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

        [Display(Name = "Código do Cliente")]
        public int ClientId { get; set; }

        [Display(Name = "Bicicleta")]
        public Bike Bike { get; set; }

        [Display(Name = "Código da Bicicleta")]
        public int BikeId { get; set; }

        [Display(Name = "Data do Aluguel")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime RentalDate { get; set; }

        [Display(Name = "Data de Devolução")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime? DeliveredDate { get; set; }

        [Display(Name = "Data Esperada de Devolução")]
        [DisplayFormat(DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ExpectedDeliveredDate { get; set; }

        [Display(Name = "Preço / Dia")]
        public decimal PricePerDay { get; set; }

        public RentalRecords()
        {
        }

        public RentalRecords(
            Client client, 
            Bike bike, 
            DateTime expectedDeliveredDate)
        {
            Client = client;
            ClientId = client.Id;
            Bike = bike;
            BikeId = bike.Id;
            RentalDate = DateTime.Now;
            ExpectedDeliveredDate = expectedDeliveredDate;
            PricePerDay = bike.PricePerDay;
        }
    }
}
