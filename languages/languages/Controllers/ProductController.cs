using languages.Models;
using Microsoft.AspNetCore.Mvc;


namespace languages.Controllers
{
	public class ProductController : Controller
	{
		Entities Entities;

        public ProductController(Entities entities)
        {
			Entities = entities;
            
        }
		[HttpGet]
		public IActionResult New()
		{
			return View();
		}
		[HttpPost]
		public IActionResult New(SkinCareProduct Product)
		{
			Entities.SkinCare.Add(Product);
			Entities.SaveChanges();
			return RedirectToAction("Index", "Home");
			
		}
		[HttpGet]
		public IActionResult Edit(int id) {
			var Product = Entities.SkinCare.FirstOrDefault(x => x.Id == id);
			return View(Product);
		}
		public IActionResult Edit(SkinCareProduct NewProduct, int id) {
            if (NewProduct.Name !=null)
            {
                var OldProduct = Entities.SkinCare.FirstOrDefault(x => x.Id == id);
                OldProduct.Name = NewProduct.Name;
                OldProduct.Description = NewProduct.Description;
                OldProduct.Image = NewProduct.Image;
                Entities.SaveChanges();
				return RedirectToAction("Index", "Home");
            }
			return View(NewProduct);
		}
        public IActionResult Delete(int id)
        {
            var product = Entities.SkinCare.FirstOrDefault(x => x.Id == id);
            if (product == null) return NotFound();
            return View(product);
        }
        [HttpPost]
        public IActionResult ConfirmDelete(int id)
        {
            var product = Entities.SkinCare.FirstOrDefault(x => x.Id == id);
            if (product == null) return NotFound();
            Entities.SkinCare.Remove(product);
            Entities.SaveChanges();
            return RedirectToAction("Index", "Home");

        }

    }
}
