using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LBG.DataConnector.Application.ReferredCasesData.Queries
{
    public class ReferredCasesDataBriefDto
    {
        public List<string>? ClientName { get; set; }
        public string? Policy { get; set; }
        public string? Product { get; set; }
        public string? ProductCategory { get; set; }
        public DateTimeOffset LastUpdated { get; set; }
        public string? CurrentStatus { get; set; }
        public bool NeedAttention { get; set; }
    }
}
