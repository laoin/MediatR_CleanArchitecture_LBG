using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LBG.DataConnector.Application.Common.Models
{
    public class ApplicationResponseDto<T>
    {
        public IEnumerable<T>? Data { get; set; }
        public string? Errors { get; set; }
    }
}
