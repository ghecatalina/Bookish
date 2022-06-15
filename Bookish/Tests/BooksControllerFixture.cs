using Api.Controllers;
using Api.Dto;
using Application.Books.Queries.GetBookById;
using Application.Books.Queries.GetBooks;
using AutoMapper;
using Domain;
using MediatR;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Tests
{
    [TestClass]
    public class BooksControllerFixture
    {
        private readonly Mock<IMediator> _mockMediator = new Mock<IMediator>();
        private readonly Mock<IMapper> _mockMapper = new Mock<IMapper>();

        [TestMethod]
        public async Task GetAllBooksQueryIsCalled()
        {
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetBooksQuery>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            var controller = new BooksController(_mockMediator.Object, _mockMapper.Object);
            await controller.GetAll();

            _mockMediator.Verify(x => x.Send(It.IsAny<GetBooksQuery>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [TestMethod]
        public async Task GetBookById()
        {
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetBookByIdQuery>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            var controller = new BooksController(_mockMediator.Object, _mockMapper.Object);
            await controller.GetBookById(1);

            _mockMediator.Verify(x => x.Send(It.IsAny<GetBookByIdQuery>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [TestMethod]
        public async Task GetBookByIdCalledWithCorrectId()
        {
            int bookId = 0;

            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetBookByIdQuery>(), It.IsAny<CancellationToken>()))
                .Returns<GetBookByIdQuery, CancellationToken>(async (q, c) =>
                {
                    bookId = q.Id;
                    return await Task.FromResult(
                        new Book
                        {
                            Id = q.Id,
                            Title = "Learning C#",
                            Author = "John Smith"
                        });
                });

            var controller = new BooksController(_mockMediator.Object, _mockMapper.Object);

            await controller.GetBookById(1);

            Assert.AreEqual(bookId, 1);
        }
    }
}
