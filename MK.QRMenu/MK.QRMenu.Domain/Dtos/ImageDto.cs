using Microsoft.AspNetCore.Http;

namespace MK.QRMenu.Domain.Dtos
{
    public sealed class ImageDto
    {
        public IFormFile? Image {  get; set; }
    }
}
