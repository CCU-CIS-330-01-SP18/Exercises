using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ASN
{
    [Serializable]
    public class Comment : Post
    {
        public Comment(int userID, string message, int commentID) : base(userID, message, commentID)
        {
            PostID = commentID;
        }
    }
}
