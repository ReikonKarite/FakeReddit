select sum(VoteType) VoteCount, Posts.Title, Posts.Content, Posts.Id
from UserVotes
inner join posts on posts.Id = UserVotes.PostID
inner join AspNetUsers on AspNetUsers.Id = posts.ApplicationUser_Id
inner join Subreddits on Subreddits.Id = posts.SubRedditID
group by PostID,Posts.Title, Posts.Content, Posts.Id


select * 
from UserVotes
inner join posts on posts.Id = UserVotes.PostID
inner join AspNetUsers on AspNetUsers.Id = posts.ApplicationUser_Id
inner join Subreddits on Subreddits.Id = posts.SubRedditID

select sum(VoteType) VoteCount, Posts.Title, Posts.Content, Posts.Id
from UserVotes
inner join posts on posts.Id = UserVotes.PostID
inner join AspNetUsers on AspNetUsers.Id = posts.ApplicationUser_Id
inner join Subreddits on Subreddits.Id = posts.SubRedditID 
group by PostID, Posts.Title, Posts.Content, Posts.Id
