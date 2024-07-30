using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MK.QRMenu.Application.Services;
using MK.QRMenu.Domain.Dtos;
using MK.QRMenu.Infrastructure.Services;
using MK.QRMenu.WebAPI.Abstractions;

namespace MK.QRMenu.WebAPI.Controllers
{
    [AllowAnonymous]
    public sealed class ImageController : ApiController
    {
        IFtpService ftpService;
        public ImageController(IMediator mediator, IFtpService ftpService) : base(mediator)
        {
            this.ftpService = ftpService;
        }

        [HttpPost]
        public async Task<IActionResult> UploadImage([FromForm] ImageDto imageDto)
        {
            if (imageDto.Image == null || imageDto.Image.Length == 0)
            {
                return BadRequest("No file uploaded.");
            }

            try
            {
                var remotePath = await ftpService.UploadFileAsync(imageDto.Image, "products");
                return Ok(new { FilePath = remotePath });
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
        [HttpPost]
        public async Task<IActionResult> RemoveImage([FromQuery] string removePath)
        {

            try
            {
                var remove = await ftpService.DeleteFileAsync(removePath);
                return Ok(remove);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Internal server error: {ex.Message}");
            }
        }
    }
}
