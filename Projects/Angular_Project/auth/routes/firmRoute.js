module.exports = function (app) {

    var firms = require('../controllers/firm.controller.js')

    app.get('/api/firms', firms.findAll);

    app.get('/api/firms/:id', firms.findById);

    app.post('/api/firms', firms.addFirm);

    app.put('/api/firms/:id', firms.updateById);

    app.delete('/api/firms/:id', firms.removeById);

}