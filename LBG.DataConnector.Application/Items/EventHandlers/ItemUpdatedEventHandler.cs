using LBG.DataConnector.Domain.Events;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LBG.DataConnector.Application.Items.EventHandlers
{
    public class ItemUpdatedEventHandler : INotificationHandler<ItemUpdated>
    {
        public async Task Handle(ItemUpdated notification, CancellationToken cancellationToken)
        {
            decimal percentageDifference = ((notification.NewPrice - notification.OldPrice) * 100);

            if (percentageDifference <= 30)
            {
                Console.WriteLine("Logic to get who is wishlisting that ID and send the emails");
            }
        }
    }
}
