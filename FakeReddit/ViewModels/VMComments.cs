using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FakeReddit.Models;

namespace FakeReddit.ViewModels
{
    public class VMComments
    {
        public string CommentTitle { get; set; }
        public string CommentContent { get; set; }
        public int PostID { get; set; }

       public IEnumerable<Comment> Comments{ get; set; }
       public IEnumerable<ApplicationUser> Users { get; set; }

        public IEnumerable<CommentUsers> ComUsers { get; set; }


    }
}