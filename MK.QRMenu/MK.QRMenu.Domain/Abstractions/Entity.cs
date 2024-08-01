namespace MK.QRMenu.Domain.Abstractions
{
    public abstract class Entity
    {
        public Guid Id { get; set; }
        public Guid CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public Guid? UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public bool IsDeleted { get; set; }
        public Guid? DeleleteBy { get; set; }
        public DateTime? DeleteDate { get; set; }
        protected Entity()
        {
            Id = Guid.NewGuid();
        }
    }
}
