using AutoMapper;
using LBG.DataConnector.Application.Common.Interfaces;
using MediatR;

namespace LBG.DataConnector.Application.Items.Queries.GetItems
{
    public class GetItemsQueryHandler : IRequestHandler<GetItemsQuery, List<ItemBriefDto>>
    {
        private readonly IDatabaseRepository _databaseRepository;
        private readonly IMapper _mapper;
        private readonly IMediator _mediator;

        public GetItemsQueryHandler(IDatabaseRepository databaseRepository, IMapper mapper, IMediator mediator)
        {
            _databaseRepository = databaseRepository;
            _mapper = mapper;
            _mediator = mediator;
        }

        public async Task<List<ItemBriefDto>> Handle(GetItemsQuery request, CancellationToken cancellationToken)
        {
            // Get data from repository
            var items = await _databaseRepository.GetItems();

            // Mapping data to UnsubmittedDataBriefDto using AutoMapper
            var mappedItems = _mapper.Map<List<ItemBriefDto>>(items);

            return mappedItems;
        }
    }
}
