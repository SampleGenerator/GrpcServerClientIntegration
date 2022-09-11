using System.Runtime.Serialization;

namespace Contracts.Requests;

[DataContract]
public sealed class GetUserRequest
{
    [DataMember(Order = 1)]
    public int Id { get; init; }
}
