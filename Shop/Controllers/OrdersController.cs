using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Models;
using Shop.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Shop.Controllers
{
    [Route("orders")]
    public class OrdersController : Controller
    {
        public ShopContext _db;

        public OrdersController(ShopContext db)
        {
            _db = db;
        }

        [Route("")]
        public async Task<IActionResult> Index()
        {
            var orders = await _db.Orders
                .Include(x => x.Items)
                .ThenInclude(x => x.Product)
                .OrderByDescending(x => x.Number)
                .ToListAsync();

            var ordersViewModel = orders
                .Select(order => new OrderViewModel
                {
                    Id = order.Id,
                    Number = order.Number,
                    IsItPaid = order.IsItPayed,
                    Items = order.Items
                        .Select(item => new OrderItemViewModel
                        {
                            ProductName = item.Product.Name,
                            ProductPrice = item.Product.Price,
                            Count = item.Count
                        }).ToList()
                });

            return View(ordersViewModel);
        }

        [HttpGet]
        [Route("{orderId:int}/payed")]
        public async Task<ActionResult<bool>> Payed(int orderId)
        {
            var order = await _db.Orders.FirstOrDefaultAsync(x => x.Id == orderId);

            if (order == null)
                return false;

            order.IsItPayed = true;
            await _db.SaveChangesAsync();

            return true;
        }
    }
}