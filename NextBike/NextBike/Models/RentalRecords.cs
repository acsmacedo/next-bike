using System;
using System.ComponentModel.DataAnnotations;

namespace NextBike.Models
{
    public class RentalRecords
    {
        [Display(Name = "Código")]
        public int Id { get; set; }

        [Display(Name = "Cliente")]
        public Client Client { get; set; }

        [Display(Name = "Bicicleta")]
        public Bike Bike { get; set; }

        [Display(Name = "Data do Aluguel")]
        public DateTime RentalDate { get; set; }

        [Display(Name = "Data de Devolução")]
        public DateTime DeliveredDate { get; set; }

        [Display(Name = "Data Esperada de Devolução")]
        public DateTime ExpectedDeliveredDate { get; set; }

        [Display(Name = "Preço / Dia")]
        public decimal PricePerDay { get; set; }
    }
}
