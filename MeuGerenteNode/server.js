"use strict";
const http = require('http');
var port = process.env.port || 1337;
http.createServer(function (req, res) {
    var spark = require('ciscospark');
    spark.rooms.list({
        max: 10
    })
        .then(function (rooms) {
        var room = rooms.items.filter(function (room) {
            return room.title === 'My First Room!';
        })[0];
        return spark.messages.create({
            text: 'Hello World!',
            roomId: room.id
        });
    })
        .catch(function (reason) {
        console.error(reason);
        process.exit(1);
    });
    res.writeHead(200, { 'Content-Type': 'text/plain' });
    res.end('Hello World\n');
}).listen(port);
//# sourceMappingURL=server.js.map