using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using WebRevamp.Data;
using WebRevamp.Models;

namespace WebRevamp.Controllers
{
    public class ApprovalsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public ApprovalsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Approvals
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Approvals.Include(a => a.Approver).Include(a => a.VacationRequest);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Approvals/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Approvals == null)
            {
                return NotFound();
            }

            var approval = await _context.Approvals
                .Include(a => a.Approver)
                .Include(a => a.VacationRequest)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (approval == null)
            {
                return NotFound();
            }

            return View(approval);
        }

        // GET: Approvals/Create
        public IActionResult Create()
        {
            ViewData["ApproverId"] = new SelectList(_context.Employees, "Id", "Id");
            ViewData["VacationRequestId"] = new SelectList(_context.VacationRequests, "Id", "Id");
            return View();
        }

        // POST: Approvals/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,VacationRequestId,ApproverId,ApprovalDate")] Approval approval)
        {
            if (ModelState.IsValid)
            {
                _context.Add(approval);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["ApproverId"] = new SelectList(_context.Employees, "Id", "Id", approval.ApproverId);
            ViewData["VacationRequestId"] = new SelectList(_context.VacationRequests, "Id", "Id", approval.VacationRequestId);
            return View(approval);
        }

        // GET: Approvals/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.Approvals == null)
            {
                return NotFound();
            }

            var approval = await _context.Approvals.FindAsync(id);
            if (approval == null)
            {
                return NotFound();
            }
            ViewData["ApproverId"] = new SelectList(_context.Employees, "Id", "Id", approval.ApproverId);
            ViewData["VacationRequestId"] = new SelectList(_context.VacationRequests, "Id", "Id", approval.VacationRequestId);
            return View(approval);
        }

        // POST: Approvals/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,VacationRequestId,ApproverId,ApprovalDate")] Approval approval)
        {
            if (id != approval.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(approval);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ApprovalExists(approval.Id))
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
            ViewData["ApproverId"] = new SelectList(_context.Employees, "Id", "Id", approval.ApproverId);
            ViewData["VacationRequestId"] = new SelectList(_context.VacationRequests, "Id", "Id", approval.VacationRequestId);
            return View(approval);
        }

        // GET: Approvals/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Approvals == null)
            {
                return NotFound();
            }

            var approval = await _context.Approvals
                .Include(a => a.Approver)
                .Include(a => a.VacationRequest)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (approval == null)
            {
                return NotFound();
            }

            return View(approval);
        }

        // POST: Approvals/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Approvals == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Approvals'  is null.");
            }
            var approval = await _context.Approvals.FindAsync(id);
            if (approval != null)
            {
                _context.Approvals.Remove(approval);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ApprovalExists(int id)
        {
          return _context.Approvals.Any(e => e.Id == id);
        }
    }
}
