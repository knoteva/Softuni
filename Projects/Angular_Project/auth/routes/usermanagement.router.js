module.exports = function(app) {
    var users = require('../controllers/usermanagement.controller.js');

    app.get('/api/getusers', users.getUserDetails);

}