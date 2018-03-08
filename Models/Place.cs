using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace RentACar.Models
{
    public class Place
    {
        
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int PlaceId { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Region { get; set; }
        [Required]
        public string Country { get; set; }
    }
}
