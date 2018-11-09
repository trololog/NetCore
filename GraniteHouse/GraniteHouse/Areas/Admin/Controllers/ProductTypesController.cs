using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraniteHouse.Data;
using Microsoft.AspNetCore.Mvc;
using GraniteHouse.Models;

namespace GraniteHouse.Areas_Admin_Controllers
{
    [Area("Admin")]
    public class ProductTypesController : Controller
    {
        private readonly ApplicationDbContext _db;

        public ProductTypesController(ApplicationDbContext db) {
            _db = db;
        }

        public IActionResult Index()
        {
            var productTypes = _db.ProductTypes.ToList();

            return View(productTypes);
        }

        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> Edit(int? id) 
        {
            if (id==null)
                return NotFound();
            

            var productType = await _db.ProductTypes.FindAsync(id);

            if(productType==null)
                return NotFound();

            return View(productType);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(ProductTypes productTypes)
        {
            if(!ModelState.IsValid) 
                return View(productTypes);

            _db.Add(productTypes);
            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, ProductTypes productTypes)
        {
            if(id!=productTypes.Id)
                return NotFound();

            if(!ModelState.IsValid) 
                return View(productTypes);

            _db.Update(productTypes);

            await _db.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        public async Task<IActionResult> Details(int? id) {
             if (id==null)
                return NotFound();
            

            var productType = await _db.ProductTypes.FindAsync(id);

            if(productType==null)
                return NotFound();

            return View(productType);
        }
    }
}