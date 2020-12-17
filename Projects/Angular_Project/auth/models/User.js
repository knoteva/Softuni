const mongoose = require('mongoose')
const bcrypt = require('bcryptjs')
const Schema = mongoose.Schema

const userSchema = new Schema({
  username: {
    type: String,
    min: [3, 'Min 3 characters are required'],
    max: [10, 'Max 10 characters are required']
  },
  email: {
    type: String,
    min: [4, 'Min 4 characters are required'],
    max: [16, 'Max 16 characters are required'],
    lowercase: true,
    unique: true,
    required: 'Email is required',
    match: [/(?!.*\.\.)(^[^\.][^@\s]+@[^@\s]+\.[^@\s\.]+$)/]
  },
  password: {
    type: String,
    min: [4, 'Min 4 characters are required'],
    max: [10, 'Max 10 characters are required'],
    required: 'Password is required'
  },
  passwordConfirmation: {
    type: String,
    min: [4, 'Min 4 characters are required'],
    max: [10, 'Max 10 characters are required']
  }
});

//The hook function hash the Password
userSchema.pre('save', function (next) {
  const user = this
  bcrypt.genSalt(10, function (err, salt) {
    if (err) {
      return res.status(422).json({
        'error': 'There is an error while gensalt hash'
      })
    }
    bcrypt.hash(user.password, salt, function (err, hash) {
      if (err) {
        return res.status(422).json({
          'error': 'There is an error while password hash'
        })
      }
      user.password = hash
      next()
    })
  })
})


// Check if password is valid or not whe the user is trying to log in
userSchema.methods.hasSamePassword = function (password) {
  return bcrypt.compareSync(password, this.password)
}

module.exports = mongoose.model('User', userSchema)