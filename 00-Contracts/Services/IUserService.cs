using Contracts.Models;
using Contracts.Requests;
using ProtoBuf.Grpc;
using System.ServiceModel;

namespace Contracts.Services;

[ServiceContract]
public interface IUserService
{
    [OperationContract]
    Task<User> CreateUser(CreateUserRequest request, CallContext context = default);

    [OperationContract]
    Task<User> GetUser(GetUserRequest request, CallContext context = default);

    [OperationContract]
    IAsyncEnumerable<User> GetUsers(CallContext context = default);
}
