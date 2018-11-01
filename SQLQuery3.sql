SELECT Comments.Title CommentTitle, comments.Content CommentContent, AspNetUsers.UserName, Posts.Title PostTitle, Posts.Content PostContent 
FROM Posts 
LEFT JOIN Comments on posts.Id = comments.PostID 
left JOIN AspNetUsers on AspNetUsers.Id = comments.ApplicationUser_Id 
WHERE Posts.Id = {0}
ORDER BY comments.id DESC


select * from Comments where PostID = 2