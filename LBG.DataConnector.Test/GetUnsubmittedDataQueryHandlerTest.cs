using AutoMapper;
using LBG.DataConnector.Application.Common.Interfaces;
using LBG.DataConnector.Application.UnsubmittedData.Queries;
using LBG.DataConnector.Domain.Entities;
using LBG.DataConnector.Infrastructure.Data;
using MediatR;
using Microsoft.Extensions.Configuration;
using Moq;
using static System.Net.Mime.MediaTypeNames;

namespace LBG.DataConnector.Test
{
    public class GetUnsubmittedDataQueryHandlerTest
    {
        [Fact]
        public async Task Handle_ShouldReturnMappedUnsubmittedDataBriefDtos()
        {
            // Arrange
            var mockDatabaseRepository = new Mock<IDatabaseRepository>();
            var mockMapper = new Mock<IMapper>();
            var mockMediator = new Mock<IMediator>();

            var unsubmittedData = new List<UnsubmittedDataDto>
            {
                new UnsubmittedDataDto { ClientName = "Client1", ReferenceNumber = "123" },
                new UnsubmittedDataDto { ClientName = "Client2", ReferenceNumber = "456" }
            };

            var unsubmittedDataBriefDtos = new List<UnsubmittedDataBriefDto>
            {
                new UnsubmittedDataBriefDto { ClientName = new string[] { "Client1" }, ReferenceNumber = "123" },
                new UnsubmittedDataBriefDto { ClientName = new string[] { "Client2" }, ReferenceNumber = "456" }
            };

            // Set up the mock for GetUnsubmittedData from the repository
            mockDatabaseRepository.Setup(repo => repo.GetUnsubmittedData())
                .ReturnsAsync(unsubmittedData);

            // Set up the mock for mapping
            mockMapper.Setup(mapper => mapper.Map<IEnumerable<UnsubmittedDataBriefDto>>(unsubmittedData))
                .Returns(unsubmittedDataBriefDtos);

            // Create the handler
            var handler = new GetUnsubmittedDataQueryHandler(mockDatabaseRepository.Object, mockMapper.Object, mockMediator.Object);

            // Act
            var result = await handler.Handle(new GetUnsubmittedDataQuery(), CancellationToken.None);

            // Assert
            Assert.NotNull(result);
            Assert.Equal(2, result.Count());
            Assert.Equal(new string[] { "Client1" }, result.First().ClientName);
            Assert.Equal(new string[] { "Client2" }, result.Last().ClientName);

            // Verify that the GetUnsubmittedData method was called exactly once
            mockDatabaseRepository.Verify(repo => repo.GetUnsubmittedData(), Times.Once);

            // Verify that the Map method was called with the correct parameters
            mockMapper.Verify(mapper => mapper.Map<IEnumerable<UnsubmittedDataBriefDto>>(unsubmittedData), Times.Once);
        }
    }
}
