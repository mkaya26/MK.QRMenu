using MediatR;
using TS.Result;

namespace MK.QRMenu.Application.Features.Kategoriler.UpdateKategori
{
    public sealed record UpdateKategoriCommand(
        Guid Id,
        string KategoriAdi,
        Guid? UstKategoriId,
        string? ArkaPlanRengi,
        string? YaziRengi) : IRequest<Result<string>>;
}
