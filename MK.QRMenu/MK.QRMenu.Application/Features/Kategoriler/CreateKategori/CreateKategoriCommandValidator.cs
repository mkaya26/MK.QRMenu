using FluentValidation;
using MK.QRMenu.Domain.Entities;

namespace MK.QRMenu.Application.Features.Kategoriler.CreateKategori
{
    public sealed class CreateKategoriCommandValidator : AbstractValidator<CreateKategoriCommand>
    {
        public CreateKategoriCommandValidator()
        {
            RuleFor(f => f.KategoriAdi).MaximumLength(100);
            RuleFor(f => f.KategoriAdi).MaximumLength(20);
            RuleFor(f => f.KategoriAdi).MaximumLength(20);
        }
    }
}
