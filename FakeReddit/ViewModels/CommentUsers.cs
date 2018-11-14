using FakeReddit.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FakeReddit.ViewModels
{
    public class CommentUsers
    {
        //public IEnumerable<Comment> Comments { get; set; }
        //public IEnumerable<ApplicationUser> Users { get; set; }

        public string Comments { get; set; }
        public string UserName { get; set; }
        public int CommentID { get; set; }
        public int PostID { get; set; }
    }
}