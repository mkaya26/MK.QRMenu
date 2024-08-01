using MediatR;
using MK.QRMenu.Domain.Entities;
using TS.Result;

namespace MK.QRMenu.Application.Features.Kategoriler.GetAllKategori
{
    public sealed record GetAllKategoriQuery() : IRequest<Result<List<Kategori>>>;

}
