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
    public class AudioController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AudioController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Audio
        public async Task<IActionResult> Index()
        {
            return View(await _context.Audios.ToListAsync());
        }

        // GET: Audio/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Audios == null)
            {
                return NotFound();
            }

            var Audio = await _context.Audios
                .FirstOrDefaultAsync(m => m.AudioID == id);
            if (Audio == null)
            {
                return NotFound();
            }

            return View(Audio);
        }

        // GET: Audio/Create
        public IActionResult AddorEdit(int id = 0)
        {
            var AudioTypes = new List<string>() { "ትምህርት", "ስብከት", "የቸብችቦ መዝሙር", "የበገና መዝሙር", "የንስሃ መዝሙር", "ትረካ", "ጭውውት", "የተለያዩ ድምፆች" };
            ViewBag.AudioType = AudioTypes;
            if (id == 0)
                return View(new Audio());
            else
                return View(_context.Audios.Find(id));

        }

        // POST: Audio/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddorEdit([Bind("AudioID,AudioTitle,AudioType,AudioFor,AudioDate,AudioMonth,AudioYear,AudioBy,Path")] Audio Audio)
        {
            if (ModelState.IsValid)
            {
                if (Audio.AudioID == 0)
                    _context.Add(Audio);
                else
                    _context.Update(Audio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            var AudioTypes = new List<string>() { "ትምህርት", "ስብከት", "የቸብችቦ መዝሙር", "የበገና መዝሙር", "የንስሃ መዝሙር", "ትረካ", "ጭውውት", "የተለያዩ ድምፆች" };
            ViewBag.AudioType = AudioTypes;
            return View(Audio);
        }



        // GET: Audio/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Audios == null)
            {
                return NotFound();
            }

            var Audio = await _context.Audios
                .FirstOrDefaultAsync(m => m.AudioID == id);
            if (Audio == null)
            {
                return NotFound();
            }

            return View(Audio);
        }

        // POST: Audio/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Audios == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Audios'  is null.");
            }
            var Audio = await _context.Audios.FindAsync(id);
            if (Audio != null)
            {
                _context.Audios.Remove(Audio);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AudioExists(int id)
        {
            return _context.Audios.Any(e => e.AudioID == id);
        }
    }
}