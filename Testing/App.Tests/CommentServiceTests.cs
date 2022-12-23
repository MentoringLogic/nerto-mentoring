using App.BL;
using Xunit;
using NSubstitute;
using System.Threading;
using System;
using System.Linq;

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
            DateTime CreatedDate = new DateTime(2022, 12, 22, 12, 30, 00);
            CommentThread TestThread = new CommentThread();
            TestThread.Created = CreatedDate;

            threadRepository.GetById(id).Returns(TestThread);
            dateTimeProvider.GetNow().Returns(CreatedDate);

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
            DateTime CreatedDate = new DateTime(2022, 12, 22, 12, 30, 00);
            CommentThread TestThread = new CommentThread();
            TestThread.Created = CreatedDate;

            threadRepository.GetById(id).Returns(TestThread);
            dateTimeProvider.GetNow().Returns(CreatedDate);
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
            DateTime CreatedDate = new DateTime(2022, 12, 22, 12, 30, 00);
            CommentThread TestThread = new CommentThread();

            threadRepository.GetById(id).Returns(TestThread);
            dateTimeProvider.GetNow().Returns(CreatedDate);
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
            CommentThread TestThread = new CommentThread();
            TestThread.Resolved = true;

            threadRepository.GetById(id).Returns(TestThread);

            //Act
            var result = sut.AddCommentToThread("Hello guys", "Elon Musk", id);
            //Assert
            Assert.False(result);
        }
    }
}