using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using SalesTracker.Models;
using SalesTracker.ViewModels;
using System.Security.Claims;
using Microsoft.EntityFrameworkCore;

namespace SalesTracker.Controllers
{
    public class InventoryController : Controller
    {
        private readonly SalesTrackerContext _db;
        private readonly UserManager<User> _userManager;


        public InventoryController(UserManager<User> userManager, SalesTrackerContext db)
        {
            _userManager = userManager;
            _db = db;
        }
        public IActionResult Index()
        {
            return View(_db.Inventories.ToList());
        }
        public IActionResult Details(int id)
        {
            var thisInventory = _db.Inventories.FirstOrDefault(inventory => inventory.InventoryId == id);
            return View(thisInventory);
        }
        public IActionResult Create()
        {
            return View();
        }
        

        [HttpPost]
        public async Task<IActionResult> Create(Inventory inventory)
        {
            var userId = this.User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var currentUser = await _userManager.FindByIdAsync(userId);
            inventory.User = currentUser;
            _db.Inventories.Add(inventory);
            _db.SaveChanges();
            return RedirectToAction("Index", "Account");
        }
        public IActionResult Edit(int id)
        {
            var thisInventory = _db.Inventories.FirstOrDefault(inventory => inventory.InventoryId == id);
            return View(thisInventory);
        }
        [HttpPost]
        public IActionResult Edit(Inventory inventory)
        {
            _db.Entry(inventory).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Index", "Account");
        }
        public ActionResult Delete(int id)
        {
            var thisInventory = _db.Inventories.FirstOrDefault(inventory => inventory.InventoryId == id);
            return View(thisInventory);
        }
        [HttpPost, ActionName("Delete")]
        public IActionResult DeleteConfirmed(int id)
        {
            var thisInventory = _db.Inventories.FirstOrDefault(inventory => inventory.InventoryId == id);
            _db.Inventories.Remove(thisInventory);
            _db.SaveChanges();
            return RedirectToAction("Index", "Account");
        }
        [HttpPost]
        public IActionResult NewInventory(string newName, string newDescription, string newPrice)
        {
            Inventory newInventory = new Inventory(newName, newDescription, newPrice);
            _db.Inventories.Add(newInventory);
            _db.SaveChanges();
            return Json(newInventory);
        }
    }
}
