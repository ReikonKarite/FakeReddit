using FakeReddit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FakeReddit.ViewModels;
using Microsoft.AspNet.Identity;
using System.Data.Entity;


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

        public ActionResult Save(VMComments vm)
        {
            Comment comment =new Comment();

            //Comment comment = new Comment();
            if (vm.CommentID !=0)
            {
                comment = _context.Comments.FirstOrDefault(s => s.Id == vm.CommentID);
            }



            comment.Content = vm.CommentContent;
            comment.PostID = vm.PostID;
            comment.Id = vm.CommentID;
            comment.ApplicationUser_Id = User.Identity.GetUserId();

            if (vm.CommentID ==0)
            { 
            _context.Comments.Add(comment);
            }

            _context.SaveChanges();

            return RedirectToAction("GetComment", new {ID = vm.PostID });
        }

        public ActionResult Edit(int PostID, int ComID)
        {
            //create viewmodel, query database and populate CLICKED comment inside edit box.

            Comment comment = _context.Comments.Find(ComID);

            VMComments vm = new VMComments();
            //CommentUsers CU = new CommentUsers();

            //var poo = _context.Comments.Include(c => c.ApplicationUser).Where(b=>b.PostID == ID).ToList();


            //grabs data from database and populates a commentUsers viewmodel
            var poo2 = from se in _context.Comments
                       join ew in _context.Users on se.ApplicationUser_Id equals ew.Id
                       where se.PostID == PostID
                       select new CommentUsers
                       {
                           Comments = se.Content,
                           UserName = ew.UserName,
                           CommentID = se.Id,
                           PostID = se.PostID
                       };

            // vm.ComUsers = poo2.ToList();

            var Model = new VMComments
            {
                ComUsers = poo2,
                PostID = PostID,
                CommentContent = comment.Content,
                CommentID = ComID


            };



            //grab post details as well to show.

            //
            //if (comment == null || comment.ApplicationUser_Id != User.Identity.GetUserId())
            //{
            //    return HttpNotFound();
            //}
            return View("Comment", Model);



        }



        public ActionResult GetComment(int ID)
        {
            //get comments using postID

            VMComments vm = new VMComments();
            //CommentUsers CU = new CommentUsers();
            
            //var poo = _context.Comments.Include(c => c.ApplicationUser).Where(b=>b.PostID == ID).ToList();
            

            //grabs data from database and populates a commentUsers viewmodel
            var poo2 = from se in _context.Comments
                       join ew in _context.Users on se.ApplicationUser_Id equals ew.Id
                       where se.PostID == ID
                       select new CommentUsers
                       {
                           Comments = se.Content,
                           UserName = ew.UserName,
                           CommentID = se.Id,
                           PostID = se.PostID
                           
                           
                       };

           // vm.ComUsers = poo2.ToList();
           
            var Model = new VMComments
            {
                ComUsers = poo2,
                PostID = ID

            };


            //vm.Comments = _context.Comments.Where(b=>b.PostID == ID).ToList();
           //vm.Users = _context.Users.ToList();
           //vm.PostID == ID;
           //vm.Comments = _context.Comments.
            //                                    Select(v => new { v.PostID, v.ApplicationUser_Id, v.Content, v.Id })
            //                                    .Where(b => b.PostID == ID).ToList();

            //var players = _context.Database
            //           .SqlQuery<VMComments>("" +
            //           "SELECT Comments.Title CommentTitle, comments.Content CommentContent, AspNetUsers.UserName " +
            //           "FROM Posts " +
            //           "INNER JOIN Comments on posts.Id = comments.PostID " +
            //           "INNER JOIN AspNetUsers on AspNetUsers.Id = comments.ApplicationUser_Id " +
            //           "WHERE Posts.Id = {0} " +
            //           "ORDER BY comments.id DESC", ID)
            //           .ToList<VMComments>();

            //vm.ComUsers = players

            //vm.ComUsers = players;
            //var players = _context.Database
            //            .SqlQuery<VMComments>("" +
            //            "SELECT Comments.Title CommentTitle, comments.Content CommentContent, AspNetUsers.UserName " +
            //            "FROM Posts " +
            //            "INNER JOIN Comments on posts.Id = comments.PostID " +
            //            "INNER JOIN AspNetUsers on AspNetUsers.Id = comments.ApplicationUser_Id " +
            //            "WHERE Posts.Id = {0} " +
            //            "ORDER BY comments.id DESC", ID)
            //            .ToList<VMComments>();

            //retugn comment where post.id = ID




            //var SubId = _context.Subreddits.FirstOrDefault(s => s.Title == subReddit);

            var Post = _context.Posts.FirstOrDefault(s => s.Id == ID);
            ViewBag.PostTitle = Post.Title;
            ViewBag.PostContent = Post.Content;

            return View("Comment", Model);
        }
    }
}