using EPortalAdmin.Application.ViewModels.Taxes;
using EPortalAdmin.Application.Wrappers.Results;
using EPortalAdmin.Core.Domain.Entities;
using EPortalAdmin.Core.Domain.Enums;
using EPortalAdmin.Core.Exceptions;
using EPortalAdmin.Domain.Constants;
using FluentValidation;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace EPortalAdmin.Application.Features.Taxes.Commands
{
    public class SaveTaxCommand : IRequest<DataResult<TaxDto>>
    {
        public int? Id { get; set; }
        public string? Code { get; set; }
        public int? Order { get; set; }
        public string? Name { get; set; }
        public string? ShortName { get; set; }
        public int? Factor { get; set; }
        public bool? IsRate { get; set; }

        public class SaveTaxCommandHandler(IValidator<SaveTaxCommand> validator)
            : ApplicationFeatureBase<Tax>, IRequestHandler<SaveTaxCommand, DataResult<TaxDto>>
        {
            public async Task<DataResult<TaxDto>> Handle(SaveTaxCommand request, CancellationToken cancellationToken)
            {
                Tax tax = null;
                if (request.Id.HasValue)
                {
                    tax = await Repository.GetAsync(m => m.Id == request.Id, cancellationToken: cancellationToken) 
                              ?? throw new NotFoundException(Messages.Tax.TaxNotFound, ExceptionCode.TaxNotFound);

                    if (!tax.Code!.Equals(request.Code, StringComparison.OrdinalIgnoreCase))
                    {
                        await CheckIfTaxCodeExistsAsync(request);
                    }
                    
                    tax.Factor = request.Factor!.Value;
                    tax.IsRate = request.IsRate!.Value;
                    tax.Code = request.Code;
                    tax.Order = request.Order;
                    tax.Name = request.Name;
                    tax.ShortName = request.ShortName;
                }
                else
                {
                    await CheckIfTaxCodeExistsAsync(request);
                    
                    tax = Mapper.Map<Tax>(request);
                    Repository.Add(tax);
                }
                await Repository.SaveChangesAsync(cancellationToken);
                var taxDto = Mapper.Map<TaxDto>(tax);
                return new SuccessDataResult<TaxDto>(taxDto);
            }

            private async Task CheckIfTaxCodeExistsAsync(SaveTaxCommand request)
            {
                var isExists = await Repository.GetAsQueryable()
                    .AnyAsync(t => t.Code.ToUpper() == request.Code.ToUpper());

                if (isExists) throw new BusinessException("Vergi kodu zaten mevcut");
            }
        }
    }
}