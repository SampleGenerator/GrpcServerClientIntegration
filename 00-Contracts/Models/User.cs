using ProtoBuf;
using System.Runtime.Serialization;

namespace Contracts.Models;

[ProtoContract]
public sealed class User
{
    [ProtoMember(1)]
    public int Id { get; init; }

    [ProtoMember(2)]
    public string? FullName { get; init; }

    [ProtoMember(3)]
    public string? Email { get; init; }

    [ProtoMember(4)]
    public Address? Address { get; init; }

    [ProtoMember(5)]
    public IEnumerable<PhoneNumber>? PhoneNumbers { get; init; }

    [ProtoMember(6)]
    public IEnumerable<Guid>? Friends { get; init; }

    [ProtoMember(7, DataFormat = DataFormat.WellKnown)]
    public DateTime CreationDate { get; set; }
}
