using MediatR;
using Microsoft.EntityFrameworkCore;
using MK.QRMenu.Domain.Entities;
using MK.QRMenu.Domain.Repositories;
using TS.Result;

namespace MK.QRMenu.Application.Features.Kategoriler.GetAllAltKategori
{
    internal sealed class GetAllAltKategoriQueryHandler(
        IKategoriRepository kategoriRepository) : IRequestHandler<GetAllAltKategoriQuery, Result<List<Kategori>>>
    {
        public async Task<Result<List<Kategori>>> Handle(GetAllAltKategoriQuery request, CancellationToken cancellationToken)
        {
            List<Kategori> result = await kategoriRepository.GetAll().Where(f => !f.IsDeleted && f.UstKategoriId == request.UstKategoriId).ToListAsync(cancellationToken);
            return result;
        }
    }
}
