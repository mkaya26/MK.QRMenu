using GenericRepository;
using MK.QRMenu.Domain.Entities;
using MK.QRMenu.Domain.Repositories;
using MK.QRMenu.Infrastructure.Context;

namespace MK.QRMenu.Infrastructure.Repositories
{
    internal sealed class KategoriRepository : Repository<Kategori, ApplicationDbContext>, IKategoriRepository
    {
        public KategoriRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
