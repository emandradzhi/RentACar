using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace RentACar.Models.Place
{
    public class Place
    {
        public Place()
        {

        }
        public Place(int placeId, string name, string region, string country)
        {
            this.PlaceId = placeId;
            this.Name = name;
            this.Region = region;
            this.Country = country;
        }

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
