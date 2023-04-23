using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using EntityFrameworkLabb1.Data;
using EntityFrameworkLabb1.Models.Domain;

namespace EntityFrameworkLabb1.Controllers
{
    public class VacationListsController : Controller
    {
        private readonly VacationDbContext _context;

        public VacationListsController(VacationDbContext context)
        {
            _context = context;
        }

        // GET: VacationList
        public async Task<IActionResult> Index()
        {
            var vacationDbContext = _context.VacationLists.Include(x => x.Employees).Include(x => x.Vacations);
            return View(await vacationDbContext.ToListAsync());
        }

        // GET: Vacations/SearchVacation
        public async Task<IActionResult> SearchVacation()
        {
            var vacationDbContext = _context.VacationLists.Include(x => x.Employees);
            return View(await vacationDbContext.ToListAsync());
        }

        // Post: Vacations/ViewSearchResults
        public async Task<IActionResult> ViewSearchResults(string SearchVacation)
        {
            var vacationDbContext = _context.VacationLists.Include(x => x.Employees);
            return View("Index", await vacationDbContext.Where(x => x.Employees.LastName.Contains(SearchVacation)).ToListAsync());
        }

        // GET: Vacations/Admin
        public async Task<IActionResult> Admin()
        {
            var vacationDbContext = _context.VacationLists.Include(v => v.Vacations);
            return View(await vacationDbContext.ToListAsync());
        }

        // Post: Vacations/AdminViewResults
        public async Task<IActionResult> AdminViewResults(DateTime Start, DateTime Stop)
        {
            var vacationDbContext = _context.VacationLists.Include(x => x.Vacations);
            return View("Index", await vacationDbContext.Where(x => x.StartDate > Start && x.EndDate < Stop).ToListAsync());
        }

        // GET: VacationLists/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.VacationLists == null)
            {
                return NotFound();
            }

            var vacationList = await _context.VacationLists
                .Include(v => v.Employees)
                .Include(v => v.Vacations)
                .FirstOrDefaultAsync(m => m.VacationListId == id);
            if (vacationList == null)
            {
                return NotFound();
            }

            return View(vacationList);
        }

        // GET: VacationLists/Create
        public IActionResult Create()
        {
            ViewData["FK_Id"] = new SelectList(_context.Employees, "Id", "FirstName", "LastName");
            ViewData["FK_VacationId"] = new SelectList(_context.Vacations, "VacationId", "VacationType");
            return View();
        }

        // POST: VacationLists/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("VacationListId,StartDate,EndDate,AskDate,FK_Id,FK_VacationId")] VacationList vacationList)
        {

            if (ModelState.IsValid)
            {
                _context.Add(vacationList);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["FK_Id"] = new SelectList(_context.Employees, "Id", "FirstName", vacationList.FK_Id);
            ViewData["FK_VacationId"] = new SelectList(_context.Vacations, "VacationId", "VacationId", vacationList.FK_VacationId);
            return View(vacationList);
        }

        // GET: VacationLists/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.VacationLists == null)
            {
                return NotFound();
            }

            var vacationList = await _context.VacationLists.FindAsync(id);
            if (vacationList == null)
            {
                return NotFound();
            }
            ViewData["FK_Id"] = new SelectList(_context.Employees, "Id", "FirstName", vacationList.FK_Id);
            ViewData["FK_VacationId"] = new SelectList(_context.Vacations, "VacationId", "VacationId", vacationList.FK_VacationId);
            return View(vacationList);
        }

        // POST: VacationLists/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("VacationListId,StartDate,EndDate,AskDate,FK_Id,FK_VacationId")] VacationList vacationList)
        {
            if (id != vacationList.VacationListId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(vacationList);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!VacationListExists(vacationList.VacationListId))
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
            ViewData["FK_Id"] = new SelectList(_context.Employees, "Id", "FirstName", vacationList.FK_Id);
            ViewData["FK_VacationId"] = new SelectList(_context.Vacations, "VacationId", "VacationId", vacationList.FK_VacationId);
            return View(vacationList);
        }

        // GET: VacationLists/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.VacationLists == null)
            {
                return NotFound();
            }

            var vacationList = await _context.VacationLists
                .Include(v => v.Employees)
                .Include(v => v.Vacations)
                .FirstOrDefaultAsync(m => m.VacationListId == id);
            if (vacationList == null)
            {
                return NotFound();
            }

            return View(vacationList);
        }

        // POST: VacationLists/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.VacationLists == null)
            {
                return Problem("Entity set 'VacationDbContext.VacationLists'  is null.");
            }
            var vacationList = await _context.VacationLists.FindAsync(id);
            if (vacationList != null)
            {
                _context.VacationLists.Remove(vacationList);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VacationListExists(int id)
        {
          return (_context.VacationLists?.Any(e => e.VacationListId == id)).GetValueOrDefault();
        }
    }
}
