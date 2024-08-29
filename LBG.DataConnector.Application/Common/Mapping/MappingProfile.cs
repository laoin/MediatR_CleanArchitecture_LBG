using AutoMapper;
using LBG.DataConnector.Application.DecisionMadeData.Queries;
using LBG.DataConnector.Application.Items.Queries.GetItems;
using LBG.DataConnector.Application.LivePoliciesData.Queries;
using LBG.DataConnector.Application.ReferredCasesData.Queries;
using LBG.DataConnector.Application.UnsubmittedData.Queries;
using LBG.DataConnector.Domain.Entities;

namespace LBG.DataConnector.Application.Common.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ItemDto, ItemBriefDto>();
            CreateMap<UnsubmittedDataDto, UnsubmittedDataBriefDto>()
                .ForMember(dest => dest.ClientName,
                    opt => opt.MapFrom(src => TransformClientName(src.ClientName)));

            CreateMap<DecisionMadeDataDto, DecisionMadeDataBriefDto>()
                .ForMember(dest => dest.ClientName,
                    opt => opt.MapFrom(src => TransformClientName(src.ClientName)));

            CreateMap<LivePoliciesDataDto, LivePoliciesDataBriefDto>()
                .ForMember(dest => dest.ClientName,
                    opt => opt.MapFrom(src => TransformClientName(src.ClientName)));

            CreateMap<ReferredCasesDataDto, ReferredCasesDataBriefDto>()
                .ForMember(dest => dest.ClientName,
                    opt => opt.MapFrom(src => TransformClientName(src.ClientName)));



        }

        #region Transform Methods
        private static string[] TransformClientName(string? clientName)
        {
            return clientName != null
                ? clientName.Split(new[] { ',' }, StringSplitOptions.RemoveEmptyEntries)
                    .Select(s => s.Trim()).ToArray()
                : Array.Empty<string>();
        }
        #endregion
    }
}
