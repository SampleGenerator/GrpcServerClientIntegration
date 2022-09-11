using ProtoBuf;

namespace Contracts.Requests;

[ProtoContract]
public sealed class GetUserRequest
{
    [ProtoMember(1)]
    public int Id { get; init; }
}
