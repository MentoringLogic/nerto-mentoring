using System;

namespace App.BL
{
    public class CommentService
    {
        private ICommentStoreWrapper _commentWrapper;
        private IGetById _getById;

        public void SetStrategy(ICommentStoreWrapper CommentWrapper, IGetById GetById)
        {
            _commentWrapper = CommentWrapper; 
            _getById = GetById;
        }

        public bool AddCommentToThread(string commentText, string authorName, Guid threadId)
        {
            if (string.IsNullOrEmpty(commentText))
            {
                throw new ArgumentException("Comment cannot be null or empty");
            }

            var repository = new ThreadRepository();
            var thread = repository.GetById(threadId);  // It is going to load Substitute now

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