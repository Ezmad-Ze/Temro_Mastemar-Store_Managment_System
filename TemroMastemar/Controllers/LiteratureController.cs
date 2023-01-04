using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using TemroMastemar.Data;
using TemroMastemar.Models;

namespace TemroMastemar.Controllers
{
    [Authorize]
    public class LiteratureController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public LiteratureController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }

        // GET: Literature
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Literatures.Include(l => l.member);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Literature/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Literatures == null)
            {
                return NotFound();
            }

            var literature = await _context.Literatures
                .Include(l => l.member)
                .FirstOrDefaultAsync(m => m.LiteratureID == id);
            if (literature == null)
            {
                return NotFound();
            }

            return View(literature);
        }

        // GET: Literature/Create
        public IActionResult AddorEdit(int id = 0)
        {
            ViewData["MemberID"] = new SelectList(_context.Members, "MemberID", "NameAndGrFName");
            var LiteratureTypes = new List<string>() { "ግጥም", "ድራማ", "ቴያትር" ,"ትውውቅ ሥልት", "መነባንብ", "ጥበበ ክህሎት", "ትረካ", "ታሪክ", "ሰንፔር", "መፅሄት እና ጋዜጣ", "በራሪ ፅሁፎች" };
            ViewBag.LiteratureType = LiteratureTypes;
            if (id == 0)
                return View(new Literature());
            else
                return View(_context.Literatures.Find(id));

        }

        // POST: Literature/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddorEdit([Bind("LiteratureID,LiteratureFile,Document,LiteratureTitle,LiteratureType,LiteratureFor,WrittenMonth,WrittenYear,Physical_Document,MemberID,member")] Literature literature)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                if (literature.LiteratureID == 0)
                {
                    if(literature.LiteratureFile != null)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(literature.LiteratureFile.FileName);
                        string extension = Path.GetExtension(literature.LiteratureFile.FileName);
                        fileName = literature.LiteratureTitle + DateTime.Now.ToString("yymmddssff") + extension;
                        string path = Path.Combine(wwwRootPath + "/Literature", fileName);
                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            await literature.LiteratureFile.CopyToAsync(fileStream);
                        }
                        literature.Document = fileName;
                    }

                    _context.Add(literature);
                }
                else
                {
                    if (literature.LiteratureFile != null && literature.Document != null)
                    {
                        DeleteFile(literature.Document);
                        string fileName = Path.GetFileNameWithoutExtension(literature.LiteratureFile.FileName);
                        string extension = Path.GetExtension(literature.LiteratureFile.FileName);
                        fileName = literature.LiteratureTitle + DateTime.Now.ToString("yymmddssff") + extension;
                        string path = Path.Combine(wwwRootPath + "/Literature", fileName);
                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            await literature.LiteratureFile.CopyToAsync(fileStream);
                        }
                        literature.Document = fileName;
                    }
                    _context.Update(literature);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MemberID"] = new SelectList(_context.Members, "MemberID", "NameAndGrFName", literature.MemberID);
            var LiteratureTypes = new List<string>() { "ግጥም", "ድራማ", "ትውውቅ ሥልት", "መነባንብ", "ጥበበ ክህሎት", "ትረካ", "ታሪክ", "ሰንፔር" };
            ViewBag.LiteratureType = LiteratureTypes;
            return View(literature);
        }


        // GET: Literature/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Literatures == null)
            {
                return NotFound();
            }

            var literature = await _context.Literatures
                .Include(l => l.member)
                .FirstOrDefaultAsync(m => m.LiteratureID == id);
            if (literature == null)
            {
                return NotFound();
            }

            return View(literature);
        }

        // POST: Literature/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Literatures == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Literatures'  is null.");
            }
            var literature = await _context.Literatures.FindAsync(id);
            if (literature != null)
            {
                _context.Literatures.Remove(literature);
            }
            DeleteFile(literature.Document);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool LiteratureExists(int id)
        {
            return (_context.Literatures?.Any(e => e.LiteratureID == id)).GetValueOrDefault();
        }

        public void DeleteFile(string LitName)
        {
            var path = Path.Combine(_hostEnvironment.WebRootPath, "Literature", LitName);
            if (System.IO.File.Exists(path))
                System.IO.File.Delete(path);
        }

    }
}
//Made by Endeamlak. Z