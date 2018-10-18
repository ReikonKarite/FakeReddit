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

        public List<Post> Posts { get; set; }
        public List<Subreddit> Subreddits{ get; set; }
        public List<User> Users { get; set; }
        public List<ApplicationUser> ApplicationUser { get; set; }
        public List<UserVote> UserVotes { get; set; }

        public string Title { get; set; } //posts
        public string Content { get; set; } //posts

        //public string SubredditTitle { get; set; }//subreddit





    }
}