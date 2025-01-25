namespace Discount.Domain.Entities
{
    public class Discount:BaseEntity
    {
        public string Code { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public int Percentage { get; set; }

        public int MinimumAmount { get; set; }

        public bool IsActive { get; set; }

    }
}
