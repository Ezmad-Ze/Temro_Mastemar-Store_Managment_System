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
    public class FormsController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public FormsController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }

        // GET: Forms
        public async Task<IActionResult> Index()
        {
              return View(await _context.Forms.ToListAsync());
        }

        // GET: Forms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Forms == null)
            {
                return NotFound();
            }

            var form = await _context.Forms
                .FirstOrDefaultAsync(m => m.FormID == id);
            if (form == null)
            {
                return NotFound();
            }

            return View(form);
        }

        // GET: Forms/Create
        public IActionResult AddorEdit(int id = 0)
        {
            var writtenBy = new List<string>() { "የትምህርትና ስልጠና ሥራ አስፈፃሚ", "የመዝሙር ጸሎትና ኪነ ጥበብ ሥራ አስፈፃሚ", "የአባላትና የጉባኤያት ጉባኤ ሥራ አስፈፃሚ", "የሀብት አስተዳደር ሥራ አስፈፃሚ", "የልማትና ሙያ ማስፋፊያ ሥራ አስፈፃሚ", "የመረጃ ስርዓትና ግንኙነት ሥራ አስፈፃሚ", "የበጎ አድራጎትና ተራድኦ ሥራ አስፈፃሚ", "ጠቅላላ ሥራ አስፈፃሚ" };
            ViewBag.writtenBy = writtenBy;
            if (id == 0)
                return View(new Form());
            else
                return View(_context.Forms.Find(id));
        }

        // POST: Forms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddorEdit([Bind("FormID,FormTitle,FormDate,FormMonth,FormYear,FormBy,Physical_Document,Document,FormFile")] Form form)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                if (form.FormID == 0)
                {
                    if (form.FormFile != null)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(form.FormFile.FileName);
                        string extension = Path.GetExtension(form.FormFile.FileName);
                        fileName = form.FormTitle + DateTime.Now.ToString("yymmddssff") + extension;
                        string path = Path.Combine(wwwRootPath + "/Form", fileName);
                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            await form.FormFile.CopyToAsync(fileStream);
                        }
                        form.Document = fileName;
                    }

                    _context.Add(form);
                }
                else
                {
                    if (form.FormFile != null && form.Document != null)
                    {
                        DeleteFile(form.Document);
                        string fileName = Path.GetFileNameWithoutExtension(form.FormFile.FileName);
                        string extension = Path.GetExtension(form.FormFile.FileName);
                        fileName = form.FormTitle + DateTime.Now.ToString("yymmddssff") + extension;
                        string path = Path.Combine(wwwRootPath + "/Form", fileName);
                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            await form.FormFile.CopyToAsync(fileStream);
                        }
                        form.Document = fileName;
                    }
                    _context.Update(form);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            var writtenBy = new List<string>() { "የትምህርትና ስልጠና ሥራ አስፈፃሚ", "የመዝሙር ጸሎትና ኪነ ጥበብ ሥራ አስፈፃሚ", "የአባላትና የጉባኤያት ጉባኤ ሥራ አስፈፃሚ", "የሀብት አስተዳደር ሥራ አስፈፃሚ", "የልማትና ሙያ ማስፋፊያ ሥራ አስፈፃሚ", "የመረጃ ስርዓትና ግንኙነት ሥራ አስፈፃሚ", "የበጎ አድራጎትና ተራድኦ ሥራ አስፈፃሚ", "ጠቅላላ ሥራ አስፈፃሚ" };
            ViewBag.writtenBy = writtenBy;
            return View(form);
        }

        // GET: Forms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Forms == null)
            {
                return NotFound();
            }

            var form = await _context.Forms
                .FirstOrDefaultAsync(m => m.FormID == id);
            if (form == null)
            {
                return NotFound();
            }

            return View(form);
        }

        // POST: Forms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Forms == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Forms'  is null.");
            }
            var form = await _context.Forms.FindAsync(id);
            if (form != null)
            {
                _context.Forms.Remove(form);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FormExists(int id)
        {
          return _context.Forms.Any(e => e.FormID == id);
        }
        public void DeleteFile(string LitName)
        {
            var path = Path.Combine(_hostEnvironment.WebRootPath, "Form", LitName);
            if (System.IO.File.Exists(path))
                System.IO.File.Delete(path);
        }
    }
}
