using AutoMapper;
using LBG.DataConnector.Application.Common.Interfaces;
using LBG.DataConnector.Application.UnsubmittedData.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LBG.DataConnector.Application.DecisionMadeData.Queries
{

    public class GetDecisionMadeDataQueryHandler : IRequestHandler<GetDecisionMadeDataQuery, IEnumerable<DecisionMadeDataBriefDto>>
    {
        private readonly IDatabaseRepository _databaseRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public GetDecisionMadeDataQueryHandler(IDatabaseRepository databaseRepository, IMapper mapper, IMediator mediator)
        {
            _databaseRepository = databaseRepository;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<IEnumerable<DecisionMadeDataBriefDto>> Handle(GetDecisionMadeDataQuery request, CancellationToken cancellationToken)
        {
            // Get data from repository
            var items = await _databaseRepository.GetDecisionMadeData();

            // Mapping data to Dto using AutoMapper
            var mappedItems = _mapper.Map<IEnumerable<DecisionMadeDataBriefDto>>(items);

            return mappedItems;
        }
    }
}
