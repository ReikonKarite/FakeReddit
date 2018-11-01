using FakeReddit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FakeReddit.ViewModels;

namespace FakeReddit.Controllers
{
    public class CommentsController : Controller
    {
        private ApplicationDbContext _context;


        public CommentsController()
        {
            _context = new ApplicationDbContext();
        }

        protected override void Dispose(bool disposing)
        {
            _context.Dispose();
        }
        // GET: Comments
        public ActionResult Index()
        {


            return View();
        }

        public ActionResult GetComment(int ID, string PostTitle,string PostContent)
        {
            //get comments using postID

            var CommentsResult = _context.Comments.
                                                Select(v => new { v.PostID, v.ApplicationUser_Id, v.Content, v.Id })
                                                .Where(b => b.PostID == ID).ToList();

            var players = _context.Database
                        .SqlQuery<VMComments>("SELECT Comments.Title CommentTitle, comments.Content CommentContent, AspNetUsers.UserName " +
                        "FROM Posts " +
                        "INNER JOIN Comments on posts.Id = comments.PostID " +
                        "INNER JOIN AspNetUsers on AspNetUsers.Id = comments.ApplicationUser_Id " +
                        "WHERE Posts.Id = {0} " +
                        "ORDER BY comments.id DESC", ID)
                        .ToList<VMComments>();

            ViewBag.PostTitle = PostTitle;
            ViewBag.PostContent = PostContent;

            return View("Comment", players);
        }
    }
}