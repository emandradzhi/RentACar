using RentACar.Models.Helpers;
using System.ComponentModel.DataAnnotations;

namespace RentACar.Models
{
    public class User
    {
        
        [Key]
        public int UserId { get; set; }
        [Required]
        public string Username { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }
        [Display(Name = "Type of user")]
        public TypeOfUser TypeOfUser { get; set; }

        public int? PlaceId { get; set; }
        public int? CarId { get; set; }
    }
}
