SELECT Isnull(Sum(votetype), 0)    VoteCount, 
       Count(DISTINCT comments.id) AS ComCount, 
       CASE 
         WHEN Voted.id = {1} THEN votetype 
         ELSE 0 
       END                         AS Voted, 
       posts.title, 
       posts.content, 
       posts.id                    PostID, 
       subreddits.title            SubTitle, 
       aspnetusers.username, 
       subreddits.id               SubID 
FROM   uservotes 
       RIGHT JOIN posts 
               ON posts.id = uservotes.postid 
       INNER JOIN aspnetusers 
               ON aspnetusers.id = posts.applicationuser_id 
       INNER JOIN subreddits 
               ON subreddits.id = posts.subredditid 
       LEFT JOIN comments 
              ON comments.postid = posts.id 
       LEFT JOIN aspnetusers Voted 
              ON uservotes.applicationuser_id = Voted.id 
WHERE  subreddits.title = {0}
GROUP  BY posts.id, 
          posts.title, 
          posts.content, 
          posts.id, 
          subreddits.title, 
          aspnetusers.username, 
          subreddits.id, 
          CASE 
         WHEN Voted.id = {1} THEN votetype 
            ELSE 0 
          END 
ORDER  BY Isnull(Sum(votetype), 0) DESC 


select * from UserVotes