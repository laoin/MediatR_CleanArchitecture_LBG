using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LBG.DataConnector.Domain.Entities
{
    public class LivePoliciesDataDto
    {
        public string? ClientName { get; set; }
        public string? Policy { get; set; }
        public string?  Product { get; set; }
        public string? ProductCategory { get; set; }
        public string? Premium { get; set; }
        public DateTimeOffset StartDate { get; set; }
        public DateTimeOffset LastUpdated { get; set; }
        public string? SummaryIssue { get; set; }
        public bool NeedAttention { get; set; }
    };

}
