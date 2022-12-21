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
            var commentStore = Substitute.For<ICommentStoreWrapper>();
            var getById = Substitute.For<IGetById>();

            Guid id = Guid.NewGuid();
            Comment a = new Comment();
            var counter = 0;

            commentStore.When(x => x.AddCommentToThread(a)).Do(x => counter++);
            getById.GetById(id).Returns(new CommentThread());

            var CommentServiceInstance = new CommentService();
            CommentServiceInstance.SetStrategy(commentStore, getById);
            //Act
            var result = CommentServiceInstance.AddCommentToThread("Hello guys", "Elon Musk", id);

            //Assert
            Assert.True(result);
            
        }
    }
}