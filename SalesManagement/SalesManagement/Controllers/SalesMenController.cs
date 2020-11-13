using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SalesManagement.Models;

namespace SalesManagement.Controllers
{
    public class SalesMenController : Controller
    {
        private readonly CoreMVCContext _context;
        private readonly string admin = "Administrator";

        public SalesMenController(CoreMVCContext context)
        {
            _context = context;
        }

        // GET: SalesMen
        public async Task<IActionResult> Index()
        {
            return View(await _context.SalesMan.ToListAsync());
        }

        // GET: SalesMen/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesMan = await _context.SalesMan
                .FirstOrDefaultAsync(m => m.SalesManId == id);
            if (salesMan == null)
            {
                return NotFound();
            }

            return View(salesMan);
        }

        // GET: SalesMen/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: SalesMen/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("SalesManId,EmployeeId,FirstName,LastName,CreatedBy,CreatedDateTime,UpdatedBy,UpdatedDateTime")] SalesMan salesMan)
        {
            if (ModelState.IsValid)
            {
                salesMan.CreatedBy = admin;
                salesMan.CreatedDateTime = DateTime.Now;
                salesMan.UpdatedBy = admin;
                salesMan.UpdatedDateTime = DateTime.Now;

                _context.Add(salesMan);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(salesMan);
        }

        // GET: SalesMen/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesMan = await _context.SalesMan.FindAsync(id);
            if (salesMan == null)
            {
                return NotFound();
            }
            return View(salesMan);
        }

        // POST: SalesMen/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("SalesManId,EmployeeId,FirstName,LastName,CreatedBy,CreatedDateTime,UpdatedBy,UpdatedDateTime")] SalesMan salesMan)
        {
            if (id != salesMan.SalesManId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    //salesMan.CreatedBy = admin;
                    //salesMan.CreatedDateTime = DateTime.Now;
                    salesMan.UpdatedBy = admin;
                    salesMan.UpdatedDateTime = DateTime.Now;

                    _context.Update(salesMan);
                    _context.Entry(salesMan).Property(x => x.CreatedBy).IsModified = false;
                    _context.Entry(salesMan).Property(x => x.CreatedDateTime).IsModified = false;
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!SalesManExists(salesMan.SalesManId))
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
            return View(salesMan);
        }

        // GET: SalesMen/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var salesMan = await _context.SalesMan
                .FirstOrDefaultAsync(m => m.SalesManId == id);
            if (salesMan == null)
            {
                return NotFound();
            }

            return View(salesMan);
        }

        // POST: SalesMen/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var salesMan = await _context.SalesMan.FindAsync(id);
            _context.SalesMan.Remove(salesMan);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool SalesManExists(int id)
        {
            return _context.SalesMan.Any(e => e.SalesManId == id);
        }
    }
}
