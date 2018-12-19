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
    public class SpecialTagsController : Controller
    {
        private readonly ApplicationDbContext _db;

        public SpecialTagsController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.SpecialTags.ToList());
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
            

            var specialTags = await _db.SpecialTags.FindAsync(id);

            if(specialTags==null)
                return NotFound();

            return View(specialTags);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, SpecialTags specialTags)
        {
            if(id!=specialTags.Id)
                return NotFound();

            if(ModelState.IsValid)
            {
                _db.Update(specialTags);
                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(specialTags);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(SpecialTags specialTags)
        {
            if(ModelState.IsValid)
            {
                _db.Add(specialTags);
                await _db.SaveChangesAsync();

                return RedirectToAction(nameof(Index));
            }

            return View(specialTags);
        }

        public async Task<IActionResult> Details(int? id)
        {
            if(id==null)
                return NotFound();
            

            var specialTags = await _db.SpecialTags.FindAsync(id);

            if(specialTags==null)
                return NotFound();

            return View(specialTags);
        }

        public async Task<IActionResult> Delete(int? id)
        {
            if(id==null)
                return NotFound();

            var specialTags = await _db.SpecialTags.FindAsync(id);

            if(specialTags==null)
                return NotFound();

            return View(specialTags);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            var SpecialTags = await _db.SpecialTags.FindAsync(id);

            _db.SpecialTags.Remove(SpecialTags);

            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}