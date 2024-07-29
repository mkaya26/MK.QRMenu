using MK.QRMenu.Application.Features.Auth.Login;
using MK.QRMenu.Domain.Entities;

namespace MK.QRMenu.Application.Services
{
    public interface IJwtProvider
    {
        Task<LoginCommandResponse> CreateToken(AppUser user);
    }
}
