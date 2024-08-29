using AutoMapper;
using LBG.DataConnector.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LBG.DataConnector.Application.Items.Queries.GetItems
{
    public class ItemBriefDto
    {
        public int Id { get; init; }

        public decimal Price { get; init; }

        public string? Title { get; init; }
    }
}
