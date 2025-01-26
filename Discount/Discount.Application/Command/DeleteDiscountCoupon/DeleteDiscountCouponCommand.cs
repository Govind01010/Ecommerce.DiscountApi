using Discount.Application.Messaging;

namespace Discount.Application.Command.DeleteDiscountCoupon
{
    public sealed record DeleteDiscountCouponCommand(
        int Id) : ICommand;
}
