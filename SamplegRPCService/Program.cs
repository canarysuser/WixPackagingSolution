using SamplegRPCService.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Host.UseWindowsService(options =>
{
    options.ServiceName = "MyGrpcService";
});
// Add services to the container.
builder.Services.AddGrpc();
builder.Services.AddCors(setupAction =>
{
    setupAction.AddPolicy("AllowAll", policy => policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());
});
var app = builder.Build();
app.UseCors("AllowAll");
// Configure the HTTP request pipeline.
app.MapGrpcService<GreeterService>().EnableGrpcWeb();

app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();
