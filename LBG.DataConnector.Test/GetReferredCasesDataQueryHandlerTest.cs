using AutoMapper;
using LBG.DataConnector.Application.Common.Interfaces;
using LBG.DataConnector.Application.ReferredCasesData.Queries;
using LBG.DataConnector.Domain.Entities;
using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LBG.DataConnector.Test
{
    public class GetReferredCasesDataQueryHandlerTest
    {
        [Fact]
        public async Task Handle_ShouldReturnMappedReferredCasesDataBriefDtos()
        {
            // Arrange
            var mockDatabaseRepository = new Mock<IDatabaseRepository>();
            var mockMapper = new Mock<IMapper>();
            var mockMediator = new Mock<IMediator>();

            var referredCasesData = new List<ReferredCasesDataDto>
            {
                new ReferredCasesDataDto
                {
                    ClientName = "Client1",
                    Policy = "Policy1",
                    Product = "Product1",
                    ProductCategory = "Category1",
                    LastUpdated = DateTimeOffset.UtcNow,
                    CurrentStatus = "Status1",
                    NeedAttention = true
                },
                new ReferredCasesDataDto
                {
                    ClientName = "Client2",
                    Policy = "Policy2",
                    Product = "Product2",
                    ProductCategory = "Category2",
                    LastUpdated = DateTimeOffset.UtcNow,
                    CurrentStatus = "Status2",
                    NeedAttention = false
                }
            };

            var referredCasesDataBriefDtos = new List<ReferredCasesDataBriefDto>
            {
                new ReferredCasesDataBriefDto
                {
                    ClientName = new List<string> { "Client1" }, // Adjust to List<string>
                    Policy = "Policy1",
                    Product = "Product1",
                    ProductCategory = "Category1",
                    LastUpdated = DateTimeOffset.UtcNow,
                    CurrentStatus = "Status1",
                    NeedAttention = true
                },
                new ReferredCasesDataBriefDto
                {
                    ClientName = new List<string> { "Client2" }, // Adjust to List<string>
                    Policy = "Policy2",
                    Product = "Product2",
                    ProductCategory = "Category2",
                    LastUpdated = DateTimeOffset.UtcNow,
                    CurrentStatus = "Status2",
                    NeedAttention = false
                }
            };

            // Set up the mock for GetReferredCasesData from the repository
            mockDatabaseRepository.Setup(repo => repo.GetReferredCasesData())
                .ReturnsAsync(referredCasesData);

            // Set up the mock for mapping
            mockMapper.Setup(mapper => mapper.Map<IEnumerable<ReferredCasesDataBriefDto>>(referredCasesData))
                .Returns(referredCasesDataBriefDtos);

            // Create the handler
            var handler = new GetReferredCasesDataQueryHandler(mockDatabaseRepository.Object, mockMapper.Object, mockMediator.Object);

            // Act
            var result = await handler.Handle(new GetReferredCasesDataQuery(), CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
            Assert.Equal(new List<string> { "Client1" }, result.First().ClientName);
            Assert.Equal(new List<string> { "Client2" }, result.Last().ClientName);

            // Verify that the GetReferredCasesData method was called exactly once
            mockDatabaseRepository.Verify(repo => repo.GetReferredCasesData(), Times.Once);

            // Verify that the Map method was called with the correct parameters
            mockMapper.Verify(mapper => mapper.Map<IEnumerable<ReferredCasesDataBriefDto>>(referredCasesData), Times.Once);
        }
    }
}
