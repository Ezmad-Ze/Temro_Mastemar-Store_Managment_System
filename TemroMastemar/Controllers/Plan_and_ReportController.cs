using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TemroMastemar.Data;
using TemroMastemar.Models;

namespace TemroMastemar.Controllers
{
    public class Plan_and_ReportController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;


        public Plan_and_ReportController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }

        // GET: Plan_and_Report
        public async Task<IActionResult> Index()
        {
              return View(await _context.Plan_and_Report.ToListAsync());
        }

        // GET: Plan_and_Report/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Plan_and_Report == null)
            {
                return NotFound();
            }

            var plan_and_Report = await _context.Plan_and_Report
                .FirstOrDefaultAsync(m => m.ID == id);
            if (plan_and_Report == null)
            {
                return NotFound();
            }

            return View(plan_and_Report);
        }

        // GET: Plan_and_Report/Create
        public IActionResult AddorEdit(int id = 0)
        {
            var plan_or_reports = new List<string>() { "እቅድ","ዘገባ"};
            ViewBag.plan_or_reports = plan_or_reports;
            var types = new List<string>() { "3 ወር","6 ወር", "አመታዊ", "የጉዞ","የገቢ/ወጪ","የሒሳብ ምርመራ" };
            ViewBag.types = types;
            var writtenBy = new List<string>() { "የትምህርትና ስልጠና ሥራ አስፈፃሚ", "የመዝሙር ጸሎትና ኪነ ጥበብ ሥራ አስፈፃሚ", "የአባላትና የጉባኤያት ጉባኤ ሥራ አስፈፃሚ", "የሀብት አስተዳደር ሥራ አስፈፃሚ", "የልማትና ሙያ ማስፋፊያ ሥራ አስፈፃሚ", "የመረጃ ስርዓትና ግንኙነት ሥራ አስፈፃሚ", "የበጎ አድራጎትና ተራድኦ ሥራ አስፈፃሚ", "ጠቅላላ ሥራ አስፈፃሚ" };
            ViewBag.writtenBy = writtenBy;
            if (id == 0)
                return View(new Plan_and_Report());
            else
                return View(_context.Plan_and_Report.Find(id));
        }

        // POST: Plan_and_Report/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddorEdit([Bind("ID,Plan_or_Report,Title,Type,S_ReportDate,S_ReportMonth,S_ReportYear,E_ReportDate,E_ReportMonth,E_ReportYear,ReportBy,Physical_Document,Document,File")] Plan_and_Report plan_and_Report)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                if (plan_and_Report.ID == 0)
                {
                    if (plan_and_Report.File != null)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(plan_and_Report.File.FileName);
                        string extension = Path.GetExtension(plan_and_Report.File.FileName);
                        fileName = plan_and_Report.Title + DateTime.Now.ToString("yymmddssff") + extension;
                        string path = Path.Combine(wwwRootPath + "/Plan_and_Report", fileName);
                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            await plan_and_Report.File.CopyToAsync(fileStream);
                        }
                        plan_and_Report.Document = fileName;
                    }

                    _context.Add(plan_and_Report);
                }
                else
                {
                    if (plan_and_Report.File != null && plan_and_Report.Document != null)
                    {
                        DeleteFile(plan_and_Report.Document);
                        string fileName = Path.GetFileNameWithoutExtension(plan_and_Report.File.FileName);
                        string extension = Path.GetExtension(plan_and_Report.File.FileName);
                        fileName = plan_and_Report.Title + DateTime.Now.ToString("yymmddssff") + extension;
                        string path = Path.Combine(wwwRootPath + "/Plan_and_Report", fileName);
                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            await plan_and_Report.File.CopyToAsync(fileStream);
                        }
                        plan_and_Report.Document = fileName;
                    }
                    _context.Update(plan_and_Report);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            var plan_or_reports = new List<string>() { "እቅድ", "ዘገባ" };
            ViewBag.plan_or_reports = plan_or_reports;
            var types = new List<string>() { "3 ወር", "6 ወር", "አመታዊ", "የጉዞ", "የገቢ/ወጪ", "የሒሳብ ምርመራ" };
            ViewBag.types = types;
            var writtenBy = new List<string>() { "የትምህርትና ስልጠና ሥራ አስፈፃሚ", "የመዝሙር ጸሎትና ኪነ ጥበብ ሥራ አስፈፃሚ", "የአባላትና የጉባኤያት ጉባኤ ሥራ አስፈፃሚ", "የሀብት አስተዳደር ሥራ አስፈፃሚ", "የልማትና ሙያ ማስፋፊያ ሥራ አስፈፃሚ", "የመረጃ ስርዓትና ግንኙነት ሥራ አስፈፃሚ", "የበጎ አድራጎትና ተራድኦ ሥራ አስፈፃሚ" };
            ViewBag.writtenBy = writtenBy;
            return View(plan_and_Report);
        }


        // GET: Plan_and_Report/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Plan_and_Report == null)
            {
                return NotFound();
            }

            var plan_and_Report = await _context.Plan_and_Report
                .FirstOrDefaultAsync(m => m.ID == id);
            if (plan_and_Report == null)
            {
                return NotFound();
            }

            return View(plan_and_Report);
        }

        // POST: Plan_and_Report/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Plan_and_Report == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Plan_and_Report'  is null.");
            }
            var plan_and_Report = await _context.Plan_and_Report.FindAsync(id);
            if (plan_and_Report != null)
            {
                _context.Plan_and_Report.Remove(plan_and_Report);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Plan_and_ReportExists(int id)
        {
          return _context.Plan_and_Report.Any(e => e.ID == id);
        }
        public void DeleteFile(string LitName)
        {
            var path = Path.Combine(_hostEnvironment.WebRootPath, "Plan_and_Report", LitName);
            if (System.IO.File.Exists(path))
                System.IO.File.Delete(path);
        }
    }
}
