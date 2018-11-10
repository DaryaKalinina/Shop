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
                .ToListAsync();

            var ordersViewModel = orders
                .Select(order => new OrderViewModel
                {
                    Number = order.Number,
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
        // GET: Orders/Pay/5
        // GET: GiftCards/Edit/5
        public async Task<IActionResult> Pay(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var order = await _db.OrderItems.FindAsync(id);
            if (order == null)
            {
                return NotFound();
            }
            return View(order);
        }

        // POST: Orders/Pay/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Pay(int id, [Bind("Id,Product ,Oder ,Count,IsItPaid")] OrderItem order)
        {
            if (id != order.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _db.Update(order);
                    await _db.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!OrderEists(order.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(order);
        }

        private bool OrderEists(int id)
        {
            throw new NotImplementedException();
        }
    }
}