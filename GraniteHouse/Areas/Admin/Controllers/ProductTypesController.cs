using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using GraniteHouse.Data;
using GraniteHouse.Models;

namespace GraniteHouse.Areas_Admin_Controllers
{
    [Area("Admin")]
    public class ProductTypesController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ProductTypesController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.ProductTypes.ToList());
        }

        [HttpGet]
        public IActionResult Create() 
        {
            return View();
        }

        public async Task<IActionResult> Edit(int? id)
        {
            if(id==null)
                return NotFound();
            

            var productType = await _db.ProductTypes.FindAsync(id);

            if(productType==null)
                return NotFound();

            return View(productType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProductTypes productTypes)
        {
            if(id!=productTypes.Id)
                return NotFound();

            if(ModelState.IsValid)
            {
                _db.Update(productTypes);
                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(productTypes);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductTypes productTypes)
        {
            if(ModelState.IsValid)
            {
                _db.Add(productTypes);
                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(productTypes);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if(id==null)
                return NotFound();
            

            var productType = await _db.ProductTypes.FindAsync(id);

            if(productType==null)
                return NotFound();

            return View(productType);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if(id==null)
                return NotFound();

            var productType = await _db.ProductTypes.FindAsync(id);

            if(productType==null)
                return NotFound();

            return View(productType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var productTypes = await _db.ProductTypes.FindAsync(id);

            _db.ProductTypes.Remove(productTypes);

            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}