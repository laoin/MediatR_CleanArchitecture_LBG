using AutoMapper;
using LBG.DataConnector.Application.Common.Interfaces;
using LBG.DataConnector.Application.DecisionMadeData.Queries;
using LBG.DataConnector.Domain.Entities;
using MediatR;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Xunit;

namespace LBG.DataConnector.Test
{
    public class GetDecisionMadeDataQueryHandlerTest
    {
        [Fact]
        public async Task Handle_ShouldReturnMappedDecisionMadeDataBriefDtos()
        {
            // Arrange
            var mockDatabaseRepository = new Mock<IDatabaseRepository>();
            var mockMapper = new Mock<IMapper>();
            var mockMediator = new Mock<IMediator>();

            var decisionMadeData = new List<DecisionMadeDataDto>
            {
                new DecisionMadeDataDto
                {
                    ClientName = "Client1",
                    Policy = "Policy1",
                    Product = "Product1",
                    ProductCategory = "Category1",
                    Premium = "Premium1",
                    LastUpdated = DateTimeOffset.UtcNow,
                    ExpiresIn = "30 days",
                    Decision = "Approved",
                    NeedAttention = true
                },
                new DecisionMadeDataDto
                {
                    ClientName = "Client2",
                    Policy = "Policy2",
                    Product = "Product2",
                    ProductCategory = "Category2",
                    Premium = "Premium2",
                    LastUpdated = DateTimeOffset.UtcNow,
                    ExpiresIn = "60 days",
                    Decision = "Rejected",
                    NeedAttention = false
                }
            };

            var decisionMadeDataBriefDtos = new List<DecisionMadeDataBriefDto>
            {
                new DecisionMadeDataBriefDto
                {
                    ClientName = new[] { "Client1" }, // Adjust to IEnumerable<string>
                    Policy = "Policy1",
                    Product = "Product1",
                    ProductCategory = "Category1",
                    Premium = "Premium1",
                    LastUpdated = DateTimeOffset.UtcNow,
                    ExpiresIn = "30 days",
                    Decision = "Approved",
                    NeedAttention = true
                },
                new DecisionMadeDataBriefDto
                {
                    ClientName = new[] { "Client2" }, // Adjust to IEnumerable<string>
                    Policy = "Policy2",
                    Product = "Product2",
                    ProductCategory = "Category2",
                    Premium = "Premium2",
                    LastUpdated = DateTimeOffset.UtcNow,
                    ExpiresIn = "60 days",
                    Decision = "Rejected",
                    NeedAttention = false
                }
            };

            // Set up the mock for GetDecisionMadeData from the repository
            mockDatabaseRepository.Setup(repo => repo.GetDecisionMadeData())
                .ReturnsAsync(decisionMadeData);

            // Set up the mock for mapping
            mockMapper.Setup(mapper => mapper.Map<IEnumerable<DecisionMadeDataBriefDto>>(decisionMadeData))
                .Returns(decisionMadeDataBriefDtos);

            // Create the handler
            var handler = new GetDecisionMadeDataQueryHandler(mockDatabaseRepository.Object, mockMapper.Object, mockMediator.Object);

            // Act
            var result = await handler.Handle(new GetDecisionMadeDataQuery(), CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
            Assert.Equal(new[] { "Client1" }, result.First().ClientName);
            Assert.Equal(new[] { "Client2" }, result.Last().ClientName);

            // Verify that the GetDecisionMadeData method was called exactly once
            mockDatabaseRepository.Verify(repo => repo.GetDecisionMadeData(), Times.Once);

            // Verify that the Map method was called with the correct parameters
            mockMapper.Verify(mapper => mapper.Map<IEnumerable<DecisionMadeDataBriefDto>>(decisionMadeData), Times.Once);
        }
    }
}
