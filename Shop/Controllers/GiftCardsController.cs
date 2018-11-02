using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Shop.Data;
using Shop.Models;

namespace Shop.Controllers
{
    public class GiftCardsController : Controller
    {
        private readonly ShopContext _context;

        public GiftCardsController(ShopContext context)
        {
            _context = context;
        }

        // GET: GiftCards
        public async Task<IActionResult> Index()
        {
            return View(await _context.GiftCards.ToListAsync());
        }

        // GET: GiftCards/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var giftCard = await _context.GiftCards
                .FirstOrDefaultAsync(m => m.Id == id);
            if (giftCard == null)
            {
                return NotFound();
            }

            return View(giftCard);
        }

        // GET: GiftCards/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: GiftCards/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,StartDate,EndDate,Balance,Number")] GiftCard giftCard)
        {
            if (ModelState.IsValid)
            {
                _context.Add(giftCard);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(giftCard);
        }

        // GET: GiftCards/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var giftCard = await _context.GiftCards.FindAsync(id);
            if (giftCard == null)
            {
                return NotFound();
            }
            return View(giftCard);
        }

        // POST: GiftCards/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,StartDate,EndDate,Balance,Number")] GiftCard giftCard)
        {
            if (id != giftCard.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(giftCard);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GiftCardExists(giftCard.Id))
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
            return View(giftCard);
        }

        // GET: GiftCards/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var giftCard = await _context.GiftCards
                .FirstOrDefaultAsync(m => m.Id == id);
            if (giftCard == null)
            {
                return NotFound();
            }

            return View(giftCard);
        }

        // POST: GiftCards/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var giftCard = await _context.GiftCards.FindAsync(id);
            _context.GiftCards.Remove(giftCard);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GiftCardExists(int id)
        {
            return _context.GiftCards.Any(e => e.Id == id);
        }
    }
}
