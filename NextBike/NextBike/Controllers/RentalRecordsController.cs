using Microsoft.AspNetCore.Mvc;
using NextBike.Interfaces;
using NextBike.Models.Enums;
using System;
using System.Threading.Tasks;

namespace NextBike.Controllers
{
    public class RentalRecordsController : Controller
    {
        private readonly IRentalRecordsService _rentalRecordsService;
        private readonly IBikesService _bikesService;

        public RentalRecordsController(
            IRentalRecordsService rentalRecordsService, 
            IBikesService bikesService)
        {
            _rentalRecordsService = rentalRecordsService;
            _bikesService = bikesService;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _rentalRecordsService.FindAllAsync();

            return View(result);
        }

        public async Task<IActionResult> Delivery(int? id)
        {
            if (!id.HasValue)
                return BadRequest();

            var record = await _rentalRecordsService.FindByIdAsync(id.Value);
            var bike = await _bikesService.FindByIdAsync(record.BikeId);

            if (bike is null || record is null)
                return NotFound();

            bike.Status = BikeStatusEnum.Available;
            await _bikesService.UpdateAsync(bike);

            record.DeliveredDate = DateTime.Now;
            await _rentalRecordsService.UpdateAsync(record);

            return RedirectToAction(nameof(Index));
        }
    }
}
