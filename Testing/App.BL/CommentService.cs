using System;

namespace App.BL
{
    public interface IMyDateTime
    {
        DateTime GetNow();
    }
    public class myDateTime : IMyDateTime
    {
        public DateTime GetNow() => DateTime.Now;
    }
    public class CommentService
    {
        private ICommentStoreWrapper _commentWrapper;
        private IThreadRepository _threadRepository;
        private IMyDateTime _myDateTime;
        public CommentService() : this(new CommentStoreWrapper(), new ThreadRepository(), new myDateTime())
        {
                
        }
        public CommentService(ICommentStoreWrapper commentWrapper, IThreadRepository threadRepository, IMyDateTime DateTime)
        {
            this._commentWrapper = commentWrapper; 
            this._threadRepository = threadRepository;
            this._myDateTime = DateTime;
        }

        public bool AddCommentToThread(string commentText, string authorName, Guid threadId)
        {
            if (string.IsNullOrEmpty(commentText))
            {
                throw new ArgumentException("Comment cannot be null or empty");
            }

            var thread = _threadRepository.GetById(threadId);  // It is going to load Substitute now

            if (thread == null)
            {
                return false;
            }

            var today = DateTime.Now;
            var timeSpan = today.Subtract(thread.Created);
            if (timeSpan.TotalMinutes > 70)
            {
                throw new ArgumentException("You cannot add comment to thread after 70 minutes of it creation");
            }

            if (thread.Resolved)
            {
                return false;
            }


            var comment = new Comment()
            {
                Id = Guid.NewGuid(),
                AuthorName = authorName,
                Created = DateTime.Now,
                Text = commentText,
                ThreadId = threadId,
                Index = ++thread.LastCommentIndex,
            };

            _commentWrapper.AddCommentToThread(comment);

            return true;
        }
    }
}