const { isObject } = require('util');

var app = require('express')();
var server = require('http').createServer(app);

// http server를 socket.io server로 upgrade한다
var io = require('socket.io')(server);

let clientCnt = 0;

// localhost:3000으로 서버에 접속하면 클라이언트로 index.html을 전송한다
app.get('/', function(req, res) {
  res.sendFile(__dirname + '/index-room.html');
});

var chat = io.on('connection', function(socket) {
  clientCnt++;
  console.log('Conneted by something')
  console.log(socket.id)
  console.log(clientCnt)


  if(clientCnt == 2){
    console.log("cnt == 2")
    io.emit('chk', 1);
    
  }

  socket.on('chat', function(data){
    console.log('message from client: ', data);

    // 메시지를 전송한 클라이언트를 제외한 모든 클라이언트에게 메시지를 전송한다
    socket.broadcast.emit('chat', data);

    // 메시지를 전송한 클라이언트에게만 메시지를 전송한다
     //socket.emit('test', data);

     
  });

  socket.on('keyExchange', function(data){
    console.log('message from client: ', data);

    // 메시지를 전송한 클라이언트를 제외한 모든 클라이언트에게 메시지를 전송한다
    socket.broadcast.emit('keyExchange', data);

    // 메시지를 전송한 클라이언트에게만 메시지를 전송한다
     //socket.emit('test', data);

     
  });

  socket.on('disconnect', function() {
    clientCnt--;
    console.log('user disconnected: ' + socket.name);
    console.log(clientCnt)
  });
});

server.listen(3000, function() {
  console.log('Socket IO server listening on port 3000');
});