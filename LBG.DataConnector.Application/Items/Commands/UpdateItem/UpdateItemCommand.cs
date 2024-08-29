using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LBG.DataConnector.Application.Items.Commands.UpdateItem
{
    public record UpdateItemCommand : IRequest<bool>
    {
        public required int Id { get; init; }
        public required decimal Price { get; init; }
        public required string Title { get; init; }
    }
}
