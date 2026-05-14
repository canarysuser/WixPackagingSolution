const Service = require("node-windows").Service; 
const path=require('path'); 

const svc = new Service({
    name: 'GrpcNodeService', 
    description: 'Runs the gRPC Service hosted in node env',
    script: path.join(__dirname, 'app.js'),
    wait: 2, 
    grow: 0.25
});

svc.on("install", function() { 
    console.log("Daemon files created successfully.");
   //svc.uninstall(); 
})
svc.on("uninstall", function() { 
    process.exit(0);
})
svc.install();
//svc.uninstall();