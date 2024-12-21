using EPortalAdmin.Application.Features.Taxes.Commands;
using FluentValidation;

namespace EPortalAdmin.Application.Features.Taxes.Validators
{
    public class SaveTaxCommandValidator : AbstractValidator<SaveTaxCommand>
    {
        public SaveTaxCommandValidator()
        {
            RuleFor(c => c.Code).NotEmpty().WithMessage("Vergi kodu zorunludur");
            RuleFor(c => c.Name).NotEmpty().WithMessage("Vergi adı zorunludur");
            RuleFor(c => c.ShortName).NotEmpty().WithMessage("Vergi kısa adı zorunludur");
            RuleFor(c => c.Factor).NotEmpty().WithMessage("Factor zorunludur");
            RuleFor(c => c.IsRate).NotEmpty().WithMessage("IsRate zorunludur");
        }
    }
}