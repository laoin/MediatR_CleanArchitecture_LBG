using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LBG.DataConnector.Domain.Entities
{
    public class TodoItem
    {
        public int Id { get; set; }
        public int ListId { get; set; }
        public string? Title { get; set; }
        public string? Note { get; set; }
        public int Priority { get; set; }
        public DateTime? Reminder { get; set; }
        public bool Done { get; set; }
        public DateTimeOffset Created { get; set; }
        public string? CreatedBy { get; set; }
        public DateTimeOffset LastModified { get; set; }
        public string? LastModifiedBy { get; set; }
    }
}
