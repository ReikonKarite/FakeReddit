using FakeReddit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FakeReddit.Controllers
{
    public class SubredditsController : Controller
    {

        private ApplicationDbContext _context;

        public SubredditsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }

        // GET: Subreddits
        public ActionResult Index()
        {
            var AllSubreddits = _context.Subreddits.ToList();

            return View(AllSubreddits);
        }
    }
}