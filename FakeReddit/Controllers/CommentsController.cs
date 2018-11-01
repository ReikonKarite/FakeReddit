﻿using FakeReddit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using FakeReddit.ViewModels;
using Microsoft.AspNet.Identity;

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

            Comment comment = new Comment();

            comment.Content = vm.CommentContent;
            comment.PostID = vm.PostID;
            comment.ApplicationUser_Id = User.Identity.GetUserId(); 


            _context.Comments.Add(comment);

            _context.SaveChanges();

            return RedirectToAction("GetComment", new {ID = vm.PostID });
        }

        public ActionResult GetComment(int ID)
        {
            //get comments using postID

            VMComments vm = new VMComments();

            vm.Comments = _context.Comments.Where(b=>b.PostID == ID).ToList();
            vm.Users = _context.Users.ToList();
            vm.PostID = ID;
           //vm.Comments = _context.Comments.
           //                                    Select(v => new { v.PostID, v.ApplicationUser_Id, v.Content, v.Id })
           //                                    .Where(b => b.PostID == ID).ToList();

            

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

            return View("Comment", vm);
        }
    }
}