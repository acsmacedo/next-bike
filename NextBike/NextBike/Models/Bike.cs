using NextBike.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace NextBike.Models
{
    public class Bike
    {
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Display(Name = "Marca")]
        public string Brand { get; set; }

        [Display(Name = "Modelo")]
        public string Model { get; set; }

        [Display(Name = "Cor")]
        public string Color { get; set; }

        [Display(Name = "Situação")]
        public BikeStatusEnum Status { get; set; }

        [Display(Name = "Preço / Dia")]
        public decimal PricePerDay { get; set; }
    }
}
