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
    public class MemberController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly IWebHostEnvironment _hostEnvironment;

        public MemberController(ApplicationDbContext context, IWebHostEnvironment hostEnvironment)
        {
            _context = context;
            this._hostEnvironment = hostEnvironment;
        }


        // GET: Member
        public async Task<IActionResult> Index()
        {
            return _context.Members != null ?
                        View(await _context.Members.ToListAsync()) :
                        Problem("Entity set 'ApplicationDbContext.Members'  is null.");
        }

        // GET: Member/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.Members == null)
            {
                return NotFound();
            }

            var member = await _context.Members
                .FirstOrDefaultAsync(m => m.MemberID == id);
            if (member == null)
            {
                return NotFound();
            }

            return View(member);
        }

        // GET: Member/Create
        public IActionResult AddorEdit(int id = 0)
        {
            var subcity = new List<string>() { "አዲስ ከተማ", "አቃቂ ቃሊቲ", "አራዳ", "ቦሌ", "ጉለሌ", "ቂርቆስ", "ኮልፌ ቀራንዮ", "ልደታ", "ንፋስ ስልክ ላፍቶ", "የካ", "ለሚ ኩራ" };
            ViewBag.subcity = subcity;
            var committee = new List<string>() { "የትምህርትና ስልጠና ሥራ አስፈፃሚ", "የመዝሙር ጸሎትና ኪነ ጥበብ ሥራ አስፈፃሚ", "የአባላትና የጉባኤያት ጉባኤ ሥራ አስፈፃሚ", "የሀብት አስተዳደር ሥራ አስፈፃሚ", "የልማትና ሙያ ማስፋፊያ ሥራ አስፈፃሚ", "የመረጃ ስርዓትና ግንኙነት ሥራ አስፈፃሚ", "የበጎ አድራጎትና ተራድኦ ሥራ አስፈፃሚ" };
            ViewBag.committee = committee;
            if (id == 0)
                return View(new Member());
            else
                return View(_context.Members.Find(id));
        }

        // POST: Member/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddorEdit([Bind("MemberID,ImageFile,Image,Name,Father_Name,GrandFather_Name,Mother_Name,Gender,Nationality,Babtisal_Name,DateofBirth,MonthofBirth,YearofBirth,PlaceofBirth,Marital_Status,Sub_City,Woreda,House_Number,Phone_Number,Education_Status,Education_Field,WorkingIn,Organization_Name,Current_Committee,Committe_Choice,YearofMembership,EmergencyContactName,EC_Relation,EC_Sub_City,EC_Woreda,EC_House_Number,EC_Phone_Number,IsAlive")] Member member)
        {
            if (ModelState.IsValid)
            {
                string wwwRootPath = _hostEnvironment.WebRootPath;

                if (member.MemberID == 0)
                {
                    if (member.ImageFile == null || member.ImageFile.Length == 0)
                    {
                        member.Image = "TM.jpg";
                    }

                    else
                    {
                        string fileName = Path.GetFileNameWithoutExtension(member.ImageFile.FileName);
                        string extension = Path.GetExtension(member.ImageFile.FileName);
                        fileName = member.FullName + DateTime.Now.ToString("yymmddssff") + extension;
                        string path = Path.Combine(wwwRootPath + "/Image", fileName);
                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            await member.ImageFile.CopyToAsync(fileStream);
                        }
                        member.Image = fileName;

                    }
                    _context.Add(member);
                }
                else
                {

                    if (member.ImageFile != null && member.Image != null)
                    {
                        DeleteImage(member.Image);
                        string fileName = Path.GetFileNameWithoutExtension(member.ImageFile.FileName);
                        string extension = Path.GetExtension(member.ImageFile.FileName);
                        fileName = member.FullName + DateTime.Now.ToString("yymmddssff") + extension;
                        string path = Path.Combine(wwwRootPath + "/Image", fileName);
                        using (var fileStream = new FileStream(path, FileMode.Create))
                        {
                            await member.ImageFile.CopyToAsync(fileStream);
                        }
                        member.Image = fileName;
                    }

                    _context.Update(member);
                }


                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }


            return View(member);
        }


        [Authorize(Roles = "Admin")]
        // GET: Member/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.Members == null)
            {
                return NotFound();
            }

            var member = await _context.Members
                .FirstOrDefaultAsync(m => m.MemberID == id);
            if (member == null)
            {
                return NotFound();
            }

            return View(member);
        }

        [Authorize(Roles = "Admin")]
        // POST: Member/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.Members == null)
            {
                return Problem("Entity set 'ApplicationDbContext.Members'  is null.");
            }
            var member = await _context.Members.FindAsync(id);
            if (member != null)
            {
                _context.Members.Remove(member);
            }
            DeleteImage(member.Image);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool MemberExists(int id)
        {
            return (_context.Members?.Any(e => e.MemberID == id)).GetValueOrDefault();
        }

        public void DeleteImage(string ImageName)
        {
            var path = Path.Combine(_hostEnvironment.WebRootPath, "Image", ImageName);
            if (System.IO.File.Exists(path) && ImageName != "TM.jpg")
                System.IO.File.Delete(path);
        }
    }
}
