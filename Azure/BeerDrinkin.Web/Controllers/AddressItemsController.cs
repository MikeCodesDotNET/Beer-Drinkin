using System.Linq;
using Microsoft.AspNet.Mvc;
using Microsoft.AspNet.Mvc.Rendering;
using Microsoft.Data.Entity;
using BeerDrinkin.Web.DataObjects;
using BeerDrinkin.Web.Models;

namespace BeerDrinkin.Web.Controllers
{
    public class AddressItemsController : Controller
    {
        private ApplicationDbContext _context;

        public AddressItemsController(ApplicationDbContext context)
        {
            _context = context;    
        }

        // GET: AddressItems
        public IActionResult Index()
        {
            return View(_context.AddressItems.ToList());
        }

        // GET: AddressItems/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            AddressItem addressItem = _context.AddressItems.Single(m => m.Id == id);
            if (addressItem == null)
            {
                return HttpNotFound();
            }

            return View(addressItem);
        }

        // GET: AddressItems/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: AddressItems/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(AddressItem addressItem)
        {
            if (ModelState.IsValid)
            {
                _context.AddressItems.Add(addressItem);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(addressItem);
        }

        // GET: AddressItems/Edit/5
        public IActionResult Edit(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            AddressItem addressItem = _context.AddressItems.Single(m => m.Id == id);
            if (addressItem == null)
            {
                return HttpNotFound();
            }
            return View(addressItem);
        }

        // POST: AddressItems/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(AddressItem addressItem)
        {
            if (ModelState.IsValid)
            {
                _context.Update(addressItem);
                _context.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(addressItem);
        }

        // GET: AddressItems/Delete/5
        [ActionName("Delete")]
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return HttpNotFound();
            }

            AddressItem addressItem = _context.AddressItems.Single(m => m.Id == id);
            if (addressItem == null)
            {
                return HttpNotFound();
            }

            return View(addressItem);
        }

        // POST: AddressItems/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            AddressItem addressItem = _context.AddressItems.Single(m => m.Id == id);
            _context.AddressItems.Remove(addressItem);
            _context.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}
