using Discount.Application.Messaging;
using Discount.Domain.Dtos;

namespace Discount.Application.Command.CreateCoupon
{
    public sealed record CreateDiscountCouponCommand(
       DiscountDto DiscountDto) : ICommand;
}
