﻿SELECT * FROM Posts INNER JOIN Subreddits on Subreddits.Id = posts.SubRedditID INNER JOIN users ON users.Id = posts.UserID WHERE Subreddits.Title= 'gaming'