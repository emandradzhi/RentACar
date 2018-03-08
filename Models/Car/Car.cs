using RentACar.Models.Helpers;
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

        [Display(Name = "Image")]
        public string ImageUrl { get; set; }

        [Display(Name = "Availablity")]
        public IsCarAvailable IsCarAvailable { get; set; }

        public int? PlaceId { get; set; }

    }
}
