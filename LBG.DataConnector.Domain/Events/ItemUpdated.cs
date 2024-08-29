using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LBG.DataConnector.Domain.Events
{
    public record ItemUpdated : INotification
    {
        public required int Id { get; init; }
        public required decimal NewPrice { get; init; }
        public required decimal OldPrice { get; init; }
        public required string Title { get; init; }
        public required string OldTitle { get; init; }

    }
}
