const express = require("express");
const app = express();
const server = require("http").Server(app);
const path = require('path');
io = require("socket.io").listen(server);



// Broadcasting loop works better than sending an update every time a player moves because waiting for player movement messages adds
// another source of jitter.
var updateInterval = 100; // Broadcast updates every 100 ms.

app.use(express.static(path.join(__dirname, '..', 'client')));


app.get('/', function (req, res) {

    res.sendFile(path.join(__dirname + 'index.html'));
});


server.listen(process.env.PORT || 8000);
