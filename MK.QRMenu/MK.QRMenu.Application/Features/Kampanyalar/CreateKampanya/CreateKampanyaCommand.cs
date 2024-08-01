using MediatR;
using Microsoft.AspNetCore.Http;
using TS.Result;

namespace MK.QRMenu.Application.Features.Kampanyalar.CreateKampanya
{
    public sealed record CreateKampanyaCommand(
        string? Title,
        string? Description,
        string? LinkUrl,
        IFormFile Image) : IRequest<Result<string>>;
}
