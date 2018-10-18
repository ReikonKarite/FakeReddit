SELECT * FROM Posts
INNER JOIN Subreddits on Subreddits.Id = posts.SubRedditID
INNER JOIN users on users.Id = posts.UserID
where Subreddits.Title = 'gaming'