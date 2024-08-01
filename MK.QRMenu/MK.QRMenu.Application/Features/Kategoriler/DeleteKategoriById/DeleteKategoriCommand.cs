using MediatR;
using TS.Result;

namespace MK.QRMenu.Application.Features.Kategoriler.DeleteKategoriById
{
    public sealed record DeleteKategoriCommand(
        Guid Id) : IRequest<Result<string>>;
}
