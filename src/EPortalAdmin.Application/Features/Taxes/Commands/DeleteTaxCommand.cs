using EPortalAdmin.Application.ViewModels.OperationClaim;
using EPortalAdmin.Application.Wrappers.Results;
using EPortalAdmin.Core.Domain.Entities;
using EPortalAdmin.Core.Domain.Enums;
using EPortalAdmin.Core.Exceptions;
using EPortalAdmin.Domain.Constants;
using MediatR;

namespace EPortalAdmin.Application.Features.Taxes.Commands
{
    public class DeleteTaxCommand : IRequest<Result>
    {
        public int Id { get; set; }

        public class DeleteTaxCommandHandler : ApplicationFeatureBase<Tax>, IRequestHandler<DeleteTaxCommand, Result>
        {
            public async Task<Result> Handle(DeleteTaxCommand request, CancellationToken cancellationToken)
            {
                var tax = await Repository.GetAsync(m => m.Id == request.Id, cancellationToken: cancellationToken) 
                    ?? throw new NotFoundException(Messages.Tax.TaxNotFound, ExceptionCode.TaxNotFound);

                tax.MarkAsDelete(CurrentUserId);
                await Repository.SaveChangesAsync(cancellationToken);
                return new Result(true);
            }
        }
    }
}