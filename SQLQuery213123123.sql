SELECT 
   isnull(sum(VoteType), 0) VoteCount,  
   count (DISTINCT Comments.Id) AS ComCount,
   case when Voted.Id is not null then VoteType else 0 end As Voted,
   Posts.Title,  
   Posts.Content,  
   Posts.Id PostID,  
   SubReddits.Title SubTitle,  
   AspNetUsers.UserName,  
   Subreddits.Id SubID
FROM  
   UserVotes  
   RIGHT JOIN posts ON posts.Id = UserVotes.PostID  
   INNER JOIN AspNetUsers ON AspNetUsers.Id = posts.ApplicationUser_Id  
   INNER JOIN Subreddits ON Subreddits.Id = posts.SubRedditID  
   LEFT JOIN Comments ON comments.PostID = posts.Id  
   left join AspNetUsers Voted on UserVotes.ApplicationUser_Id = Voted.Id
WHERE  
   subreddits.Title = 'gaming'
GROUP BY  
   Posts.Id,  
   Posts.Title,  
   Posts.Content,  
   Posts.Id,  
   SubReddits.Title,  
   AspNetUsers.UserName,  
   Subreddits.Id,
   case when Voted.Id is not null then VoteType else 0 end
ORDER BY  
isnull(sum(VoteType), 0) DESC



select * from UserVotes
where ApplicationUser_Id = 'f80420eb-b463-4560-865e-3fdb35af0d6c'

select * from Comments
where ApplicationUser_Id = 'f80420eb-b463-4560-865e-3fdb35af0d6c'


select * from comments where PostID = 1014
select * from Posts where id = 1014
select * from UserVotes where PostID = 1014


SELECT * FROM Posts
select * from Comments

select posts.id, count(comments.Id) 
from Posts
inner join comments on comments.PostID = posts.Id
group by posts.Id



SELECT * FROM UserVotes  
SELECT * FROM posts 
SELECT * FROM AspNetUsers 
SELECT * FROM Subreddits
SELECT * FROM Comments where PostID = 1027


SELECT * 
FROM posts
INNER JOIN Subreddits on posts.SubRedditID = Subreddits.Id
left JOIN Comments on comments.PostID = posts.Id
INNER JOIN UserVotes on UserVotes.PostID = posts.Id
order by Posts.Title