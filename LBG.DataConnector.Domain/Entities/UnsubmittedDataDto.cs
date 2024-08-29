using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LBG.DataConnector.Domain.Entities
{
    public class UnsubmittedDataDto
    {
        public string? ClientName { get; set; }
        public string? ReferenceNumber { get; set; }
        public string? Product { get; set; }
        public string? ProductCategory { get; set; }
        public string? Premium { get; set; }
        public string? Stage { get; set; }
        public string? StageName { get; set; }
        public DateTimeOffset DateCreated { get; set; }
        public string? CurrentStep { get; set; }
        public string? ExpiresIn { get; set; }
        public string? ContinueStep { get; set; }
    };

}
