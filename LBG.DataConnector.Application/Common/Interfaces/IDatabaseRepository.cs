using LBG.DataConnector.Application.Items.Queries.GetItems;
using LBG.DataConnector.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LBG.DataConnector.Application.Common.Interfaces
{
    public interface IDatabaseRepository
    {
        Task<bool> UpdateItem(int itemId, decimal newPrice, string title);
        Task<ItemDto> GetItemById(int id);
        Task<List<ItemDto>> GetItems();
        Task<IEnumerable<UnsubmittedDataDto>> GetUnsubmittedData();
        Task<IEnumerable<DecisionMadeDataDto>> GetDecisionMadeData();
        Task<IEnumerable<LivePoliciesDataDto>> GetLivePoliciesData();
        Task<IEnumerable<ReferredCasesDataDto>> GetReferredCasesData();
    }
}
