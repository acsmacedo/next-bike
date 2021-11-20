using System.ComponentModel.DataAnnotations;

namespace NextBike.Models.Enums
{
    public enum BikeStatusEnum
    {
        [Display(Name = "Disponível")]
        Available,

        [Display(Name = "Alugada")]
        Rented,

        [Display(Name = "Em Manutenção")]
        Maintenance
    }
}
