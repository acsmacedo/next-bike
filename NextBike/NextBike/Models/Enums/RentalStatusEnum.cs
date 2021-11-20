using System.ComponentModel.DataAnnotations;

namespace NextBike.Models.Enums
{
    public enum RentalStatusEnum
    {
        [Display(Name = "Em Andamento")]
        InProgress,

        [Display(Name = "Entrega Pendente")]
        PendingDelivery,

        [Display(Name = "Finalizado")]
        Concluded
    }
}
