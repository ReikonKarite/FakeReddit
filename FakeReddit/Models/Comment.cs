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
        public int Title { get; set; }
        public int Content { get; set; }

        public Post Post { get; set; }
        public int PostID { get; set; }
    }
}