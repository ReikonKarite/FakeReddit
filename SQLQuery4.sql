select * from Posts
select * from Subreddits
select * from Users


select * from posts
inner join Subreddits on posts.SubRedditID = Subreddits.Id
inner join Users on users.Id = posts.UserID
where Subreddits.Title = 'gaming'