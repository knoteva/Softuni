const express = require('express');
const mongoose = require('mongoose');
//parse the HTTP request body and create an object that is attached to the request data.
const bodyParser = require('body-parser');
//providing the Connect/Express middleware
const cors = require('cors');

const config = require('./DB');
const userRoute = require('./routes/UserRoute');

const PORT = process.env.PORT || 5000;

mongoose.set('useNewUrlParser', true);
mongoose.set('useUnifiedTopology', true);
mongoose.set('useFindAndModify', false);
mongoose.set('useCreateIndex', true);

mongoose.connect(config.DB).then(
  () => { console.log('Database is connected') },
  err => { console.log('Can not connect to the database' + err) }
);

const app = express();

app.use(bodyParser.urlencoded({ extended: false }));
app.use(bodyParser.json());

let corsOptions = {
  origin: 'http://localhost:4200',
  optionsSuccessStatus: 200
}

app.use(cors(corsOptions))
app.use('/api/users', userRoute);
require('./routes/usermanagement.router.js')(app);

app.listen(PORT, () => {
  console.log(`Server is running on PORT ${PORT}`);
});