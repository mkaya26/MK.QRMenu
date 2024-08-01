using GenericRepository;
using MediatR;
using Microsoft.AspNetCore.Http;
using MK.QRMenu.Application.Features.Kampanyalar.CreateKampanya;
using MK.QRMenu.Application.Services;
using MK.QRMenu.Domain.Entities;
using MK.QRMenu.Domain.Repositories;
using TS.Result;

namespace MK.QRMenu.Application.Features.Kampanyalar.DeleteKampanyaById
{
    internal sealed class DeleteKampanyaByIdCommandHandler(
        IKampanyaRepository kampanyaRepository,
        IUnitOfWork unitOfWork,
        IFtpService ftpService,
        IHttpContextAccessor httpContextAccessor) : IRequestHandler<DeleteKampanyaByIdCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(DeleteKampanyaByIdCommand request, CancellationToken cancellationToken)
        {
            var userId = httpContextAccessor.HttpContext.User?.Claims.Select(f => f.Value).FirstOrDefault();
            //
            Kampanya kampanya = await kampanyaRepository.GetByExpressionWithTrackingAsync(f => f.Id == request.Id, cancellationToken);
            //
            if(kampanya is null)
            {
                return Result<string>.Failure("Kampanya Bulunamadı.");
            }
            //
            kampanya.IsDeleted = true;
            kampanya.DeleleteBy = new Guid(userId ?? "");
            kampanya.DeleteDate = DateTime.Now;
            //
            await unitOfWork.SaveChangesAsync(cancellationToken);
            //
            if (kampanya.ImageUrl != null)
            {
                await ftpService.DeleteFileAsync(kampanya.ImageUrl);
            }
            //
            return "Kampanya Başarıyla Silindi.";
        }
    }
}
