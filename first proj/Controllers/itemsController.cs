using first_proj.Data;
using first_proj.Models;
using Microsoft.AspNetCore.Mvc;

namespace first_proj.Controllers
{
    public class itemsController : Controller //
    {
        public itemsController(appdbcontext db) //
        {
            _db = db;
        }

        private readonly appdbcontext _db; //

        public IActionResult Index()
        {
           IEnumerable <item> itemslist = _db.items.ToList(); //
           
            return View(itemslist);
        }
        //GET
        public IActionResult New() //
        {

            return View();
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult New(item item) //
        {
            if (item.Name == "100")
            {
                ModelState.AddModelError("Name", "Name can't equal 100");
            }
            if (ModelState.IsValid)
            {
                _db.items.Add(item);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(item);
            }
        }
        //GET
        public IActionResult Edit(int? Id) //
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var item = _db.items.Find(Id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(item item) //
        {
            if (item.Name == "100")
            {
                ModelState.AddModelError("Name", "Name can't equal 100");
            }
            if (ModelState.IsValid)
            {
                _db.items.Update(item);
                _db.SaveChanges();
                return RedirectToAction("Index");
            }
            else
            {
                return View(item);
            }
        }
        //GET
        public IActionResult Delete(int? Id) //
        {
            if (Id == null || Id == 0)
            {
                return NotFound();
            }
            var item = _db.items.Find(Id);
            if (item == null)
            {
                return NotFound();
            }
            return View(item);
        }
        //POST
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(item item) //
        {
            _db.items.Remove(item);
            _db.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
