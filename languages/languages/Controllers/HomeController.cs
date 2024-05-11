using System.Diagnostics;
using languages.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace languages.Controllers
{
	public class HomeController : Controller
	{
		private readonly ILogger<HomeController> _logger;
		Entities entities;


		public HomeController(ILogger<HomeController> logger,Entities entities)
		{
			_logger = logger;
			this.entities = entities;
		}
		public ActionResult Details(int id) {

			var mov=entities.SkinCare.FirstOrDefault(x => x.Id == id);
			return View(mov);
		}
		
		public IActionResult Index()
		{
			var movs=entities.SkinCare.ToList();
			return View(movs);
		}

		public IActionResult Privacy()
		{
			return View();
		}

		[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
		public IActionResult Error()
		{
			return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
		}
	}
}
