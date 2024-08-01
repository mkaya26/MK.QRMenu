using MediatR;
using MK.QRMenu.Domain.Entities;
using TS.Result;

namespace MK.QRMenu.Application.Features.Kampanyalar.GetAllKampanya
{
    public sealed record GetAllKampanyaQuery() : IRequest<Result<List<Kampanya>>>;
}
