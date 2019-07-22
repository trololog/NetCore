using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GraniteHouse.Data;
using GraniteHouse.Models;

using Microsoft.AspNetCore.Mvc;

namespace GraniteHouse.Areas_Admin_Controllers
{
    [Area("Admin")]
    public class AdminUsersController : Controller
    {
        private readonly ApplicationDbContext _db;

        public AdminUsersController(ApplicationDbContext db)
        {
            _db = db;
        }

        public IActionResult Index()
        {
            return View(_db.ApplicationUsers.ToList());
        }

        public async Task<IActionResult> Edit(string id) {

            if(id==null || id.Trim().Length == 0)
                return NotFound();

            var userFromDb = await _db.ApplicationUsers.FindAsync(id);

            if(userFromDb == null)
                return NotFound();

            return View(userFromDb);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(string id, ApplicationUser appUser) {
            if(id != appUser.Id)
                return NotFound();
            
            if(ModelState.IsValid) {
                ApplicationUser userFromDb = _db.ApplicationUsers.FirstOrDefault(u => u.Id == id);
                userFromDb.Name = appUser.Name;
                userFromDb.PhoneNumber = appUser.PhoneNumber;

                _db.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            return View(appUser);
        }
    }
}