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
        // WRITE TESTS HERE this is eloon musk

        [Fact]
        public void AddCommentToThread_Comment_CommentAdded()
        {
            //Arrange
            var CommentStore = Substitute.For<ICommentStoreWrapper>();
            var threadRepository = Substitute.For<IThreadRepository>();
            var MyDateTime = Substitute.For<IMyDateTime>();

            Guid id = Guid.NewGuid();
            Comment a = new Comment();
            var counter = 0;
            DateTime myDate = new DateTime(2022, 12, 22, 12, 30, 00);
            CommentThread newComment = new CommentThread();
            newComment.Created = myDate;

            CommentStore.When(x => x.AddCommentToThread(a)).Do(x => counter++);
            threadRepository.GetById(id).Returns(newComment);
            MyDateTime.GetNow().Returns(myDate);

            var CommentServiceInstance = new CommentService(CommentStore, threadRepository, MyDateTime);
            //Act
            var result = CommentServiceInstance.AddCommentToThread("Hello guys", "Elon Musk", id);

            //Assert
            Assert.True(result);
            
        }
    }
}