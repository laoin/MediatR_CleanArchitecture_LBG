using LBG.DataConnector.Application.UnsubmittedData.Queries;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LBG.DataConnector.Application.ReferredCasesData.Queries
{
    public class GetReferredCasesDataQuery : IRequest<IEnumerable<ReferredCasesDataBriefDto>>
    {
    }
}
