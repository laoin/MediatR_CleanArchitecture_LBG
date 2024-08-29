using AutoMapper;
using LBG.DataConnector.Application.Common.Interfaces;
using LBG.DataConnector.Application.Common.Models;
using LBG.DataConnector.Application.Items.Queries.GetItems;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace LBG.DataConnector.Application.UnsubmittedData.Queries
{
    public class GetUnsubmittedDataQueryHandler : IRequestHandler<GetUnsubmittedDataQuery, IEnumerable<UnsubmittedDataBriefDto>>
    {
        private readonly IDatabaseRepository _databaseRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public GetUnsubmittedDataQueryHandler(IDatabaseRepository databaseRepository, IMapper mapper, IMediator mediator)
        {
            _databaseRepository = databaseRepository;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<IEnumerable<UnsubmittedDataBriefDto>> Handle(GetUnsubmittedDataQuery request, CancellationToken cancellationToken)
        {
            // Get data from repository
            var items = await _databaseRepository.GetUnsubmittedData();

            // Mapping data to Dto using AutoMapper
            var mappedItems = _mapper.Map<IEnumerable<UnsubmittedDataBriefDto>>(items);

            return mappedItems;
        }
    }
}
