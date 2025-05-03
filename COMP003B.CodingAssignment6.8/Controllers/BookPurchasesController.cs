using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using COMP003B.CodingAssignment6._8.Data;
using COMP003B.CodingAssignment6._8.Models;

namespace COMP003B.CodingAssignment6._8.Controllers
{
    public class BookPurchasesController : Controller
    {
        private readonly WebDevAcademyContext _context;

        public BookPurchasesController(WebDevAcademyContext context)
        {
            _context = context;
        }

        // GET: BookPurchases
        public async Task<IActionResult> Index()
        {
            var webDevAcademyContext = _context.BookPurchases.Include(b => b.Book).Include(b => b.Customer);
            return View(await webDevAcademyContext.ToListAsync());
        }

        // GET: BookPurchases/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookPurchase = await _context.BookPurchases
                .Include(b => b.Book)
                .Include(b => b.Customer)
                .FirstOrDefaultAsync(m => m.BookPurchaseId == id);
            if (bookPurchase == null)
            {
                return NotFound();
            }

            return View(bookPurchase);
        }

        // GET: BookPurchases/Create
        public IActionResult Create()
        {
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "Author");
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "Email");
            return View();
        }

        // POST: BookPurchases/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BookPurchaseId,BookId,CustomerId")] BookPurchase bookPurchase)
        {
            if (ModelState.IsValid)
            {
                _context.Add(bookPurchase);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "Author", bookPurchase.BookId);
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "Email", bookPurchase.CustomerId);
            return View(bookPurchase);
        }

        // GET: BookPurchases/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookPurchase = await _context.BookPurchases.FindAsync(id);
            if (bookPurchase == null)
            {
                return NotFound();
            }
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "Author", bookPurchase.BookId);
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "Email", bookPurchase.CustomerId);
            return View(bookPurchase);
        }

        // POST: BookPurchases/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BookPurchaseId,BookId,CustomerId")] BookPurchase bookPurchase)
        {
            if (id != bookPurchase.BookPurchaseId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(bookPurchase);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BookPurchaseExists(bookPurchase.BookPurchaseId))
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
            ViewData["BookId"] = new SelectList(_context.Books, "BookId", "Author", bookPurchase.BookId);
            ViewData["CustomerId"] = new SelectList(_context.Customers, "CustomerId", "Email", bookPurchase.CustomerId);
            return View(bookPurchase);
        }

        // GET: BookPurchases/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var bookPurchase = await _context.BookPurchases
                .Include(b => b.Book)
                .Include(b => b.Customer)
                .FirstOrDefaultAsync(m => m.BookPurchaseId == id);
            if (bookPurchase == null)
            {
                return NotFound();
            }

            return View(bookPurchase);
        }

        // POST: BookPurchases/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var bookPurchase = await _context.BookPurchases.FindAsync(id);
            if (bookPurchase != null)
            {
                _context.BookPurchases.Remove(bookPurchase);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BookPurchaseExists(int id)
        {
            return _context.BookPurchases.Any(e => e.BookPurchaseId == id);
        }
    }
}
