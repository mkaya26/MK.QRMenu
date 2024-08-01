using MediatR;
using TS.Result;

namespace MK.QRMenu.Application.Features.Kampanyalar.DeleteKampanyaById
{
    public sealed record DeleteKampanyaByIdCommand(
        Guid Id) : IRequest<Result<string>>;
}
