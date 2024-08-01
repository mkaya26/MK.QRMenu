using GenericRepository;
using MediatR;
using Microsoft.AspNetCore.Http;
using MK.QRMenu.Domain.Entities;
using MK.QRMenu.Domain.Repositories;
using TS.Result;

namespace MK.QRMenu.Application.Features.Kategoriler.DeleteKategoriById
{
    internal sealed class DeleteKategoriCommandHandler(
        IKategoriRepository kategoriRepository,
        IUnitOfWork unitOfWork,
        IHttpContextAccessor httpContextAccessor) : IRequestHandler<DeleteKategoriCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(DeleteKategoriCommand request, CancellationToken cancellationToken)
        {
            var userId = httpContextAccessor.HttpContext.User?.Claims.Select(f => f.Value).FirstOrDefault();
            //
            Kategori model = await kategoriRepository.GetByExpressionWithTrackingAsync(f => f.Id == request.Id && !f.IsDeleted);
            //
            if (model is null)
            {
                return Result<string>.Failure("Kategori Bulunamadı.");
            }
            //
            model.DeleleteBy = new Guid(userId ?? "");
            model.DeleteDate = DateTime.Now;
            model.IsDeleted = true;
            //
            await unitOfWork.SaveChangesAsync(cancellationToken);
            //
            return "Kategori Başarıyla Silindi.";
        }
    }
}
