using FluentValidation;
using MK.QRMenu.Domain.Entities;

namespace MK.QRMenu.Application.Features.Kampanyalar.CreateKampanya
{
    public sealed class CreateKampanyaCommandValidator : AbstractValidator<Kampanya>
    {
        public CreateKampanyaCommandValidator()
        {
            RuleFor(f => f.Title).MaximumLength(200);
            RuleFor(f => f.Description).MaximumLength(500);
        }
    }
}
