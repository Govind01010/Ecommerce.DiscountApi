using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Domain.Dtos
{
    public class DiscountDto
    {
        public int Id { get; set; }
        public string Code { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public int Percentage { get; set; }

        public int MinimumAmount { get; set; }

        public bool IsActive { get; set; }
    }
}
