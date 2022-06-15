using Api.Controllers;
using Application.Categories.Queries.GetAllCategories;
using Application.Categories.Queries.GetCategoryById;
using AutoMapper;
using Domain.Entities;
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
    public class CategoryControllerFixture
    {
        private readonly Mock<IMediator> _mockMediator = new Mock<IMediator>();
        private readonly Mock<IMapper> _mockMapper = new Mock<IMapper>();

        [TestMethod]
        public async Task GetAllCatgeoriesQueryIsCalled()
        {
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetAllCategoriesQuery>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            var controller = new CategoryController(_mockMediator.Object, _mockMapper.Object);
            await controller.GetAllCategories();

            _mockMediator.Verify(x => x.Send(It.IsAny<GetAllCategoriesQuery>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [TestMethod]
        public async Task GetCategoryById()
        {
            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetCategoryByIdQuery>(), It.IsAny<CancellationToken>()))
                .Verifiable();

            var controller = new CategoryController(_mockMediator.Object, _mockMapper.Object);
            await controller.GetCategoryById(1);

            _mockMediator.Verify(x => x.Send(It.IsAny<GetCategoryByIdQuery>(), It.IsAny<CancellationToken>()), Times.Once());
        }

        [TestMethod]
        public async Task GetCategoryByIdCalledWithCorrectId()
        {
            int categoryId = 0;

            _mockMediator
                .Setup(m => m.Send(It.IsAny<GetCategoryByIdQuery>(), It.IsAny<CancellationToken>()))
                .Returns<GetCategoryByIdQuery, CancellationToken>(async (q, c) =>
                {
                    categoryId = q.Id;
                    return await Task.FromResult(
                        new Category
                        {
                            Id = q.Id,
                            CategoryName = "romance"
                        });
                });

            var controller = new CategoryController(_mockMediator.Object, _mockMapper.Object);

            await controller.GetCategoryById(1);

            Assert.AreEqual(categoryId, 1);
        }
    }
}
