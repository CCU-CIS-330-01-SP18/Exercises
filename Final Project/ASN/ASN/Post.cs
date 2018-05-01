using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASN
{
    /// <summary>
    /// A serializable class representing a Post.
    /// </summary>
    [Serializable]
    public class Post
    {
        /// <summary>
        /// The ID of the user who posted this Post.
        /// </summary>
        public int UserID { get; private set; }

        /// <summary>
        /// The message of this Post.
        /// </summary>
        public string PostMessage { get; private set; }

        /// <summary>
        /// A collection of comments about this Post.
        /// </summary>
        public List<Comment> Comments { get; set; }

        /// <summary>
        /// A number of "points" this Post has earned.
        /// </summary>
        public int Points { get; private set; }

        /// <summary>
        /// The ID of this Post.
        /// </summary>
        public int PostID { get; set; }

        /// <summary>
        /// The date, time, and timezone offset this Post was made.
        /// </summary>
        public DateTime Posted { get; set; }

        /// <summary>
        /// Constructs a new Post event.
        /// </summary>
        /// <param name="userID">The User ID of the poster.</param>
        /// <param name="message">The message of the post.</param>
        /// <param name="postID">The new post ID.</param>
        public Post(int userID, string message, int postID)
        {
            UserID = userID;
            PostID = postID;
            PostMessage = message;
            Posted = DateTime.Now;
            Comments = new List<Comment>();
        }

        /// <summary>
        /// Adds a comment to this post.
        /// </summary>
        /// <param name="userID">The ID of the commenter.</param>
        /// <param name="message">The text of the comment.</param>
        /// <returns>A new Comment object.</returns>
        public Comment AddComment(int userID, string message)
        {
            var comment = new Comment(userID, message, GetNextCommentID());
            Comments.Add(comment);

            return comment;
        }

        /// <summary>
        /// Adds a point to this Post and deducts one from the user.
        /// </summary>
        /// <param name="from">The User object giving the point.</param>
        public void AddPoint(User from)
        {
            Points += 1;
            from.Points -= 1;
        }

        /// <summary>
        /// Gets a comment object based on its ID.
        /// </summary>
        /// <param name="id">The comment ID.</param>
        /// <returns>The Comment object if found; otherwise, returns null.</returns>
        public Comment GetCommentByID(int id)
        {
            foreach(var item in Comments)
            {
                if(item.PostID == id)
                {
                    return item;
                }
            }

            return null;
        }

        /// <summary>
        /// Gets the next ID for a comment in the sequence.
        /// </summary>
        /// <returns>An integer for the new comment's ID.</returns>
        private int GetNextCommentID()
        {
            int id = 0;

            foreach (var c in Comments)
            {
                if (c.PostID >= id)
                {
                    id = c.PostID + 1;
                }
            }

            return id;
        }
    }
}
