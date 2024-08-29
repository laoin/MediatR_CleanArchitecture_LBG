using AutoMapper;
using LBG.DataConnector.Application.Common.Interfaces;
using LBG.DataConnector.Application.LivePoliciesData.Queries;
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
    public class GetLivePoliciesDataQueryHandlersTest
    {
        [Fact]
        public async Task Handle_ShouldReturnMappedLivePoliciesDataBriefDtos()
        {
            // Arrange
            var mockDatabaseRepository = new Mock<IDatabaseRepository>();
            var mockMapper = new Mock<IMapper>();
            var mockMediator = new Mock<IMediator>();

            var livePoliciesData = new List<LivePoliciesDataDto>
            {
                new LivePoliciesDataDto { ClientName = "Client1", Policy = "Policy1" },
                new LivePoliciesDataDto { ClientName = "Client2", Policy = "Policy2" }
            };

            var livePoliciesDataBriefDtos = new List<LivePoliciesDataBriefDto>
            {
                new LivePoliciesDataBriefDto { ClientName = new string[] { "Client1" }, Policy = "Policy1" },
                new LivePoliciesDataBriefDto { ClientName = new string[] { "Client2" }, Policy = "Policy2" }
            };

            // Set up the mock for GetLivePoliciesData from the repository
            mockDatabaseRepository.Setup(repo => repo.GetLivePoliciesData())
                .ReturnsAsync(livePoliciesData);

            // Set up the mock for mapping
            mockMapper.Setup(mapper => mapper.Map<IEnumerable<LivePoliciesDataBriefDto>>(livePoliciesData))
                .Returns(livePoliciesDataBriefDtos);

            // Create the handler
            var handler = new GetLivePoliciesDataQueryHandlers(mockDatabaseRepository.Object, mockMapper.Object, mockMediator.Object);

            // Act
            var result = await handler.Handle(new GetLivePoliciesDataQuery(), CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
            Assert.Equal(new string[] { "Client1" }, result.First().ClientName);
            Assert.Equal(new string[] { "Client2" }, result.Last().ClientName);

            // Verify that the GetLivePoliciesData method was called exactly once
            mockDatabaseRepository.Verify(repo => repo.GetLivePoliciesData(), Times.Once);

            // Verify that the Map method was called with the correct parameters
            mockMapper.Verify(mapper => mapper.Map<IEnumerable<LivePoliciesDataBriefDto>>(livePoliciesData), Times.Once);
        }
    }
}
