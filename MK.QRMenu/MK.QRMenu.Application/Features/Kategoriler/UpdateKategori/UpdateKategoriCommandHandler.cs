using AutoMapper;
using GenericRepository;
using MediatR;
using Microsoft.AspNetCore.Http;
using MK.QRMenu.Application.Features.Kategoriler.CreateKategori;
using MK.QRMenu.Domain.Entities;
using MK.QRMenu.Domain.Repositories;
using TS.Result;

namespace MK.QRMenu.Application.Features.Kategoriler.UpdateKategori
{
    internal sealed class UpdateKategoriCommandHandler(
        IKategoriRepository kategoriRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IHttpContextAccessor httpContextAccessor) : IRequestHandler<UpdateKategoriCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(UpdateKategoriCommand request, CancellationToken cancellationToken)
        {
            var userId = httpContextAccessor.HttpContext.User?.Claims.Select(f => f.Value).FirstOrDefault();
            //
            Kategori model = await kategoriRepository.GetByExpressionWithTrackingAsync(f => f.Id == request.Id && !f.IsDeleted);
            //
            if(model is null)
            {
                return Result<string>.Failure("Kategori Bulunamadı.");
            }
            //
            mapper.Map(request, model);
            //
            model.UpdateBy = new Guid(userId ?? "");
            model.UpdateDate = DateTime.Now;
            //
            await unitOfWork.SaveChangesAsync(cancellationToken);
            //
            return "Kategori Başarıyla Güncellendi.";
        }
    }
}
