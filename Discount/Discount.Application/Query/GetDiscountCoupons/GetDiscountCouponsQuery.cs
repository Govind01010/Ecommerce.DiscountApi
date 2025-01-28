using Discount.Application.Messaging;

namespace Discount.Application.Query.GetDiscountCoupons;

public sealed record GetDiscountCouponsQuery() : IQuery<IEnumerable<Domain.Dtos.DiscountDto>>;
