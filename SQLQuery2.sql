SELECT Comments.Title CommentTitle, comments.Content CommentContent, AspNetUsers.UserName, Posts.Title, Posts.Content
FROM Comments
INNER JOIN Posts on posts.Id = comments.PostID
INNER JOIN AspNetUsers on AspNetUsers.Id = comments.ApplicationUser_Id
WHERE PostID = {0}
ORDER BY comments.id DESC