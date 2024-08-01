using MK.QRMenu.Domain.Abstractions;

namespace MK.QRMenu.Domain.Entities
{
    public sealed class Kampanya : Entity
    {
        public string? Title { get; set; }
        public string? Description { get; set; }
        public string? ImageUrl { get; set; }
        public string? LinkUrl { get; set; }
    }
}
