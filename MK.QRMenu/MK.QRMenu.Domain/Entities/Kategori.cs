using MK.QRMenu.Domain.Abstractions;

namespace MK.QRMenu.Domain.Entities
{
    public sealed class Kategori : Entity
    {
        public string KategoriAdi { get; set; } = string.Empty;
        public Guid? UstKategoriId { get; set; }
        public string? ArkaPlanRengi { get; set; }
        public string? YaziRengi { get; set; }

    }
}
