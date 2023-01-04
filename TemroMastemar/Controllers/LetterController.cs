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
    public class LetterController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public LetterController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }

        // GET: Letter
        public async Task<IActionResult> Index()
        {
              return View(await _context.Letters.ToListAsync());
        }

        // GET: Letter/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Letters == null)
            {
                return NotFound();
            }

            var letter = await _context.Letters
                .FirstOrDefaultAsync(m => m.LetterID == id);
            if (letter == null)
            {
                return NotFound();
            }

            return View(letter);
        }

        // GET: Letter/Create
        public IActionResult AddorEdit(int id = 0)
        {
            if (id == 0)
                return View(new Letter());
            else
                return View(_context.Letters.Find(id));
        }

        // POST: Letter/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddorEdit([Bind("LetterID,LetterTitle,LetterType,S_LetterDate,S_LetterMonth,S_LetterYear,From,To,Physical_Document,Document,File")] Letter letter)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                if (letter.LetterID == 0)
                {
                    if (letter.File != null)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(letter.File.FileName);
                        string extension = Path.GetExtension(letter.File.FileName);
                        fileName = letter.LetterTitle + DateTime.Now.ToString("yymmddssff") + extension;
                        string path = Path.Combine(wwwRootPath + "/Letter", fileName);
                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            await letter.File.CopyToAsync(fileStream);
                        }
                        letter.Document = fileName;
                    }

                    _context.Add(letter);
                }
                else
                {
                    if (letter.File != null && letter.Document != null)
                    {
                        DeleteFile(letter.Document);
                        string fileName = Path.GetFileNameWithoutExtension(letter.File.FileName);
                        string extension = Path.GetExtension(letter.File.FileName);
                        fileName = letter.LetterTitle + DateTime.Now.ToString("yymmddssff") + extension;
                        string path = Path.Combine(wwwRootPath + "/Letter", fileName);
                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            await letter.File.CopyToAsync(fileStream);
                        }
                        letter.Document = fileName;
                    }
                    _context.Update(letter);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(letter);
        }


        // GET: Letter/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Letters == null)
            {
                return NotFound();
            }

            var letter = await _context.Letters
                .FirstOrDefaultAsync(m => m.LetterID == id);
            if (letter == null)
            {
                return NotFound();
            }

            return View(letter);
        }

        // POST: Letter/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Letters == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Letters'  is null.");
            }
            var letter = await _context.Letters.FindAsync(id);
            if (letter != null)
            {
                _context.Letters.Remove(letter);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LetterExists(int id)
        {
          return _context.Letters.Any(e => e.LetterID == id);
        }
        public void DeleteFile(string LitName)
        {
            var path = Path.Combine(_hostEnvironment.WebRootPath, "Letter", LitName);
            if (System.IO.File.Exists(path))
                System.IO.File.Delete(path);
        }
    }
}
