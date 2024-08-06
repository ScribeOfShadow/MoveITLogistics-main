using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TestDbCRUD.Data;
using TestDbCRUD.Models;
using TestDbCRUD.Models.Domain;
using Microsoft.AspNetCore.Authorization;

namespace TestDbCRUD.Controllers
{
    public class OrdersController : Controller
    {
        private readonly MoveItDbContext moveItDbContext;

        public OrdersController(MoveItDbContext moveItDbContext)
        {
            this.moveItDbContext = moveItDbContext;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var orders = await moveItDbContext.Orders.ToListAsync();
            return View(orders);
        }

        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(AddOrderViewModel addOrderRequest)
        {
            var order = new Orders()
            {
                Id = Guid.NewGuid(),
                CompanyName = addOrderRequest.CompanyName,
                Contents = addOrderRequest.Contents,
                Quantity = addOrderRequest.Quantity,
                PickupLocation = addOrderRequest.PickupLocation,
                Destination = addOrderRequest.Destination,
                OrderDate = addOrderRequest.OrderDate,
                ETA = addOrderRequest.ETA,
                PickupLocationID = addOrderRequest.PickupLocationID,
                DestinationID = addOrderRequest.DestinationID,
            };

            await moveItDbContext.Orders.AddAsync(order);
            await moveItDbContext.SaveChangesAsync();
            return RedirectToAction("Add");
        }

        [HttpGet]
        public async Task<IActionResult> View(Guid id)
        {
            var order = await moveItDbContext.Orders.FirstOrDefaultAsync(x => x.Id == id);

            if (order != null)
            {
                var viewModel = new UpdateOrderViewModel()
                {
                    Id = order.Id,
                    CompanyName = order.CompanyName,
                    Contents = order.Contents,
                    Quantity = order.Quantity,
                    PickupLocation = order.PickupLocation,
                    Destination = order.Destination,
                    OrderDate = order.OrderDate,
                    ETA = order.ETA,
                };

                return await Task.Run(() => View("View", viewModel));

            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> View(UpdateOrderViewModel model)
        {

            var order = await moveItDbContext.Orders.FindAsync(model.Id);

            if (order != null)
            {
                order.CompanyName = model.CompanyName;
                order.Contents = model.Contents;
                order.Quantity = model.Quantity;
                order.PickupLocation = model.PickupLocation;
                order.Destination = model.Destination;
                order.OrderDate = model.OrderDate;
                order.ETA = model.ETA;

                await moveItDbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> Delete(UpdateOrderViewModel model)
        {
            var order = await moveItDbContext.Orders.FindAsync(model.Id);

            if (order != null)
            {
                moveItDbContext.Orders.Remove(order);
                await moveItDbContext.SaveChangesAsync();

                return RedirectToAction("Index");
            }

            return RedirectToAction("Index");
        }

        [HttpPost]
        public async Task<IActionResult> CancelOrder(UpdateOrderViewModel model)
        {
            try
            {
                var order = await moveItDbContext.Orders.FindAsync(model.Id);

                if (order != null)
                {
                    moveItDbContext.Orders.Remove(order);
                    await moveItDbContext.SaveChangesAsync();

                    return RedirectToAction("OrderCancelled");
                }
                else
                {
                    // Handle the case where the order with the given Id doesn't exist.
                    return NotFound(); // Or return an error view or message.
                }
            }
            catch (Exception ex)
            {
                // Handle any exceptions here, log them, or return an error view.
                return View("Error");
            }
        }

        public IActionResult OrderCancelled()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Status(UpdateOrderViewModel model)
        {

            var order = await moveItDbContext.Orders.FindAsync(model.Id);
            var status = model.UserStatus;

            // Retrieve the corresponding RoleType entity based on the selected role name
            var Selectedstatus = moveItDbContext.Orders.FirstOrDefault(r => r.UserStatus == status);

            if (status == false)
            {
                order.UserStatus = true;

                await moveItDbContext.SaveChangesAsync();

                return RedirectToAction("IndexDriver","Home");
            }

            return RedirectToAction("Index");
        }

    }
}
