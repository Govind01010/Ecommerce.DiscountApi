namespace Discount.Domain.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }

        public DateTime CreatedAt { get; set; } 

        public DateTime? UpdatedAt { get; set; } = null;

        public DateTime? DeletedAt { get; set; } = null;

        public string? CreatedBy { get; set; } = null;

        public string? UpdatedBy { get; set; } = null;

        public string? DeletedBy { get; set; } = null;

    }
}
