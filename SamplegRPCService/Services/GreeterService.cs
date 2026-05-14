using Grpc.AspNetCore.Web;
using Grpc.Core;
using Microsoft.AspNetCore.Cors;

namespace SamplegRPCService.Services
{
    [EnableGrpcWeb]
    
    public class GreeterService(ILogger<GreeterService> logger) : Greeter.GreeterBase
    {
        public override Task<HelloReply> SayHello(HelloRequest request, ServerCallContext context)
        {
            logger.LogInformation("The message is received from {Name}", request.Name);

            return Task.FromResult(new HelloReply
            {
                Message = "Hello " + request.Name
            });
        }
    }
}
