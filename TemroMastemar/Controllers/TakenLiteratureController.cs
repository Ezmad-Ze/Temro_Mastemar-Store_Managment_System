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
    public class TakenLiteratureController : Controller
    {
        private readonly ApplicationDbContext _context;

        public TakenLiteratureController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: TakenLiterature
        public async Task<IActionResult> Index()
        {
              return _context.TakenLiteratures != null ? 
                          View(await _context.TakenLiteratures.ToListAsync()) :
                          Problem("Entity set 'ApplicationDbContext.TakenLiteratures'  is null.");
        }

        // GET: TakenLiterature/Create
        public IActionResult AddorEdit(int id = 0)
        {
            //TODO: Add a radio button to check which type of litreture it is
            //Like "Tiliku gubae", "hitsannate kifile", "audio", "video", "ekid", "report" etc
            var LiteratureType = _context.Literatures.Select(lt => lt.LiteratureType).ToList();
            var C_LiteratureType = _context.C_Literatures.Select(lt => lt.C_LiteratureType).ToList();
            var Total_Lit_Type = C_LiteratureType.Union(LiteratureType);

            var LiteratureTitle = _context.Literatures.Select(lt => lt.LiteratureTitle).ToList();
            var C_LiteratureTitle = _context.C_Literatures.Select(lt => lt.C_LiteratureTitle).ToList();
            var Total_Lit_Title = C_LiteratureTitle.Union(LiteratureTitle);


            var GiverName = _context.Members.Select(gn => gn.NameAndGrFName);
            var TakerName = _context.Members.Select(gn => gn.NameAndGrFName);


            ViewBag.litType = new SelectList(Total_Lit_Type);
            ViewBag.litTitle = new SelectList(Total_Lit_Title);
            ViewBag.givName = new SelectList(GiverName);
            ViewBag.takName = new SelectList(TakerName);

            if (id == 0)
                return View(new TakenLiterature());
            else
                return View(_context.TakenLiteratures.Find(id));
        }

        // POST: TakenLiterature/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddorEdit([Bind("TakenLiteratureID,TL_Reason,TL_Title,TL_LiteratureType,Giver,Taker,TL_Time")] TakenLiterature takenLiterature)
        {
            if (ModelState.IsValid)
            {
                if(takenLiterature != null)
                {
                    _context.Add(takenLiterature);
                }
                else
                {
                    _context.Update(takenLiterature);
                }

                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            var LiteratureType = _context.Literatures.Select(lt => lt.LiteratureType).ToList();
            var C_LiteratureType = _context.C_Literatures.Select(lt => lt.C_LiteratureType).ToList();
            var Total_Lit_Type = C_LiteratureType.Union(LiteratureType);

            var LiteratureTitle = _context.Literatures.Select(lt => lt.LiteratureTitle).ToList();
            var C_LiteratureTitle = _context.C_Literatures.Select(lt => lt.C_LiteratureTitle).ToList();
            var Total_Lit_Title = C_LiteratureTitle.Union(LiteratureTitle);


            var GiverName = _context.Members.Select(gn => gn.NameAndGrFName);
            var TakerName = _context.Members.Select(gn => gn.NameAndGrFName);


            ViewBag.litType = new SelectList(Total_Lit_Type);
            ViewBag.litTitle = new SelectList(Total_Lit_Title);
            ViewBag.givName = new SelectList(GiverName);
            ViewBag.takName = new SelectList(TakerName);
            return View(takenLiterature);
        }
        // POST: TakenLiterature/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Admin")]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TakenLiteratures == null)
            {
                return Problem("Entity set 'ApplicationDbContext.TakenLiteratures'  is null.");
            }
            var takenLiterature =  await _context.TakenLiteratures.FindAsync(id);
            if (takenLiterature != null)
            {
                _context.TakenLiteratures.Remove(takenLiterature);
            }
            
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
//Made by Endeamlak. Z