using Contracts.Models;
using Contracts.Requests;
using Contracts.Services;
using ProtoBuf.Grpc;

namespace Service.GrpcServices;

internal sealed class UserService : IUserService
{
    private readonly static Dictionary<int, User> _users = new();

    public ValueTask<User> CreateUser(CreateUserRequest rq, CallContext context = default)
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
            CreationDate = DateTime.Now,
        };

        _users.TryAdd(id, rs);

        return new ValueTask<User>(rs);
    }

    public ValueTask<User> GetUser(GetUserRequest rq, CallContext context = default)
    {
        var user = _users.GetValueOrDefault(rq.Id) ?? new User();
        return new ValueTask<User>(user);
    }

    public async IAsyncEnumerable<User> GetUsersStream(CallContext context = default)
    {
        foreach (var user in _users.Values)
        {
            yield return user;
            await Task.CompletedTask;
        }
    }

    public ValueTask<IEnumerable<User>> GetUsersBuffer(CallContext context = default)
    {
        var users = _users.Values.ToList();
        return new ValueTask<IEnumerable<User>>(users);
    }
}
