using Discount.Application.Messaging;
using Discount.Domain.Dtos;

namespace Discount.Application.Command.UpdateDiscountCoupon
{
    public sealed record UpdateDiscountCouponCommand(
        DiscountDto DiscountDto) : ICommand<DiscountDto>;
}
