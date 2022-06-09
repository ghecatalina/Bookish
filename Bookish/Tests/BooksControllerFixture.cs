using MediatR;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass]
    public class BooksControllerFixture
    {
        private readonly Mock<IMediator> _mockMediator = new Mock<IMediator>();
        [TestMethod]
        public async Task GetBooksQueryIsCalld()
        {
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetBooksQuery>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            var controller = new BooksController(_mockMediator.Object);
            await controller.Get();

            _mockMediator.Verify(x => x.Send(It.IsAny<GetBooksQuery>(), It.IsAny<CancellationToken>()), Times.Once());
        }
    }
}
