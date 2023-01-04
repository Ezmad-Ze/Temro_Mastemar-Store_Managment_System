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
    public class VideoController : Controller
    {
        private readonly ApplicationDbContext _context;

        public VideoController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Video
        public async Task<IActionResult> Index()
        {
            return View(await _context.Videos.ToListAsync());
        }

        // GET: Video/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Videos == null)
            {
                return NotFound();
            }

            var video = await _context.Videos
                .FirstOrDefaultAsync(m => m.VideoID == id);
            if (video == null)
            {
                return NotFound();
            }

            return View(video);
        }

        // GET: Video/Create
        public IActionResult AddorEdit(int id = 0)
        {
            var VideoTypes = new List<string>() { "ትምህርት", "ስብከት", "የቸብችቦ መዝሙር", "የበገና መዝሙር", "የንስሃ መዝሙር", "ትረካ", "ጭውውት", "የበዓል ምስሎች", "የተለያዩ ምስሎች" };
            ViewBag.VideoType = VideoTypes;
            if (id == 0)
                return View(new Video());
            else
                return View(_context.Videos.Find(id));

        }

        // POST: Video/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddorEdit([Bind("VideoID,VideoTitle,VideoType,VideoFor,VideoDate,VideoMonth,VideoYear,VideoBy,Path")] Video video)
        {
            if (ModelState.IsValid)
            {
                if (video.VideoID == 0)
                    _context.Add(video);
                else
                    _context.Update(video);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }

            var VideoTypes = new List<string>() { "ትምህርት", "ስብከት", "የቸብችቦ መዝሙር", "የበገና መዝሙር", "የንስሃ መዝሙር", "ትረካ", "ጭውውት", "የበዓል ምስሎች", "የተለያዩ ምስሎች" };
            ViewBag.VideoType = VideoTypes;
            return View(video);
        }



        // GET: Video/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Videos == null)
            {
                return NotFound();
            }

            var video = await _context.Videos
                .FirstOrDefaultAsync(m => m.VideoID == id);
            if (video == null)
            {
                return NotFound();
            }

            return View(video);
        }

        // POST: Video/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Videos == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Videos'  is null.");
            }
            var video = await _context.Videos.FindAsync(id);
            if (video != null)
            {
                _context.Videos.Remove(video);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool VideoExists(int id)
        {
            return _context.Videos.Any(e => e.VideoID == id);
        }
    }
}
