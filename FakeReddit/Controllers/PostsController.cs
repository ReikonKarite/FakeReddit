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
                                    .SqlQuery<SubRedditPostsViewModel>( "SELECT" +
                                                                        "   isnull(sum(VoteType), 0) VoteCount, " +
                                                                        "   isnull(count(Comments.Id), 0) ComCount, " +
                                                                        "   Posts.Title, " +
                                                                        "   Posts.Content, " +
                                                                        "   Posts.Id PostID, " +
                                                                        "   SubReddits.Title SubTitle, " +
                                                                        "   UserName, " +
                                                                        "   Subreddits.Id SubID " +
                                                                        "FROM " +
                                                                        "   UserVotes " +
                                                                        "   RIGHT JOIN " +
                                                                        "   posts " +
                                                                        "   ON posts.Id = UserVotes.PostID " +
                                                                        "   INNER JOIN " +
                                                                        "   AspNetUsers " +
                                                                        "   ON AspNetUsers.Id = posts.ApplicationUser_Id " +
                                                                        "   INNER JOIN " +
                                                                        "   Subreddits " +
                                                                        "   ON Subreddits.Id = posts.SubRedditID " +
                                                                        "   LEFT JOIN " +
                                                                        "   Comments " +
                                                                        "   ON comments.PostID = posts.Id " +
                                                                        "WHERE " +
                                                                        "   subreddits.Title = {0} " +
                                                                        "GROUP BY " +
                                                                        "   Posts.Id, " +
                                                                        "   Posts.Title, " +
                                                                        "   Posts.Content, " +
                                                                        "   Posts.Id, " +
                                                                        "   SubReddits.Title, " +
                                                                        "   UserName, " +
                                                                        "   Subreddits.Id " +
                                                                        "ORDER BY " +
                                                                        "isnull(sum(VoteType), 0) DESC", subReddit)
                                    .ToList<SubRedditPostsViewModel>();

            var SubId = _context.Subreddits.FirstOrDefault(s => s.Title == subReddit);


            ViewBag.Title = subReddit.ToString();
            ViewBag.SubId = SubId.Id.ToString();
            return View(players);
        }
    }
}