using MediatR;
using Microsoft.AspNetCore.Mvc;
using MK.QRMenu.Application.Features.Kampanyalar.CreateKampanya;
using MK.QRMenu.Application.Features.Kampanyalar.DeleteKampanyaById;
using MK.QRMenu.Application.Features.Kampanyalar.GetAllKampanya;
using MK.QRMenu.WebAPI.Abstractions;

namespace MK.QRMenu.WebAPI.Controllers
{
    public class KampanyaController : ApiController
    {
        public KampanyaController(IMediator mediator) : base(mediator)
        {
        }
        [HttpPost]
        public async Task<IActionResult> GetAll(GetAllKampanyaQuery request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] CreateKampanyaCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteById(DeleteKampanyaByIdCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
    }
}
