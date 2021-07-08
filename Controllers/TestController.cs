using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using CorporateQualitySolution.Models.DB;

namespace CorporateQualitySolution.Controllers
{
    public class TestController : Controller
    {
        private readonly QualityManagementContext _context;

        public TestController(QualityManagementContext context)
        {
            _context = context;
        }

        // GET: Test
        public async Task<IActionResult> Index()
        {
            return View(await _context.TblBusinessUnitMasters.ToListAsync());
        }

        // GET: Test/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblBusinessUnitMaster = await _context.TblBusinessUnitMasters
                .FirstOrDefaultAsync(m => m.BusinessUnitId == id);
            if (tblBusinessUnitMaster == null)
            {
                return NotFound();
            }

            return View(tblBusinessUnitMaster);
        }

        // GET: Test/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Test/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BusinessUnitId,BusinessUnitName,BusinessUnitShortName,Status,UpdatedBy,UpdatedDate")] TblBusinessUnitMaster tblBusinessUnitMaster)
        {
            if (ModelState.IsValid)
            {
                tblBusinessUnitMaster.BusinessUnitId = Guid.NewGuid();
                _context.Add(tblBusinessUnitMaster);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tblBusinessUnitMaster);
        }

        // GET: Test/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblBusinessUnitMaster = await _context.TblBusinessUnitMasters.FindAsync(id);
            if (tblBusinessUnitMaster == null)
            {
                return NotFound();
            }
            return View(tblBusinessUnitMaster);
        }

        // POST: Test/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("BusinessUnitId,BusinessUnitName,BusinessUnitShortName,Status,UpdatedBy,UpdatedDate")] TblBusinessUnitMaster tblBusinessUnitMaster)
        {
            if (id != tblBusinessUnitMaster.BusinessUnitId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tblBusinessUnitMaster);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TblBusinessUnitMasterExists(tblBusinessUnitMaster.BusinessUnitId))
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
            return View(tblBusinessUnitMaster);
        }

        // GET: Test/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tblBusinessUnitMaster = await _context.TblBusinessUnitMasters
                .FirstOrDefaultAsync(m => m.BusinessUnitId == id);
            if (tblBusinessUnitMaster == null)
            {
                return NotFound();
            }

            return View(tblBusinessUnitMaster);
        }

        // POST: Test/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var tblBusinessUnitMaster = await _context.TblBusinessUnitMasters.FindAsync(id);
            _context.TblBusinessUnitMasters.Remove(tblBusinessUnitMaster);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TblBusinessUnitMasterExists(Guid id)
        {
            return _context.TblBusinessUnitMasters.Any(e => e.BusinessUnitId == id);
        }
    }
}
