using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FakeReddit.Models;

namespace FakeReddit.Models
{
    public class Comment
    {
        public int Id { get; set; }
        public String Title { get; set; }
        public String Content { get; set; }

        public Post Post { get; set; }
        public int PostID { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
        public string ApplicationUser_Id { get; set; }
    }
}