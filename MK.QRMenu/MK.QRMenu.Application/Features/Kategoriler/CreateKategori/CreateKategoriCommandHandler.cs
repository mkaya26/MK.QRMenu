using AutoMapper;
using GenericRepository;
using MediatR;
using Microsoft.AspNetCore.Http;
using MK.QRMenu.Domain.Entities;
using MK.QRMenu.Domain.Repositories;
using TS.Result;

namespace MK.QRMenu.Application.Features.Kategoriler.CreateKategori
{
    internal sealed class CreateKategoriCommandHandler(
        IKategoriRepository kategoriRepository,
        IUnitOfWork unitOfWork,
        IMapper mapper,
        IHttpContextAccessor httpContextAccessor) : IRequestHandler<CreateKategoriCommand, Result<string>>
    {
        public async Task<Result<string>> Handle(CreateKategoriCommand request, CancellationToken cancellationToken)
        {
            var userId = httpContextAccessor.HttpContext.User?.Claims.Select(f => f.Value).FirstOrDefault();
            //
            Kategori kategori = mapper.Map<Kategori>(request);
            //
            kategori.CreateBy = new Guid(userId ?? "");
            kategori.CreateDate = DateTime.Now;
            //
            await kategoriRepository.AddAsync(kategori, cancellationToken);
            await unitOfWork.SaveChangesAsync(cancellationToken);
            //
            return "Kategori Başarıyla Eklendi.";
        }
    }
}
