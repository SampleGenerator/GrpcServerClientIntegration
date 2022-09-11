using Contracts.Models;
using Contracts.Requests;
using ProtoBuf.Grpc;
using ProtoBuf.ServiceModel;
using System.ServiceModel;

namespace Contracts.Services;

[ServiceContract]
public interface IUserService
{
    [OperationContract, ProtoBehavior]
    ValueTask<User> CreateUser(CreateUserRequest request, CallContext context = default);

    [OperationContract, ProtoBehavior]
    ValueTask<User> GetUser(GetUserRequest request, CallContext context = default);

    [OperationContract, ProtoBehavior]
    IAsyncEnumerable<User> GetUsersStream(CallContext context = default);

    [OperationContract, ProtoBehavior]
    ValueTask<IEnumerable<User>> GetUsersBuffer(CallContext context = default);
}
