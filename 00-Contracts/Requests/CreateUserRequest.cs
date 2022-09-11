using Contracts.Models;
using System.Runtime.Serialization;

namespace Contracts.Requests;

[DataContract]
public sealed class CreateUserRequest
{
    [DataMember(Order = 1)]
    public string? FullName { get; init; }

    [DataMember(Order = 2)]
    public string? Email { get; init; }

    [DataMember(Order = 3)]
    public Address? Address { get; init; }

    [DataMember(Order = 4)]
    public IEnumerable<PhoneNumber>? PhoneNumbers { get; init; }

    [DataMember(Order = 5)]
    public IEnumerable<Guid>? Friends { get; init; }
}
