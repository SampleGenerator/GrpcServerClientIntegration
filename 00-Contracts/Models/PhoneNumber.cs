using ProtoBuf;

namespace Contracts.Models;

[ProtoContract]
public sealed class PhoneNumber
{
    [ProtoMember(1)]
    public string? Value { get; init; }
}
