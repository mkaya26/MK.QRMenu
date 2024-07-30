using Microsoft.AspNetCore.Http;

namespace MK.QRMenu.Application.Services
{
    public interface IFtpService
    {
        Task<string> UploadFileAsync(IFormFile file, string folder);
        Task<bool> DeleteFileAsync(string remoteFileName);
    }
}
