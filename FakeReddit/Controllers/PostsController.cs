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

        // GET: Posts
        public ActionResult Index(string subReddit)
        {

            var posts = _context.Posts.Include(c => c.SubReddit).SingleOrDefault(c => c.Title == subReddit);
            //var customer = _context.Customers.Include(c => c.MembershipType).SingleOrDefault(c => c.Id == id);
            //var query = from e in Employee
            //            join d in Dept on e.deptno equals d.deptno
            //            select new { e.deptno, d.deptno };

            var query = (from e in _context.Posts
                         join d in _context.Subreddits on e.SubRedditID equals d.Id
                         where d.Title == subReddit
                         select new
                         {
                             e.Title,
                             e.Content
                         }
                                    ).AsEnumerable().Select(e => new Post
                                    {

                                        Title = e.Title.ToString(),
                                        Content = e.Content.ToString()
                                    }).ToList();


            var myviewmodel = new SubRedditPostsViewModel()
            {
                Posts = query.ToList()
            };
            



            return View(myviewmodel);
        }
    }
}