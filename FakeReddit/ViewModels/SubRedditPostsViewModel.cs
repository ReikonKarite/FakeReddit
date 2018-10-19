using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FakeReddit.Models;

namespace FakeReddit.ViewModels
{
    public class SubRedditPostsViewModel
    {
        //public Post Post { get; set; }
        //public Subreddit Subreddit { get; set; }

        public int PostID { get; set; }
        public string Title { get; set; } //posts
        public string Content { get; set; } //posts
        public int VoteCount { get; set; } //upvotecount


        //public string SubredditTitle { get; set; }//subreddit





    }
}