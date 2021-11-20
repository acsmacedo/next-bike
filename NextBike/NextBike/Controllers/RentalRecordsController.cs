using Microsoft.AspNetCore.Mvc;
using NextBike.Interfaces;
using System.Threading.Tasks;

namespace NextBike.Controllers
{
    public class RentalRecordsController : Controller
    {
        private readonly IRentalRecordsService _service;

        public RentalRecordsController(IRentalRecordsService service)
        {
            _service = service;
        }

        public async Task<IActionResult> Index()
        {
            var result = await _service.FindAllAsync();

            return View(result);
        }
    }
}
