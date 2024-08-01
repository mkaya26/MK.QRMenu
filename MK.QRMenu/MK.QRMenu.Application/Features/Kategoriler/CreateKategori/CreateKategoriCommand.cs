using MediatR;
using TS.Result;

namespace MK.QRMenu.Application.Features.Kategoriler.CreateKategori
{
    public sealed record CreateKategoriCommand(
        string KategoriAdi,
        Guid? UstKategoriId,
        string? ArkaPlanRengi,
        string? YaziRengi) : IRequest<Result<string>>;
}
