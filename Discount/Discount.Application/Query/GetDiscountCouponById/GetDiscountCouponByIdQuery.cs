using Discount.Application.Messaging;
using Discount.Domain.Dtos;

namespace Discount.Application.Query.GetDiscountCouponById;

public sealed record GetDiscountCouponByIdQuery(
    int Id) : IQuery<DiscountDto>;
