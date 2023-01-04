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
    public class RuleController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public RuleController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }

        // GET: Rule
        public async Task<IActionResult> Index()
        {
              return View(await _context.Rules.ToListAsync());
        }

        // GET: Rule/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Rules == null)
            {
                return NotFound();
            }

            var rule = await _context.Rules
                .FirstOrDefaultAsync(m => m.RuleID == id);
            if (rule == null)
            {
                return NotFound();
            }

            return View(rule);
        }

        // GET: Rule/Create
        public IActionResult AddorEdit(int id = 0)
        {
            var writtenBy = new List<string>() { "የትምህርትና ስልጠና ሥራ አስፈፃሚ", "የመዝሙር ጸሎትና ኪነ ጥበብ ሥራ አስፈፃሚ", "የአባላትና የጉባኤያት ጉባኤ ሥራ አስፈፃሚ", "የሀብት አስተዳደር ሥራ አስፈፃሚ", "የልማትና ሙያ ማስፋፊያ ሥራ አስፈፃሚ", "የመረጃ ስርዓትና ግንኙነት ሥራ አስፈፃሚ", "የበጎ አድራጎትና ተራድኦ ሥራ አስፈፃሚ", "ጠቅላላ ሥራ አስፈፃሚ" };
            ViewBag.writtenBy = writtenBy;
            if (id == 0)
                return View(new Rule());
            else
                return View(_context.Rules.Find(id));
        }

        // POST: Rule/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddorEdit([Bind("RuleID,RuleTitle,RuleDate,RuleMonth,RuleYear,RuleBy,Physical_Document,Document,RuleFile")] Rule rule)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                if (rule.RuleID == 0)
                {
                    if (rule.RuleFile != null)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(rule.RuleFile.FileName);
                        string extension = Path.GetExtension(rule.RuleFile.FileName);
                        fileName = rule.RuleTitle + DateTime.Now.ToString("yymmddssff") + extension;
                        string path = Path.Combine(wwwRootPath + "/Rule", fileName);
                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            await rule.RuleFile.CopyToAsync(fileStream);
                        }
                        rule.Document = fileName;
                    }

                    _context.Add(rule);
                }
                else
                {
                    if (rule.RuleFile != null && rule.Document != null)
                    {
                        DeleteFile(rule.Document);
                        string fileName = Path.GetFileNameWithoutExtension(rule.RuleFile.FileName);
                        string extension = Path.GetExtension(rule.RuleFile.FileName);
                        fileName = rule.RuleTitle + DateTime.Now.ToString("yymmddssff") + extension;
                        string path = Path.Combine(wwwRootPath + "/Rule", fileName);
                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            await rule.RuleFile.CopyToAsync(fileStream);
                        }
                        rule.Document = fileName;
                    }
                    _context.Update(rule);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            var writtenBy = new List<string>() { "የትምህርትና ስልጠና ሥራ አስፈፃሚ", "የመዝሙር ጸሎትና ኪነ ጥበብ ሥራ አስፈፃሚ", "የአባላትና የጉባኤያት ጉባኤ ሥራ አስፈፃሚ", "የሀብት አስተዳደር ሥራ አስፈፃሚ", "የልማትና ሙያ ማስፋፊያ ሥራ አስፈፃሚ", "የመረጃ ስርዓትና ግንኙነት ሥራ አስፈፃሚ", "የበጎ አድራጎትና ተራድኦ ሥራ አስፈፃሚ", "ጠቅላላ ሥራ አስፈፃሚ" };
            ViewBag.writtenBy = writtenBy;
            return View(rule);
        }

        // GET: Rule/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Rules == null)
            {
                return NotFound();
            }

            var rule = await _context.Rules
                .FirstOrDefaultAsync(m => m.RuleID == id);
            if (rule == null)
            {
                return NotFound();
            }

            return View(rule);
        }

        // POST: Rule/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Rules == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Rules'  is null.");
            }
            var rule = await _context.Rules.FindAsync(id);
            if (rule != null)
            {
                _context.Rules.Remove(rule);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RuleExists(int id)
        {
          return _context.Rules.Any(e => e.RuleID == id);
        }
        public void DeleteFile(string LitName)
        {
            var path = Path.Combine(_hostEnvironment.WebRootPath, "Rule", LitName);
            if (System.IO.File.Exists(path))
                System.IO.File.Delete(path);
        }
    }
}
