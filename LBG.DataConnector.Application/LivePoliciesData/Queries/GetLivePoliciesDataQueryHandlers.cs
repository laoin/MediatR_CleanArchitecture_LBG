using AutoMapper;
using LBG.DataConnector.Application.Common.Interfaces;
using LBG.DataConnector.Application.UnsubmittedData.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LBG.DataConnector.Application.LivePoliciesData.Queries
{
    public class GetLivePoliciesDataQueryHandlers : IRequestHandler<GetLivePoliciesDataQuery, IEnumerable<LivePoliciesDataBriefDto>>
    {
        private readonly IDatabaseRepository _databaseRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public GetLivePoliciesDataQueryHandlers(IDatabaseRepository databaseRepository, IMapper mapper, IMediator mediator)
        {
            _databaseRepository = databaseRepository;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<IEnumerable<LivePoliciesDataBriefDto>> Handle(GetLivePoliciesDataQuery request, CancellationToken cancellationToken)
        {
            // Get data from repository
            var items = await _databaseRepository.GetLivePoliciesData();

            // Mapping data to Dto using AutoMapper
            var mappedItems = _mapper.Map<IEnumerable<LivePoliciesDataBriefDto>>(items);

            return mappedItems;
        }
    }
}
