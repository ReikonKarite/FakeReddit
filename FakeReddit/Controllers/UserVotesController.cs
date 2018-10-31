using FakeReddit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FakeReddit.ViewModels;
using System.Data.Entity;
using Microsoft.AspNet.Identity;

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

        public ActionResult AddVote(int id, int type)
        {
            //Upvotes a particular post
            //passs in PostID, VoteType(+1 or -1), Application UserID, 

            UserVote model = new UserVote();

            var s = User.Identity.GetUserId();
            if (s != null)
            {
                //check to see if record exists
                var voteTot = _context.UserVotes.
                                                    Select(v => new { v.PostID, v.ApplicationUser_Id, v.VoteType, v.Id })
                                                    .Where(b => b.PostID == id && b.ApplicationUser_Id == s).SingleOrDefault();

                // if record doesnt exist at all insert it
                if (voteTot is null)
                {
                    model.PostID = id;
                    model.ApplicationUser_Id = User.Identity.GetUserId();
                    model.VoteType = type;

                    _context.UserVotes.Add(model);
                    _context.SaveChanges();
                }
                else if (voteTot != null && voteTot.VoteType != type)
                {
                    //grab record from database to make edit
                    var voteRecinDB = _context.UserVotes.Single(c => c.Id == voteTot.Id);

                    //model.PostID = voteTot.PostID;
                    //model.ApplicationUser_Id = User.Identity.GetUserId();
                    //model.Id = voteTot.Id;
                    //model.VoteType = type;
                    //update votetype here

                    //edit record 
                    voteRecinDB.VoteType = type;
                    //save record
                    _context.SaveChanges();
                }




                //TODO: change to dynamic subreddit location
                return Redirect("/r/gaming");
            }

            return Content("No User logged in.");

         
        }
    }
}