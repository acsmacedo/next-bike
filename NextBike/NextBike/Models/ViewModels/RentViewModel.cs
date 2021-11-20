using System;
using System.Collections.Generic;

namespace NextBike.Models.ViewModels
{
    public class RentViewModel
    {
        public Bike Bike { get; set; }
        public IEnumerable<Client> Clients { get; set; }
        public int ClientId { get; set; }
        public int BikeId { get; set; }
        public DateTime ExpectedDeliveredDate { get; set; } = DateTime.Now;

        public RentViewModel(Bike bike, IEnumerable<Client> clients)
        {
            Bike = bike;
            Clients = clients;
            BikeId = bike.Id;
        }
    }
}
