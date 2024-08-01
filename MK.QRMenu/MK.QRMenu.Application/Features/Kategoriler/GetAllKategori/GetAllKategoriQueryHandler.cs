using MediatR;
using Microsoft.EntityFrameworkCore;
using MK.QRMenu.Domain.Entities;
using MK.QRMenu.Domain.Repositories;
using TS.Result;

namespace MK.QRMenu.Application.Features.Kategoriler.GetAllKategori
{
    internal sealed class GetAllKategoriQueryHandler(
        IKategoriRepository kategoriRepository) : IRequestHandler<GetAllKategoriQuery, Result<List<Kategori>>>
    {
        public async Task<Result<List<Kategori>>> Handle(GetAllKategoriQuery request, CancellationToken cancellationToken)
        {
            List<Kategori> result = await kategoriRepository.GetAll().Where(f => !f.IsDeleted).ToListAsync(cancellationToken);
            return result;
        }
    }
}
