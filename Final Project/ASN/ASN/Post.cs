using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASN
{
    [Serializable]
    public class Post
    {
        public int UserID { get; private set; }

        public string PostMessage { get; private set; }

        public List<Comment> Comments { get; set; }

        public int Points { get; private set; }

        public int PostID { get; set; }

        public DateTime Posted { get; set; }

        public Post(int userID, string message, int postID)
        {
            UserID = userID;
            PostID = postID;
            PostMessage = message;
            Posted = DateTime.Now;
            Comments = new List<Comment>();
        }

        public Comment AddComment(int userID, string message)
        {
            var comment = new Comment(userID, message, GetNextCommentID());
            Comments.Add(comment);

            return comment;
        }

        public void AddPoint(User from)
        {
            Points += 1;
            from.Points -= 1;
        }

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
