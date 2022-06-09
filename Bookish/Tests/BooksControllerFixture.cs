using MediatR;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
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
                .Setup(m => m.Send(It.IsAny<GetBooksQuery>()))
        }
    }
}
