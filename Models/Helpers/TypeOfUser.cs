using System.Runtime.Serialization;

namespace RentACar.Models.Helpers
{
    public enum TypeOfUser
    {

        [EnumMember(Value = "Admin")]
        Admin = 1,
        [EnumMember(Value = "Customer")]
        Customer = 2
        
    }
}
