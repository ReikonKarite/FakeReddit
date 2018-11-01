SELECT Comments.Title CommentTitle, comments.Content CommentContent, AspNetUsers.UserName
FROM Comments
INNER JOIN Posts on posts.Id = comments.PostID
INNER JOIN AspNetUsers on AspNetUsers.Id = comments.ApplicationUser_Id
WHERE PostID = 1
ORDER BY comments.id DESC