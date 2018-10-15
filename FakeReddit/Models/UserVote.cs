using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FakeReddit.Models
{
    public class UserVote
    {
        public int Id { get; set; }

        public User User { get; set; }
        public int UserID { get; set; }


        public Post Post { get; set; }
        public int PostID { get; set; }

        //Upvote or downvote.
        public int VoteType { get; set; }
    }
}