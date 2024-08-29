using LBG.DataConnector.Application.Common.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LBG.DataConnector.Application.UnsubmittedData.Queries
{
    public class GetUnsubmittedDataQuery: IRequest<IEnumerable<UnsubmittedDataBriefDto>>
    {
    }
}
