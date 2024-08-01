using MediatR;
using Microsoft.AspNetCore.Mvc;
using MK.QRMenu.Application.Features.Kategoriler.CreateKategori;
using MK.QRMenu.Application.Features.Kategoriler.DeleteKategoriById;
using MK.QRMenu.Application.Features.Kategoriler.GetAllAltKategori;
using MK.QRMenu.Application.Features.Kategoriler.GetAllKategori;
using MK.QRMenu.Application.Features.Kategoriler.UpdateKategori;
using MK.QRMenu.WebAPI.Abstractions;

namespace MK.QRMenu.WebAPI.Controllers
{
    public class KategoriController : ApiController
    {
        public KategoriController(IMediator mediator) : base(mediator)
        {
        }

        [HttpPost]
        public async Task<IActionResult> GetAll(GetAllKategoriQuery request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
        [HttpPost]
        public async Task<IActionResult> GetAllSubs(GetAllAltKategoriQuery request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
        [HttpPost]
        public async Task<IActionResult> Create(CreateKategoriCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
        [HttpPost]
        public async Task<IActionResult> DeleteById(DeleteKategoriCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
        [HttpPost]
        public async Task<IActionResult> Update(UpdateKategoriCommand request, CancellationToken cancellationToken)
        {
            var response = await _mediator.Send(request, cancellationToken);
            return StatusCode(response.StatusCode, response);
        }
    }
}
