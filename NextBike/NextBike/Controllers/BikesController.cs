using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NextBike.Interfaces;
using NextBike.Models;

namespace NextBike.Controllers
{
    public class BikesController : Controller
    {
        private readonly IBikesService _service;

        public BikesController(IBikesService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _service.FindAllAsync();

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
                await _service.AddAsync(bike);

                return RedirectToAction(nameof(Index));
            }

            return View(bike);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (!id.HasValue)
                return BadRequest();

            var bike = await _service.FindByIdAsync(id.Value);

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
                await _service.UpdateAsync(bike);

                return RedirectToAction(nameof(Index));
            }

            return View(bike);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (!id.HasValue)
                return BadRequest();

            var bike = await _service.FindByIdAsync(id.Value);

            if (bike == null)
                return NotFound();

            return View(bike);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            await _service.DeleteAsync(id);

            return RedirectToAction(nameof(Index));
        }
    }
}
