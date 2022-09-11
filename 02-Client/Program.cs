using Contracts.Models;
using Contracts.Requests;
using Contracts.Services;
using Grpc.Net.Client;
using Microsoft.Extensions.DependencyInjection;
using Polly;
using ProtoBuf.Grpc.Client;
using ProtoBuf.Grpc.ClientFactory;
using System.Text.Json;

var services = new ServiceCollection();
services.AddCodeFirstGrpcClient<IUserService>(o =>
{
    o.Address = new Uri("https://localhost:5001");
})
.AddTransientHttpErrorPolicy(x => x.WaitAndRetryAsync(3, _ => TimeSpan.FromMilliseconds(100)))
.AddTransientHttpErrorPolicy(x => x.CircuitBreakerAsync(15, TimeSpan.FromSeconds(1)))
.AddPolicyHandler(Policy.TimeoutAsync(TimeSpan.FromSeconds(10), (context, _, _, ex) =>
{
    throw new Exception("An error happened.");
}).AsAsyncPolicy<HttpResponseMessage>());

var provider = services.BuildServiceProvider();
var client = provider.GetRequiredService<IUserService>();

await CreateUser(client);

await GetUser(client);

await GetUsers(client);

Console.WriteLine("Press any key to exit...");
Console.ReadKey();


static async Task CreateUser(IUserService client)
{
    var request = new CreateUserRequest
    {
        FullName = "Farshad Goodarzi",
        Email = "fgoodarzi.pr@gmail.com",
        Address = new Address { Value = "Address1" },
        PhoneNumbers = new List<PhoneNumber>
    {
        new PhoneNumber { Value = "09120000000" },
        new PhoneNumber { Value = "09120000001" },
        new PhoneNumber { Value = "09120000002" },
    },
        Friends = new List<Guid> { Guid.NewGuid(), Guid.NewGuid(), Guid.NewGuid() },
    };

    var rsCreateUser = await client.CreateUser(request);
    var rsCreateUserJson = JsonSerializer.Serialize(rsCreateUser, new JsonSerializerOptions
    {
        WriteIndented = true,
    });

    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Create user response");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine(rsCreateUserJson);
    Console.WriteLine($"=================================");
}

static async Task GetUser(IUserService client)
{
    var rsGetUser = await client.GetUser(new GetUserRequest { Id = 1, });
    var rsGetUserJson = JsonSerializer.Serialize(rsGetUser, new JsonSerializerOptions
    {
        WriteIndented = true,
    });
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Get user response");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine(rsGetUserJson);
    Console.WriteLine($"=================================");
}

static async Task GetUsers(IUserService client)
{
    var rsGetUsers = await client.GetUsers().ToListAsync();
    var rsGetUsersJson = JsonSerializer.Serialize(rsGetUsers, new JsonSerializerOptions
    {
        WriteIndented = true,
    });
    Console.ForegroundColor = ConsoleColor.Green;
    Console.WriteLine("Get users response");
    Console.ForegroundColor = ConsoleColor.White;
    Console.WriteLine(rsGetUsersJson);
    Console.WriteLine($"=================================");
}