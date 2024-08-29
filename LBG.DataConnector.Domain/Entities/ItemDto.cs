using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LBG.DataConnector.Domain.Entities
{
    public record ItemDto(int Id, decimal Price, string Title);
}
