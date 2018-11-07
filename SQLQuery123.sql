SELECT
   isnull(sum(VoteType), 0) VoteCount,
   isnull(count(comments.Id),0) ComCount,
   Posts.Title,
   Posts.Content,
   Posts.Id PostID,
   SubReddits.Title SubTitle,
   UserName,
   Subreddits.Id SubID 
FROM
   UserVotes 
   RIGHT JOIN
      posts 
      ON posts.Id = UserVotes.PostID 
   INNER JOIN
      AspNetUsers 
      ON AspNetUsers.Id = posts.ApplicationUser_Id 
   INNER JOIN
      Subreddits 
      ON Subreddits.Id = posts.SubRedditID 
	LEFT JOIN 
	Comments
	ON comments.PostID = posts.Id
WHERE
   subreddits.Title = {0}
GROUP BY
   Posts.Id,
   Posts.Title,
   Posts.Content,
   Posts.Id,
   SubReddits.Title,
   UserName,
   Subreddits.Id



   select * from Comments