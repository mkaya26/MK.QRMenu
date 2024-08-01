using MediatR;
using MK.QRMenu.Domain.Entities;
using TS.Result;

namespace MK.QRMenu.Application.Features.Kategoriler.GetAllAltKategori
{
    public sealed record GetAllAltKategoriQuery(
        Guid UstKategoriId) : IRequest<Result<List<Kategori>>>;

}
