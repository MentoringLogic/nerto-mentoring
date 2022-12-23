using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.BL
{
    public interface ICommentStoreWrapper
    {
        public void AddCommentToThread(Comment comment);
    }

    public class CommentStoreWrapper : ICommentStoreWrapper
    {
        public void AddCommentToThread(Comment comment)
        {
            CommentStore.AddCommentToThread(comment);
        }
    }
}
