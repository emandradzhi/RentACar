using System.Runtime.Serialization;

namespace RentACar.Models.Helpers
{
    public enum IsCarAvailable
    {

        [EnumMember(Value = "Available")]
        Available = 1,
        [EnumMember(Value = "NonAvailable")]
        NonAvailable = 2

    }
}
