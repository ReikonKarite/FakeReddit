using FakeReddit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FakeReddit.ViewModels;
using System.Data.Entity;

namespace FakeReddit.Controllers
{
    public class UserVotesController : Controller
    {
        private ApplicationDbContext _context;


        public UserVotesController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }



        // GET: UserVotes
        public ActionResult Index()
        {
            return View();
        }

        public string CalculateVotes(int ID)
        {

            //var posts = _context.Posts
            //                    .Where(b => b.SubReddit.Title == subReddit)
            //                    .Include(b => b.SubReddit)
            //                    .Include(b => b.ApplicationUser)
            //                    .ToList();


            //var VoteTot = _context.UserVotes
            //                        .Where(b=> b.Post.SubReddit.Title == SubReddit)
            //                        .Include(b=> b.Post)
            //                        .Include(b=> b.ApplicationUser)

            var voteTot = _context.UserVotes.GroupBy(e => e.PostID)
                                                //.Select(v => new { PostID = v.Key, Count = v.Count(), total=v.Sum(b=>b.VoteType) })
                                                .Select(v => new { PostID = v.Key, total = v.Sum(b => b.VoteType) })
                                                .Where(b=>b.PostID == ID).Single();
                                                
            return voteTot.total.ToString();
        }
    }
}