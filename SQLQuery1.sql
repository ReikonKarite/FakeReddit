select sum(VoteType) VoteCount, Posts.Title, Posts.Content, Posts.Id, SubReddits.Title SubTitle, UserName
from UserVotes
inner join posts on posts.Id = UserVotes.PostID
inner join AspNetUsers on AspNetUsers.Id = posts.ApplicationUser_Id
inner join Subreddits on Subreddits.Id = posts.SubRedditID 
where subreddits.Title = {0}
group by PostID, Posts.Title, Posts.Content, Posts.Id, SubReddits.Title, UserName



select *
from UserVotes
inner join posts on posts.Id = UserVotes.PostID
inner join AspNetUsers on AspNetUsers.Id = posts.ApplicationUser_Id
inner join Subreddits on Subreddits.Id = posts.SubRedditID 
group by PostID, Posts.Title, Posts.Content, Posts.Id

