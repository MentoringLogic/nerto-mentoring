using Xunit;
using NSubstitute;
using System.Threading;
using System;
using System.Linq;
using App.BL.Comments;
using App.BL.Threads;
using App.BL.Threads.ThreadInterfaces;
using App.BL.Date.DateTimeProvider.DateTimeProviderInterface;
using App.BL.Comments.CommentWrappers;

namespace App.Tests
{
    public class CommentServiceTests
    {
        // WRITE TESTS HERE
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
            DateTime createdDate = new DateTime(2022, 12, 22, 12, 30, 00);
            CommentThread testThread = new CommentThread();
            testThread.Created = createdDate;

            threadRepository.GetById(id).Returns(testThread);
            dateTimeProvider.GetNow().Returns(createdDate);

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
            //DateTime CreatedDate = new DateTime(2022, 12, 22, 12, 30, 00);
            CommentThread testThread = new CommentThread();
            threadRepository.GetById(id).Returns(testThread);
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
            DateTime createdDate = new DateTime(2022, 12, 22, 12, 30, 00);
            CommentThread testThread = new CommentThread();

            threadRepository.GetById(id).Returns(testThread);
            dateTimeProvider.GetNow().Returns(createdDate);
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

            threadRepository.GetById(id).Returns((CommentThread)null);
            //Act
            var result = sut.AddCommentToThread("Hello guys", "Elon Musk", id);
            //Assert
            Assert.False(result);
        }

        [Fact]
        public void AddCommentToThread_ResolvedIsTrue_False()
        {
            //Arrange
            Guid id = Guid.NewGuid();
            CommentThread testThread = new CommentThread();
            testThread.Resolved = true;

            threadRepository.GetById(id).Returns(testThread);

            //Act
            var result = sut.AddCommentToThread("Hello guys", "Elon Musk", id);
            //Assert
            Assert.False(result);
        }
    }
}