using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using NextBike.Interfaces;
using NextBike.Models;

namespace NextBike.Controllers
{
    public class ClientsController : Controller
    {
        private readonly IClientsService _service;

        public ClientsController(IClientsService service)
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
        public async Task<IActionResult> Create([Bind("Id,Name,Address,Phone,BirthDay,MaxQtyRented")] Client client)
        {
            if (ModelState.IsValid)
            {
                await _service.AddAsync(client);

                return RedirectToAction(nameof(Index));
            }

            return View(client);
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if (!id.HasValue)
                return BadRequest();

            var client = await _service.FindByIdAsync(id.Value);

            if (client == null)
                return NotFound();

            return View(client);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Name,Address,Phone,BirthDay,MaxQtyRented")] Client client)
        {
            if (id != client.Id)
                return BadRequest();

            if (ModelState.IsValid)
            {
                await _service.UpdateAsync(client);

                return RedirectToAction(nameof(Index));
            }

            return View(client);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if (!id.HasValue) 
                return BadRequest();

            var client = await _service.FindByIdAsync(id.Value);

            if (client == null)
                return NotFound();

            return View(client);
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
