const User = require('../models/User')

  exports.getUserDetails = (req,res) => {
    User.find({}, (err, data) => {
      if(err) throw err;
      res.json(data);
    })
  }

  exports.deleteUser = (req, res) => {
    let user = req.params.id
    User.remove({_id:user}, (err, data) => {
      if(err) throw err;
      res.json(data);
    })
  }

  exports.updateEmail = (req, res) => {
    let uid = req.body.id;
    let new_email = req.body.email;
    console.log(uid);
    console.log(new_email);
    User.update({_id:uid},{$set : { email : new_email}}, (err, data) => {
      if(err) throw err;
      res.json(data);
    })
  }