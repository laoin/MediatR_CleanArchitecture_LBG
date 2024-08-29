using LBG.DataConnector.Application.Common.Interfaces;
using LBG.DataConnector.Domain.Entities;
using LBG.DataConnector.Domain.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LBG.DataConnector.Application.Items.Commands.UpdateItem
{
    public class UpdateItemCommandHandler : IRequestHandler<UpdateItemCommand, bool>
    {
        private readonly IDatabaseRepository _databaseRepository;
        private readonly IMediator _mediator;
        public UpdateItemCommandHandler(IDatabaseRepository dataBaseRepository, IMediator mediator)
        {
            _databaseRepository = dataBaseRepository;
            _mediator = mediator;
        }
        public async Task<bool> Handle(UpdateItemCommand request, CancellationToken cancellationToken)
        {
            if (request.Title.Length > 200)
                throw new Exception("Title must be less than 200 characters");

            if (request.Price <= 0)
                throw new Exception("It can't be free");

            ItemDto existingItem = await _databaseRepository.GetItemById(request.Id);
            await _databaseRepository.UpdateItem(request.Id, request.Price, request.Title);

            await _mediator.Publish(new ItemUpdated()
            {
                Id = request.Id,
                NewPrice = request.Price,
                Title = request.Title,
                OldPrice = request.Price,
                OldTitle = request.Title
            }).ConfigureAwait(false);

            return true;
        }
    }
}
