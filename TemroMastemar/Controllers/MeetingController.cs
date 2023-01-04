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
    public class MeetingController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public MeetingController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context; 
            this._hostEnvironment = hostEnvironment;
        }

        // GET: Meeting
        public async Task<IActionResult> Index()
        {
            var applicationDbContext = _context.Meetings.Include(m => m.member);
            return View(await applicationDbContext.ToListAsync());
        }

        // GET: Meeting/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Meetings == null)
            {
                return NotFound();
            }

            var meeting = await _context.Meetings
                .Include(m => m.member)
                .FirstOrDefaultAsync(m => m.MeetingID == id);
            if (meeting == null)
            {
                return NotFound();
            }

            return View(meeting);
        }

        // GET: Meeting/Create
        public IActionResult AddorEdit(int id = 0)
        {
            ViewData["MemberID"] = new SelectList(_context.Members, "MemberID", "FullName");
            if (id == 0)
                return View(new Meeting());
            else
                return View(_context.Meetings.Find(id));

        }

        // POST: Meeting/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddorEdit([Bind("MeetingID,MeetingFile,MeetingAgenda,MemberID,MeetingPlace,MeetingHour,MeetingDate,MeetingMonth,MeetingYear,Physical_Document,Document")] Meeting meeting)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;
                if (meeting.MeetingID == 0)
                {
                    if (meeting.MeetingFile != null)
                    {
                        string fileName = Path.GetFileNameWithoutExtension(meeting.MeetingFile.FileName);
                        string extension = Path.GetExtension(meeting.MeetingFile.FileName);
                        fileName = meeting.MeetingAgenda + DateTime.Now.ToString("yymmddssff") + extension;
                        string path = Path.Combine(wwwRootPath + "/Meeting", fileName);
                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            await meeting.MeetingFile.CopyToAsync(fileStream);
                        }
                        meeting.Document = fileName;
                    }
                    _context.Add(meeting);
                }
                else
                {
                    if (meeting.MeetingFile != null && meeting.Document != null)
                    {
                        DeleteFile(meeting.Document);
                        string fileName = Path.GetFileNameWithoutExtension(meeting.MeetingFile.FileName);
                        string extension = Path.GetExtension(meeting.MeetingFile.FileName);
                        fileName = meeting.MeetingAgenda + DateTime.Now.ToString("yymmddssff") + extension;
                        string path = Path.Combine(wwwRootPath + "/Meeting", fileName);
                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            await meeting.MeetingFile.CopyToAsync(fileStream);
                        }
                        meeting.Document = fileName;
                    }
                    _context.Update(meeting);
                }
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            ViewData["MemberID"] = new SelectList(_context.Members, "MemberID", "FullName", meeting.MemberID);
            return View(meeting);
        }



        // GET: Meeting/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Meetings == null)
            {
                return NotFound();
            }

            var meeting = await _context.Meetings
                .Include(m => m.member)
                .FirstOrDefaultAsync(m => m.MeetingID == id);
            if (meeting == null)
            {
                return NotFound();
            }

            return View(meeting);
        }

        // POST: Meeting/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Meetings == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Meetings'  is null.");
            }
            var meeting = await _context.Meetings.FindAsync(id);
            if (meeting != null)
            {
                _context.Meetings.Remove(meeting);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MeetingExists(int id)
        {
          return _context.Meetings.Any(e => e.MeetingID == id);
        }
        public void DeleteFile(string MeetName)
        {
            var path = Path.Combine(_hostEnvironment.WebRootPath, "Meeting", MeetName);
            if (System.IO.File.Exists(path))
                System.IO.File.Delete(path);
        }

    }
}
