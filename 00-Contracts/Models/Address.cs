using ProtoBuf;

namespace Contracts.Models;

[ProtoContract]
public sealed class Address
{
    [ProtoMember(1)]
    public string? Value { get; init; }
}
