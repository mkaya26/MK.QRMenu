using FluentValidation;

namespace MK.QRMenu.Application.Features.Kategoriler.UpdateKategori
{
    public sealed class UpdateKategoriCommandValidator : AbstractValidator<UpdateKategoriCommand>
    {
        public UpdateKategoriCommandValidator()
        {
            RuleFor(f => f.Id).NotNull();
            RuleFor(f => f.KategoriAdi).MaximumLength(100);
            RuleFor(f => f.KategoriAdi).MaximumLength(20);
            RuleFor(f => f.KategoriAdi).MaximumLength(20);
        }
    }
}
