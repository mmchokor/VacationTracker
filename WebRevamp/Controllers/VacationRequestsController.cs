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
    public class VacationRequestsController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VacationRequestsController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: VacationRequests
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.VacationRequests.Include(v => v.Employee).Include(v => v.HODApprover).Include(v => v.OpsApprover);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: VacationRequests/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.VacationRequests == null)
            {
                return NotFound();
            }

            var vacationRequest = await _context.VacationRequests
                .Include(v => v.Employee)
                .Include(v => v.HODApprover)
                .Include(v => v.OpsApprover)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vacationRequest == null)
            {
                return NotFound();
            }

            return View(vacationRequest);
        }

        // GET: VacationRequests/Create
        public IActionResult Create()
        {
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Id");
            ViewData["HODApproverId"] = new SelectList(_context.Employees, "Id", "Id");
            ViewData["OpsApproverId"] = new SelectList(_context.Employees, "Id", "Id");
            return View();
        }

        // POST: VacationRequests/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,EmployeeId,StartDate,EndDate,Status,HODApprovalStatus,HODApproverId,OpsApprovalStatus,OpsApproverId")] VacationRequest vacationRequest)
        {
            if (ModelState.IsValid)
            {
                _context.Add(vacationRequest);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Id", vacationRequest.EmployeeId);
            ViewData["HODApproverId"] = new SelectList(_context.Employees, "Id", "Id", vacationRequest.HODApproverId);
            ViewData["OpsApproverId"] = new SelectList(_context.Employees, "Id", "Id", vacationRequest.OpsApproverId);
            return View(vacationRequest);
        }

        // GET: VacationRequests/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.VacationRequests == null)
            {
                return NotFound();
            }

            var vacationRequest = await _context.VacationRequests.FindAsync(id);
            if (vacationRequest == null)
            {
                return NotFound();
            }
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Id", vacationRequest.EmployeeId);
            ViewData["HODApproverId"] = new SelectList(_context.Employees, "Id", "Id", vacationRequest.HODApproverId);
            ViewData["OpsApproverId"] = new SelectList(_context.Employees, "Id", "Id", vacationRequest.OpsApproverId);
            return View(vacationRequest);
        }

        // POST: VacationRequests/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,EmployeeId,StartDate,EndDate,Status,HODApprovalStatus,HODApproverId,OpsApprovalStatus,OpsApproverId")] VacationRequest vacationRequest)
        {
            if (id != vacationRequest.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vacationRequest);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VacationRequestExists(vacationRequest.Id))
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
            ViewData["EmployeeId"] = new SelectList(_context.Employees, "Id", "Id", vacationRequest.EmployeeId);
            ViewData["HODApproverId"] = new SelectList(_context.Employees, "Id", "Id", vacationRequest.HODApproverId);
            ViewData["OpsApproverId"] = new SelectList(_context.Employees, "Id", "Id", vacationRequest.OpsApproverId);
            return View(vacationRequest);
        }

        // GET: VacationRequests/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.VacationRequests == null)
            {
                return NotFound();
            }

            var vacationRequest = await _context.VacationRequests
                .Include(v => v.Employee)
                .Include(v => v.HODApprover)
                .Include(v => v.OpsApprover)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (vacationRequest == null)
            {
                return NotFound();
            }

            return View(vacationRequest);
        }

        // POST: VacationRequests/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.VacationRequests == null)
            {
                return Problem("Entity set 'ApplicationDbContext.VacationRequests'  is null.");
            }
            var vacationRequest = await _context.VacationRequests.FindAsync(id);
            if (vacationRequest != null)
            {
                _context.VacationRequests.Remove(vacationRequest);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VacationRequestExists(int id)
        {
          return _context.VacationRequests.Any(e => e.Id == id);
        }
    }
}
