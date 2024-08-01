using GenericRepository;
using MediatR;
using Microsoft.AspNetCore.Http;
using MK.QRMenu.Application.Services;
using MK.QRMenu.Domain.Entities;
using MK.QRMenu.Domain.Repositories;
using TS.Result;

namespace MK.QRMenu.Application.Features.Kampanyalar.CreateKampanya
{
    internal sealed class CreateKampanyaCommandHandler(
        IKampanyaRepository kampanyaRepository,
        IUnitOfWork unitOfWork,
        IFtpService ftpService,
        IHttpContextAccessor httpContextAccessor) : IRequestHandler<CreateKampanyaCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(CreateKampanyaCommand request, CancellationToken cancellationToken)
        {
            var userId = httpContextAccessor.HttpContext.User?.Claims.Select(f => f.Value).FirstOrDefault();
            //
            if(request.Image is null)
            {
                return Result<string>.Failure("Kampanya Resmi Zorunludur.");
            }
            //
            string imageUrl = await ftpService.UploadFileAsync(request.Image, "products");
            //
            Kampanya kampanya = new Kampanya
            {
                Title = request.Title,
                Description = request.Description,
                LinkUrl = request.LinkUrl,
                ImageUrl = imageUrl,
                CreateBy = new Guid(userId ?? ""),
                CreateDate = DateTime.Now
            };
            //
            await kampanyaRepository.AddAsync(kampanya, cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            //
            return "Kampanya başarıyla kaydedildi.";
        }
    }
}
