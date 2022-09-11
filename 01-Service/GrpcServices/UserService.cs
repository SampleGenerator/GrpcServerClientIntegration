using Contracts.Models;
using Contracts.Requests;
using Contracts.Services;
using ProtoBuf.Grpc;

namespace Service.GrpcServices;

internal sealed class UserService : IUserService
{
    private readonly static Dictionary<int, User> _users = new();

    public async Task<User> CreateUser(CreateUserRequest rq, CallContext context = default)
    {
        var id = _users.Count + 1;
        var rs = new User
        {
            Id = id,
            FullName = rq.FullName,
            Email = rq.Email,
            Address = rq.Address,
            PhoneNumbers = rq.PhoneNumbers,
            Friends = rq.Friends,
        };

        _users.TryAdd(id, rs);

        return await Task.FromResult(rs);
    }

    public async Task<User> GetUser(GetUserRequest rq, CallContext context = default)
    {
        var user = _users.GetValueOrDefault(rq.Id) ?? new User();
        return await Task.FromResult(user);
    }

    public async IAsyncEnumerable<User> GetUsers(CallContext context = default)
    {
        foreach (var user in _users.Values)
        {
            yield return user;
            await Task.CompletedTask;
        }
    }
}
