using App.BL.Comments;
using System.Linq;
using System.Text;

namespace App.BL.Comments.CommentInterfaces
{
    public interface ICommentStoreWrapper
    {
        public void AddCommentToThread(Comment comment);
    }
}
