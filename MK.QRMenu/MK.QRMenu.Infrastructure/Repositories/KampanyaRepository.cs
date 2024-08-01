using GenericRepository;
using MK.QRMenu.Domain.Entities;
using MK.QRMenu.Domain.Repositories;
using MK.QRMenu.Infrastructure.Context;

namespace MK.QRMenu.Infrastructure.Repositories
{
    internal sealed class KampanyaRepository : Repository<Kampanya, ApplicationDbContext>, IKampanyaRepository
    {
        public KampanyaRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
