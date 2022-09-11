using System.Runtime.Serialization;

namespace Contracts.Models;

[DataContract]
public sealed class User
{
    [DataMember(Order = 1)]
    public int Id { get; init; }

    [DataMember(Order = 2)]
    public string? FullName { get; init; }

    [DataMember(Order = 3)]
    public string? Email { get; init; }

    [DataMember(Order = 4)]
    public Address? Address { get; init; }

    [DataMember(Order = 5)]
    public IEnumerable<PhoneNumber>? PhoneNumbers { get; init; }

    [DataMember(Order = 6)]
    public IEnumerable<Guid>? Friends { get; init; }
}
