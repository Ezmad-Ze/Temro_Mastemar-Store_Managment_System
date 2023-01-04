using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TemroMastemar.Data;
using TemroMastemar.Models;

namespace TemroMastemar.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ApplicationDbContext _context;

        public HomeController(ILogger<HomeController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            var mem = _context.Members;
            var lit = _context.Literatures;
            int MaleCount = 0, SingleCount = 0, MarriedCount = 0,isAlive = 0;    

            foreach (var member in mem)
            {
                if(member.Gender == "ወንድ" || member.Gender == "ወ")
                {
                    MaleCount++;
                }
                if (member.Marital_Status == "ያገባ")
                {
                    MarriedCount++;
                }
                if (member.Marital_Status == "ያላገባ")
                {
                    SingleCount++;
                }
                if(member.IsAlive == "አሉ")
                {
                    isAlive++;
                }
            }

            int poem = 0, drama =0, tiwiwk = 0, menebanb = 0, senper = 0, tarik = 0, tireka = 0, tibebe = 0;
            foreach(var literature in lit)
            {
                if (literature.LiteratureType == "ግጥም")
                {
                    poem++;
                }
                if (literature.LiteratureType == "ድራማ")
                {
                    drama++;
                }
                if (literature.LiteratureType == "ትውውቅ ሥልት")
                {
                    tiwiwk++;
                }
                if (literature.LiteratureType == "መነባንብ")
                {
                    menebanb++;
                }
                if (literature.LiteratureType == "ሰንፔር")
                {
                    senper++;
                }
                if (literature.LiteratureType == "ታሪክ")
                {
                    tarik++;
                }
                if (literature.LiteratureType == "ትረካ")
                {
                    tireka++;
                }
                if (literature.LiteratureType == "ጥበበ ክህሎት")
                {
                    tibebe++;
                }
            }

            var MemberCount = mem.Count();
            ViewBag.MemberCount = MemberCount.ToString();
            ViewBag.MaleCount = MaleCount.ToString();
            int FemaleCount = MemberCount - MaleCount;
            ViewBag.FemaleCount = FemaleCount.ToString();
            ViewBag.SingleCount = SingleCount.ToString();
            ViewBag.MarriedCount = MarriedCount.ToString();
            ViewBag.IsAlive = isAlive.ToString();

            var LiteratureCount = lit.Count();
            ViewBag.LiteratureCount = LiteratureCount.ToString();
            ViewBag.Poem = poem.ToString();
            ViewBag.Drama = drama.ToString();
            ViewBag.Tiwiwk = tiwiwk.ToString();
            ViewBag.Menebanb = menebanb.ToString();
            ViewBag.Senper = senper.ToString();
            ViewBag.Tarik = tarik.ToString();
            ViewBag.Tireka = tireka.ToString();
            ViewBag.Tibebe = tibebe.ToString();



            return View();
        }
        [Authorize]
        public IActionResult Literature_Home()
        {
            return View();
        }
        [Authorize]
        public IActionResult Other_Docs_Home()
        {
            return View();
        }
        [Authorize]
        public IActionResult Audio_and_Video()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}