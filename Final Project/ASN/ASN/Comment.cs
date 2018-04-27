using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASN
{
    /// <summary>
    /// A serializable class representing a comment on a Post.
    /// </summary>
    [Serializable]
    public class Comment : Post
    {
        /// <summary>
        /// Constructs a new Comment object.
        /// </summary>
        /// <param name="userID">The ID of the commenter.</param>
        /// <param name="message">The comment message.</param>
        /// <param name="commentID">The new comment ID.</param>
        public Comment(int userID, string message, int commentID) : base(userID, message, commentID)
        {
            PostID = commentID;
        }
    }
}
