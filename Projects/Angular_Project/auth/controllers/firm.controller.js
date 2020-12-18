const Firm = require('../models/firm.js');

exports.findAll = (req, res) => {
    Firm.find()
        .then(products => {
            res.send(products);
        }).catch(err => {
            res.status(500).send({
                message: err.message
            });
        });
};

exports.findById = (req, res) => {
    Firm.findById(req.params.id, (err, firm) => {
        if (err) throw err;
        res.send(firm);
    })
};

exports.addFirm = (req, res) => {
    Firm.create(req.body, (err, data) => {
        if (err) { throw err; }
        res.send(data);
    })
};

exports.removeById = (req, res) => {
    Firm.findByIdAndRemove(req.params.id, (err, firm) => {
        if (err) throw err;
        res.send(firm);
    })
}

exports.updateById = (req, res) => {
    Firm.findByIdAndUpdate(req.params.id, req.body, (err, firm) => {
        if (err) throw err;
        res.send(firm);
    })
}