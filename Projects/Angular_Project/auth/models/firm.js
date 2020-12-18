const mongoose = require('mongoose'), Schema = mongoose.Schema;

const FirmSchema = mongoose.Schema({
    name: String
});

module.exports = mongoose.model('Firm', FirmSchema);