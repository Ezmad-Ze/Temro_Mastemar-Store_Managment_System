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
    public class Children_LiteratureController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;


        public Children_LiteratureController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }

        // GET: Children_Literature
        public async Task<IActionResult> Index()
        {
              return View(await _context.C_Literatures.ToListAsync());
        }

        // GET: Children_Literature/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.C_Literatures == null)
            {
                return NotFound();
            }

            var children_Literature = await _context.C_Literatures
                .FirstOrDefaultAsync(m => m.C_LiteratureID == id);
            if (children_Literature == null)
            {
                return NotFound();
            }

            return View(children_Literature);
        }

        // GET: Children_Literature/Create
        public IActionResult AddorEdit(int id = 0)
        {
            var LiteratureTypes = new List<string>() { "ግጥም", "ድራማ", "ትውውቅ ሥልት", "መነባንብ", "ጥበበ ክህሎት", "ትረካ", "ታሪክ", "ተረቶች", "ሠዕሎች" };
            ViewBag.LiteratureType = LiteratureTypes;
            if (id == 0)
                return View(new Children_Literature());
            else
                return View(_context.C_Literatures.Find(id));
        }

        // POST: Children_Literature/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddorEdit([Bind("C_LiteratureID,LiteratureFile,C_LiteratureTitle,C_LiteratureType,C_LiteratureFor,WrittenMonth,WrittenYear,C_Author,C_Physical_Document,Document")] Children_Literature children_Literature)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                if (children_Literature.C_LiteratureID == 0)
                {
                    if (children_Literature.LiteratureFile != null)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(children_Literature.LiteratureFile.FileName);
                        string extension = Path.GetExtension(children_Literature.LiteratureFile.FileName);
                        fileName = children_Literature.C_LiteratureTitle + DateTime.Now.ToString("yymmddssff") + extension;
                        string path = Path.Combine(wwwRootPath + "/Children_Literature", fileName);
                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            await children_Literature.LiteratureFile.CopyToAsync(fileStream);
                        }
                        children_Literature.Document = fileName;
                    }

                    _context.Add(children_Literature);
                }
                else
                {
                    if (children_Literature.LiteratureFile != null && children_Literature.Document != null)
                    {
                        DeleteFile(children_Literature.Document);
                        string fileName = Path.GetFileNameWithoutExtension(children_Literature.LiteratureFile.FileName);
                        string extension = Path.GetExtension(children_Literature.LiteratureFile.FileName);
                        fileName = children_Literature.C_LiteratureTitle + DateTime.Now.ToString("yymmddssff") + extension;
                        string path = Path.Combine(wwwRootPath + "/Children_Literature", fileName);
                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            await children_Literature.LiteratureFile.CopyToAsync(fileStream);
                        }
                        children_Literature.Document = fileName;
                    }
                    _context.Update(children_Literature);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            var LiteratureTypes = new List<string>() { "ግጥም", "ድራማ", "ትውውቅ ሥልት", "መነባንብ", "ጥበበ ክህሎት", "ትረካ", "ታሪክ", "ሰንፔር" };
            ViewBag.LiteratureType = LiteratureTypes;
            return View(children_Literature);
        }


        // GET: Children_Literature/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.C_Literatures == null)
            {
                return NotFound();
            }

            var children_Literature = await _context.C_Literatures
                .FirstOrDefaultAsync(m => m.C_LiteratureID == id);
            if (children_Literature == null)
            {
                return NotFound();
            }

            return View(children_Literature);
        }

        // POST: Children_Literature/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.C_Literatures == null)
            {
                return Problem("Entity set 'ApplicationDbContext.C_Literatures'  is null.");
            }
            var children_Literature = await _context.C_Literatures.FindAsync(id);
            if (children_Literature != null)
            {
                _context.C_Literatures.Remove(children_Literature);
            }
            DeleteFile(children_Literature.Document);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool Children_LiteratureExists(int id)
        {
          return _context.C_Literatures.Any(e => e.C_LiteratureID == id);
        }
        public void DeleteFile(string LitName)
        {
            var path = Path.Combine(_hostEnvironment.WebRootPath, "Children_Literature", LitName);
            if (System.IO.File.Exists(path))
                System.IO.File.Delete(path);
        }
    }
}
