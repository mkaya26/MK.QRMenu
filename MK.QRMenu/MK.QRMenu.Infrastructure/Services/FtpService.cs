using FluentFTP;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using MK.QRMenu.Application.Services;

namespace MK.QRMenu.Infrastructure.Services
{
    public class FtpService : IFtpService
    {
        private readonly string? _ftpHost;
        private readonly string? _ftpUser;
        private readonly string? _ftpPassword;

        public FtpService(IConfiguration configuration)
        {
            _ftpHost = configuration["FtpSettings:Host"];
            _ftpUser = configuration["FtpSettings:User"];
            _ftpPassword = configuration["FtpSettings:Password"];
        }

        public async Task<bool> DeleteFileAsync(string remoteFilePath)
        {
            try
            {
                using (var ftpClient = new FtpClient(_ftpHost, _ftpUser, _ftpPassword, 21))
                {
                    ftpClient.Config.DataConnectionType = FtpDataConnectionType.PASV;

                    // Bağlan
                    await Task.Run(() => ftpClient.Connect());

                    // Dosyayı sil
                    await Task.Run(() => ftpClient.DeleteFile(remoteFilePath));

                    return true; // Başarılı olduysa true döndür
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error deleting file: {ex.Message}");
                return false; // Hata durumunda false döndür
            }
        }

        public async Task<string> UploadFileAsync(IFormFile file, string folder)
        {
            try
            {
                var fileFormat = Path.GetExtension(file.FileName).ToLower();
                string fileName = Guid.NewGuid().ToString() + fileFormat;
                string remotePath = $"{folder}/{fileName}";

                using (var ftpClient = new FtpClient(_ftpHost, _ftpUser, _ftpPassword,21))
                {
                    ftpClient.Config.DataConnectionType = FtpDataConnectionType.PASV;
                    //
                    ftpClient.Connect();

                    using (var tempStream = new MemoryStream())
                    {
                        await file.CopyToAsync(tempStream);
                        tempStream.Position = 0; 
                        ftpClient.UploadStream(tempStream, remotePath, FtpRemoteExists.Overwrite);
                    }

                    return remotePath;
                }
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }
    }
}
