const grpc=require("@grpc/grpc-js")
const protoLoader = require('@grpc/proto-loader') 

const packageDefinition = protoLoader.loadSync("hello.proto", {}); 
const helloProto = grpc.loadPackageDefinition(packageDefinition); 

function sayHello(call, callback) { 
    callback(null, {message: 'Hello ' + call.request.name})
}

const server = new grpc.Server(); 
server.addService(helloProto.Greeter.service, { sayHello: sayHello});
server.bindAsync("127.0.0.1:50050", grpc.ServerCredentials.createInsecure(), 
() =>{
    console.log("Server running at 127.0.0.1:50050");
    server.start();
})