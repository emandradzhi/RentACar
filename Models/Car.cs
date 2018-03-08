using System;
using System.ComponentModel.DataAnnotations;

namespace RentACar.Models
{
    public class Car
    {
        
        [Key]
        public int CarId { get; set; }
        
        [Required]
        public string Brand { get; set; }
        [Required]
        public string Model { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Start Date")]
        public DateTime RentFrom { get; set; }

        [Required]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "End Date")]
        public DateTime RentTo { get; set; }
        
        public string ImageUrl { get; set; }
        public bool IsAvailable { get; set; } 

        public int? PlaceId { get; set; }

    }
}
