﻿using System;
using System.Collections.Generic;
using Moq;
using System.Threading.Tasks;
using Xunit;
using NewBuildings.Data.Abstract;
using NewBuildings.Data.Objects;
using NewBuildings.Core;

namespace NewBuildings.BusinessLogic.Tests.Controllers
{
    public class FlatControllerTests
    {
        public FlatControllerTests()
        {
        }

        [Fact]
        public async Task GetAllFlatsSummary_ShouldReturnOk()
        {
            var flatRepoMoq = new Mock<IFlatRepository>();
            flatRepoMoq
                .Setup(m => m.GetAllFlatsWithHouseInfo())
                .Returns(Task.FromResult<IEnumerable<Flat>>
                (
                    new List<Flat>
                    {
                        new Flat
                        {
                            House = new House (),
                        }
                    }
                ));
            var controller = new FlatController(flatRepoMoq.Object);

            var response = await controller.GetAllFlatsSummary();
            Assert.Equal(ResponseStatuses.Ok, response.Status);
        }

        [Fact]
        public async Task GetAllFlatsSummary_ShouldReturnException()
        {
            var flatRepoMoq = new Mock<IFlatRepository>();
            flatRepoMoq
                .Setup(m => m.GetAllFlatsWithHouseInfo())
                .Returns(Task.FromResult<IEnumerable<Flat>>
                (
                    new List<Flat>
                    {
                        new Flat
                        {
                            Id = 23,
                            House = null,
                        }
                    }
                ));
            var controller = new FlatController(flatRepoMoq.Object);
            await Assert.ThrowsAnyAsync<Exception>(controller.GetAllFlatsSummary);
        }

        [Fact]
        public async Task DeleteFlat_EmptyIdentifier_Warning()
        {
            var flatRepoMoq = new Mock<IFlatRepository>();

            var controller = new FlatController(flatRepoMoq.Object);
            var actualResponse = await controller.DeleteFlat(0);

            Assert.Equal(ResponseStatuses.Warning, actualResponse.Status);
        }

        [Theory]
        [InlineData(1)]
        [InlineData(100)]
        [InlineData(10000)]
        public async Task DeleteFlat_NonEmptyIdentifier_OkResponse(int id)
        {
            var flatRepoMoq = new Mock<IFlatRepository>();
            flatRepoMoq
                .Setup(m => m.Delete(id))
                .Returns(Task.FromResult(true));

            var controller = new FlatController(flatRepoMoq.Object);
            var actualResponse = await controller.DeleteFlat(id);

            Assert.Equal(ResponseStatuses.Ok, actualResponse.Status);
        }
    }
}
