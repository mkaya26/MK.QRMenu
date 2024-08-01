using AutoMapper;
using MK.QRMenu.Application.Features.Kategoriler.CreateKategori;
using MK.QRMenu.Application.Features.Kategoriler.UpdateKategori;
using MK.QRMenu.Domain.Entities;

namespace MK.QRMenu.Application.Mapping
{
    public sealed class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<CreateKategoriCommand, Kategori>();
            CreateMap<UpdateKategoriCommand, Kategori>();
        }
    }
}
