using EPortalAdmin.Application.ViewModels.Taxes;
using EPortalAdmin.Application.Wrappers.Results;
using EPortalAdmin.Core.Domain.Entities;
using EPortalAdmin.Core.Domain.Models;
using MediatR;

namespace EPortalAdmin.Application.Features.Taxes.Queries
{
    public class GetTaxListQuery : PagingRequest, IRequest<DataResult<TaxListDto>>
    {
        public string? Code { get; set; }
        public string? Name { get; set; }
        public string? ShortName { get; set; }
        public int? Factor { get; set; }
        public bool? IsRate { get; set; }

        public class GetTaxListQueryHandler : ApplicationFeatureBase<Tax>, IRequestHandler<GetTaxListQuery, DataResult<TaxListDto>>
        {
            public async Task<DataResult<TaxListDto>> Handle(GetTaxListQuery request, CancellationToken cancellationToken)
            {                
                var taxList = await Repository.GetListAsync(
                    predicate: (x => (string.IsNullOrEmpty(request.Code) || x.Code!.ToUpper().Contains(request.Code.ToUpper())) 
                                     && (string.IsNullOrEmpty(request.Name) || x.Name!.ToUpper().Contains(request.Name.ToUpper()))
                                     && (string.IsNullOrEmpty(request.ShortName) || x.ShortName!.ToUpper().Contains(request.ShortName.ToUpper()))
                                     && (request.Factor == null || x.Factor == request.Factor)
                                     && (request.IsRate == null || x.IsRate == request.IsRate)
                    ),
                    index: request.Page,
                    size: request.PageSize);

                var dtoTaxList = Mapper.Map<TaxListDto>(taxList);

                return new SuccessDataResult<TaxListDto>(dtoTaxList);
            }
        }
    }
}