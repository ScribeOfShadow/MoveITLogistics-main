using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestDbCRUD.Data;
using TestDbCRUD.Models;
using TestDbCRUD.Models.Domain;

namespace TestDbCRUD.Controllers
{
    public class DestinationController : Controller
    {
        private readonly MoveItDbContext moveItDbContext;

        public DestinationController(MoveItDbContext moveItDbContext)
        {
            this.moveItDbContext = moveItDbContext;
        }


        [HttpGet]
        public async Task<IActionResult> Routes()
        {
            
            var orders = await moveItDbContext.Orders.ToListAsync();
            return View(orders);
        }

        [HttpGet]
        public async Task<IActionResult> Maps()
        {
            ViewBag.ShowNavigationBar = false;
            return View();
        }

        
        [HttpGet]
        public async Task<IActionResult> MapsDriver()
        {
           
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> RoutesDriver()
        {
            
            var orders = await moveItDbContext.Orders.ToListAsync();
            return View(orders);
        }

    }
}
