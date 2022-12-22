using App.BL;
using Xunit;
using NSubstitute;
using System.Threading;
using System;
using System.Linq;
using Castle.Core.Resource;

namespace App.Tests
{
    public class CommentServiceTests
    {
        // WRITE TESTS HERE this is eloon musk
        public ICommentStoreWrapper commentStoreWrapper = Substitute.For<ICommentStoreWrapper>();
        public IThreadRepository threadRepository = Substitute.For<IThreadRepository>();
        public IDateTimeProvider dateTimeProvider = Substitute.For<IDateTimeProvider>();

        public CommentService sut;

        public CommentServiceTests()
        {
            this.sut = new CommentService(commentStoreWrapper, threadRepository, dateTimeProvider);
        }

        [Fact]
        public void AddCommentToThread_Comment_CommentAdded()
        {
            //Arrange
            Guid id = Guid.NewGuid();
            DateTime myDate = new DateTime(2022, 12, 22, 12, 30, 00);
            CommentThread newComment = new CommentThread();
            newComment.Created = myDate;

            threadRepository.GetById(id).Returns(newComment);
            dateTimeProvider.GetNow().Returns(myDate);

            //Act
            var result = sut.AddCommentToThread("Hello guys", "Elon Musk", id);

            //Assert
            Assert.True(result);
        }

        [Fact]
        public void AddCommentToThread_EmptyComment_Exception()
        {
            //Arrange
            Guid id = Guid.NewGuid();
            DateTime myDate = new DateTime(2022, 12, 22, 12, 30, 00);
            CommentThread newComment = new CommentThread();
            newComment.Created = myDate;

            threadRepository.GetById(id).Returns(newComment);
            dateTimeProvider.GetNow().Returns(myDate);
            //Act

            //Assert
            var caughtException = Assert.Throws<ArgumentException>(() => sut.AddCommentToThread("", "Elon Musk", id));
            Assert.Equal("Comment cannot be null or empty", caughtException.Message);
        }

        [Fact]
        public void AddCommentToThread_NotSameDataTime_Exception()
        {
            //Arrange
            Guid id = Guid.NewGuid();
            DateTime myDate = new DateTime(2022, 12, 22, 12, 30, 00);
            CommentThread newComment = new CommentThread();

            threadRepository.GetById(id).Returns(newComment);
            dateTimeProvider.GetNow().Returns(myDate);
            //Act

            //Assert
            var caughtException = Assert.Throws<ArgumentException>(() => sut.AddCommentToThread("Hello Guys", "Elon Musk", id));
            Assert.Equal("You cannot add comment to thread after 70 minutes of it creation", caughtException.Message);
        }

        [Fact]
        public void AddCommentToThread_ThreadIsNull_False()
        {
            //Arrange
            Guid id = Guid.NewGuid();
            CommentThread newComment = new CommentThread();
            newComment = null;

            threadRepository.GetById(id).Returns(newComment);
            //Act
            var result = sut.AddCommentToThread("Hello guys", "Elon Musk", id);
            //Assert
            Assert.False(result);
        }

        [Fact]
        public void AddCommentToThread_ThreadIsTrue_False()
        {
            //Arrange
            Guid id = Guid.NewGuid();
            CommentThread newComment = new CommentThread();
            newComment.Resolved = true;

            threadRepository.GetById(id).Returns(newComment);

            //Act
            var result = sut.AddCommentToThread("Hello guys", "Elon Musk", id);
            //Assert
            Assert.False(result);
        }
    }
}