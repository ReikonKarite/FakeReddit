USE [aspnet-FakeReddit-20181012113906]
GO

/****** Object: SqlProcedure [dbo].[GetPostForSubreddit] Script Date: 17/10/2018 16:01:17 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

ALTER PROCEDURE [dbo].[GetPostForSubreddit]
	@Subreddit nvarchar(max)
AS
SELECT * 
FROM Posts 
INNER JOIN Subreddits on Subreddits.Id = posts.SubRedditID 
INNER JOIN users ON users.Id = posts.UserID 
WHERE Subreddits.Title= @Subreddit
