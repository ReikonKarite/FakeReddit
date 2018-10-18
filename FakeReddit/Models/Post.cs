using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using FakeReddit.Models;

namespace FakeReddit.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title {get; set;}
        public string Content { get; set; }



        public Subreddit SubReddit { get; set; }
        public int SubRedditID { get; set; }

        //public User User { get; set; }    
        //public int UserID { get; set; }

        //public string UserID { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }


    }
}