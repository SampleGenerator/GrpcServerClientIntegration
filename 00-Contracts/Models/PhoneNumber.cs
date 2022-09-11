using System.Runtime.Serialization;

namespace Contracts.Models;

[DataContract]
public sealed class PhoneNumber
{
    [DataMember(Order = 1)]
    public string? Value { get; init; }
}
