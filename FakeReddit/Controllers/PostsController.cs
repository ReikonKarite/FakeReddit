using FakeReddit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data.Entity;
using FakeReddit.ViewModels;

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
                                    .SqlQuery<SubRedditPostsViewModel>("select sum(VoteType) VoteCount, Posts.Title, Posts.Content, Posts.Id, SubReddits.Title SubTitle, UserName from UserVotes inner join posts on posts.Id = UserVotes.PostID inner join AspNetUsers on AspNetUsers.Id = posts.ApplicationUser_Id inner join Subreddits on Subreddits.Id = posts.SubRedditID where subreddits.Title = {0} group by PostID, Posts.Title, Posts.Content, Posts.Id, SubReddits.Title, UserName",subReddit)
                                    .ToList<SubRedditPostsViewModel>();

            return View(players);
        }
    }
}