using System;
using App.BL.Date.DateTimeProvider.DateTimeProviderInterface;
using App.BL.Date.DateTimeProvider;
using App.BL.Threads;
using App.BL.Threads.ThreadInterfaces;
using App.BL.Comments.CommentWrappers;
using App.BL.Comments;

namespace App.BL
{
    public class CommentService
    {
        private ICommentStoreWrapper _commentWrapper;
        private IThreadRepository _threadRepository;
        private IDateTimeProvider _dateTimeProvider;
        public CommentService() : this(new CommentStoreWrapper(), new ThreadRepository(), new DateTimeProvider())
        {

        }
        public CommentService(ICommentStoreWrapper commentWrapper, IThreadRepository threadRepository, IDateTimeProvider dateTimeProvider)
        {
            _commentWrapper = commentWrapper;
            _threadRepository = threadRepository;
            _dateTimeProvider = dateTimeProvider;
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

            DateTime today = _dateTimeProvider.GetCurrentDateTime;
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