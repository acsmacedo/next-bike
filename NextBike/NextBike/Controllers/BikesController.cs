using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NextBike.Interfaces;
using NextBike.Models;
using NextBike.Models.ViewModels;

namespace NextBike.Controllers
{
    public class BikesController : Controller
    {
        private readonly IBikesService _bikeService;
        private readonly IClientsService _clientsService;
        private readonly IRentalRecordsService _rentalRecordsService;

        public BikesController(
            IBikesService bikeService, 
            IClientsService clientsService,
            IRentalRecordsService rentalRecordsService)
        {
            _bikeService = bikeService;
            _clientsService = clientsService;
            _rentalRecordsService = rentalRecordsService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _bikeService.FindAllAsync();

            return View(result);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Brand,Model,Color,Status,PricePerDay")] Bike bike)
        {
            if (ModelState.IsValid)
            {
                await _bikeService.AddAsync(bike);

                return RedirectToAction(nameof(Index));
            }

            return View(bike);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (!id.HasValue)
                return BadRequest();

            var bike = await _bikeService.FindByIdAsync(id.Value);

            if (bike == null)
                return NotFound();

            return View(bike);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Brand,Model,Color,Status,PricePerDay")] Bike bike)
        {
            if (id != bike.Id)
                return BadRequest();

            if (ModelState.IsValid)
            {
                await _bikeService.UpdateAsync(bike);

                return RedirectToAction(nameof(Index));
            }

            return View(bike);
        }

        public async Task<IActionResult> Rent(int? id)
        {
            if (!id.HasValue)
                return BadRequest();

            var bike = await _bikeService.FindByIdAsync(id.Value);

            if (bike == null)
                return NotFound();

            var clients = await _clientsService.FindAllAsync();

            return View(new RentViewModel(bike, clients));
        }

        [HttpPost]
        public async Task<IActionResult> Rent(int? clientId, int? bikeId, DateTime? expectedDeliveredDate)
        {
            if (!clientId.HasValue || !bikeId.HasValue || !expectedDeliveredDate.HasValue)
                return BadRequest();

            var bike = await _bikeService.FindByIdAsync(bikeId.Value);
            var client = await _clientsService.FindByIdAsync(clientId.Value);

            if (bike == null || client == null)
                return NotFound();

            var data = new RentalRecords(client, bike, expectedDeliveredDate.Value);

            await _rentalRecordsService.AddAsync(data);

            bike.Status = Models.Enums.BikeStatusEnum.Rented;

            await _bikeService.UpdateAsync(bike);

            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (!id.HasValue)
                return BadRequest();

            var bike = await _bikeService.FindByIdAsync(id.Value);

            if (bike == null)
                return NotFound();

            return View(bike);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _bikeService.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
