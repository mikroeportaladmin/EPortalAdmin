using AutoMapper;
using EPortalAdmin.Application.Features.Taxes.Commands;
using EPortalAdmin.Application.ViewModels.Taxes;
using EPortalAdmin.Core.Domain.Entities;
using EPortalAdmin.Core.Persistence.Paging;

namespace EPortalAdmin.Application.Features.Taxes.Profiles
{
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<Tax, TaxDto>().ReverseMap();
            CreateMap<IPaginate<Tax>, TaxListDto>().ReverseMap();
            CreateMap<SaveTaxCommand, Tax>().ReverseMap();
        }
    }
}