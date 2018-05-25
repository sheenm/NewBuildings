using System;
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
                            Id = Guid.NewGuid(),
                            House = null,
                        }
                    }
                ));
            var controller = new FlatController(flatRepoMoq.Object);

            var response = await controller.GetAllFlatsSummary();
            Assert.Equal(ResponseStatuses.Exception, response.Status);
        }
    }
}
