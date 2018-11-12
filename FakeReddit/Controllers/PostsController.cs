using FakeReddit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using FakeReddit.ViewModels;
using Microsoft.AspNet.Identity;
using System.Net;

namespace FakeReddit.Controllers
{
    public class PostsController : Controller
    {
        private ApplicationDbContext _context;


        public PostsController()
        {
           _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }


        public string GetVoteCount (int Id)
        {
            var result = new UserVotesController().CalculateVotes(Id);
            return result;
        }


        [HttpPost]
                [ValidateInput(false)]
        public ActionResult Save(Post Post)
        {
            Post.Content = WebUtility.HtmlDecode(Post.Content);

            if (Post.Id == 0)
            {
                _context.Posts.Add(Post);
            }

            if (User.Identity.GetUserId() != null)
            {

                _context.SaveChanges();
                return Redirect("/r/gaming");
            }
            else
            {
                return Content("not logged in");
            }
        }

        public ActionResult New(int Id)
        {
            //pass in id of subreddit and add new post to subreddit.
            Post model = new Post();

            model.SubRedditID = Id;
            model.ApplicationUser_Id = User.Identity.GetUserId();
            model.CreatedDate = DateTime.Now;


            return View("NewPost", model);
        }
        // GET: Posts
        public ActionResult Index(string subReddit)
        {

           // var posts = _context.Posts
           //                     .Where(b=>b.SubReddit.Title == subReddit)
           //                     .Include(b => b.SubReddit)
           //                     .Include(b=>b.ApplicationUser)
           //                     .ToList();
           //
           //// //var posts = _context.Posts.Include(c => c.SubReddit).SingleOrDefault(c => c.Title == subReddit);
           //// //var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
           //// //var query = from e in Employee
           //// //            join d in Dept on e.deptno equals d.deptno
           //// //            select new { e.deptno, d.deptno };
           //// //linq query to join posts and subreddits and retrieve the posts.
           //// var query = (from e in _context.Posts
           ////              join d in _context.Subreddits on e.SubRedditID equals d.Id
           ////              where d.Title == subReddit
           ////              select new
           ////              {
           ////                  e.Title,
           ////                  e.Content
           ////              }
           ////                         ).AsEnumerable().Select(e => new Post
           ////                         {
           ////
           ////                             Title = e.Title.ToString(),
           ////                             Content = e.Content.ToString()
           ////                         }).ToList();
           ////
           ////
           // var myviewmodel = new SubRedditPostsViewModel()
           // {
           //     Posts = posts.ToList()
           // };

            //var players = _context.Database
            //        .SqlQuery<SubRedditPostsViewModel>("select * from posts inner join Subreddits on posts.SubRedditID = Subreddits.Id inner join Users on users.Id = posts.UserID where Subreddits.Title = 'gaming'")
            //        .ToList<SubRedditPostsViewModel>();
            var players = _context.Database
                                    .SqlQuery<SubRedditPostsViewModel>("SELECT Isnull(Sum(votetype), 0) VoteCount, Count(DISTINCT comments.id) AS ComCount, CASE WHEN Voted.id = {1} THEN votetype ELSE 0 END AS Voted, posts.title, posts.content, posts.id PostID, subreddits.title SubTitle, aspnetusers.username, subreddits.id SubID FROM uservotes RIGHT JOIN posts ON posts.id = uservotes.postid INNER JOIN aspnetusers ON aspnetusers.id = posts.applicationuser_id INNER JOIN subreddits ON subreddits.id = posts.subredditid LEFT JOIN comments ON comments.postid = posts.id LEFT JOIN aspnetusers Voted ON uservotes.applicationuser_id = Voted.id WHERE subreddits.title = {0} GROUP BY posts.id, posts.title, posts.content, posts.id, subreddits.title, aspnetusers.username, subreddits.id, CASE WHEN Voted.id = {1} THEN votetype ELSE 0 END ORDER BY Isnull(Sum(votetype), 0) DESC ", subReddit, User.Identity.GetUserId())
                                    .ToList<SubRedditPostsViewModel>();

            var SubId = _context.Subreddits.FirstOrDefault(s => s.Title == subReddit);


            ViewBag.Title = subReddit.ToString();
            ViewBag.SubId = SubId.Id.ToString();
            return View(players);
        }
    }
}