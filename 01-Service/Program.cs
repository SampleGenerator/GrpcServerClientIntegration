using Microsoft.AspNetCore.Builder;
using ProtoBuf.Grpc.Server;
using Service.GrpcServices;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCodeFirstGrpc();

var app = builder.Build();

app.MapGrpcService<UserService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client.");

app.Run();