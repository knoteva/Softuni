const User = require('../models/User')
const env = require('../DB')
const jwt = require('jsonwebtoken')

//status(422): Unprocessable Entity


// save the User in MongoDB
exports.register = function (req, res) {
  const { username, email, password, passwordConfirmation } = req.body

  //Check if the email or password are empty
  if (!email || !password) {
    return res.status(422).json({ 'error': 'Please provide email and password' })
  }

  //Check if passowrd match
  if (password != passwordConfirmation) {
    return res.status(422).json({ 'error': 'Password does not match' })
  }

  User.findOne({ email }, function (err, existingUser) {
    if (err) {
      return res.status(422).json({ 'error': 'Oops! Something went Wrong' })
    }
    //Check if user already exist
    if (existingUser) {
      return res.status(422).json({ 'error': 'This email already exists' })
    }

    else {
      //Create user
      const user = new User({
        username, email, password
      })

      //Save user on database
      user.save(function (err) {
        if (err) {
          return res.status(422).json({
            'error': 'Oops! Something went wrong'
          })
        }
        return res.status(200).json({ 'registered': true })
      })
    }
  })
 }


exports.login = function (req, res) { 
  const { email, password } = req.body

  //Check if the email or password are empty
  if (!email || !password) {
    return res.status(422).json({ 'error': 'Please provide email and password' })
  }

  User.findOne({ email }, function (err, user) {
    if (err) {
      return res.status(422).json({
        'error': 'Oops! Something went wrong'
      })
    }

    //Check if the email is on database
    if (!user) {
      return res.status(422).json({ 'error': 'Invalid user' })
    }

    //Check if the passowrd is wrong
    if (user.hasSamePassword(password)) {
      json_token = jwt.sign(
        {
          userId: user.id,
          username: user.username
        },
        env.secret,
        { expiresIn: '1h' })

      return res.json(json_token)
    }
    else {
      return res.status(422).json({ 'error': 'Wrong email or password' })
    }
  })
}

//middleware will protect the private route
exports.authMiddleware = function (req, res, next) {
  const json_token = req.headers.authorization
  try {
    if (json_token) {
      const user = parseToken(json_token)
      User.findById(user.userId, function (err, user) {
        if (err) {
          return res.status(422).json({
            'error': 'Oops! Something went wrong'
          })
        }
        if (user) {
          res.locals.user = user
          next()
        }
        else {
          return res.status(422).json({ 'error': 'Not authorized user' })
        }
      })
    }
    else {
      return res.status(422).json({ 'error': 'Not authorized user' })
    }
  } catch (err) {
    res.status(403).json({
      success: false,
      message: err
    })
  }
}

function parseToken(token) {
  return jwt.verify(token.split(' ')[1], env.secret)
}