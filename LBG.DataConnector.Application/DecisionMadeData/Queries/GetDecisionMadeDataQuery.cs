using MediatR;

namespace LBG.DataConnector.Application.DecisionMadeData.Queries
{


    public class GetDecisionMadeDataQuery : IRequest<IEnumerable<DecisionMadeDataBriefDto>>
    {
    }
}
