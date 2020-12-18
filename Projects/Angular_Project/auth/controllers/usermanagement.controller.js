const User = require('../models/User')

  exports.getUserDetails = (req,res) => {
    User.find({}, (err, data) => {
      if(err) throw err;
      res.json(data);
    })
  }