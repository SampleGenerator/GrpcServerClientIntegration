using Contracts.Models;
using ProtoBuf;

namespace Contracts.Requests;

[ProtoContract]
public sealed class CreateUserRequest
{
    [ProtoMember(1)]
    public string? FullName { get; init; }

    [ProtoMember(2)]
    public string? Email { get; init; }

    [ProtoMember(3)]
    public Address? Address { get; init; }

    [ProtoMember(4)]
    public IEnumerable<PhoneNumber>? PhoneNumbers { get; init; }

    [ProtoMember(5)]
    public IEnumerable<Guid>? Friends { get; init; }
}
