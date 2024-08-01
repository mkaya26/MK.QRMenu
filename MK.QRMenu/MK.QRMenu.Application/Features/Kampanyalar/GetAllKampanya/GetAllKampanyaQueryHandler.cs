using MediatR;
using Microsoft.EntityFrameworkCore;
using MK.QRMenu.Domain.Entities;
using MK.QRMenu.Domain.Repositories;
using TS.Result;

namespace MK.QRMenu.Application.Features.Kampanyalar.GetAllKampanya
{
    internal sealed class GetAllKampanyaQueryHandler(
        IKampanyaRepository kampanyaRepository) : IRequestHandler<GetAllKampanyaQuery, Result<List<Kampanya>>>
    {
        public async Task<Result<List<Kampanya>>> Handle(GetAllKampanyaQuery request, CancellationToken cancellationToken)
        {
            List<Kampanya> list = await kampanyaRepository.GetAll().Where(f => !f.IsDeleted).ToListAsync(cancellationToken);
            //
            return list;
        }
    }
}
