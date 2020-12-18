module.exports = function(app) {
    var users = require('../controllers/usermanagement.controller.js');

    app.get('/api/getusers', users.getUserDetails);

    app.delete('/api/deleteuser/:id', users.deleteUser);

    app.put('/api/updateuser', users.updateEmail);
}