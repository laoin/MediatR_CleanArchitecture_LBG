using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LBG.DataConnector.Application.Items.Queries.GetItems
{
    public record GetItemsQuery : IRequest<List<ItemBriefDto>>
    {

    }
}
