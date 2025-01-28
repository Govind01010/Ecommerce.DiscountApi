using AutoMapper;
using Discount.Application.Messaging;
using Discount.Application.Query.GetDiscountCouponById;
using Discount.Domain.Dtos;
using Discount.Domain.Repository;
using Discount.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Application.Query.GetDiscountCoupons
{
    public class GetDiscountCouponsQueryHandler : IQueryHandler<GetDiscountCouponsQuery, IEnumerable<DiscountDto>>
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public GetDiscountCouponsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Result<IEnumerable<DiscountDto>>> Handle(GetDiscountCouponsQuery query, CancellationToken cancellationToken)
        {
            var discountCoupons = await _unitOfWork.DiscountRepository.GetAllAsync();
            if (discountCoupons == null)
            {
                return Result<IEnumerable<DiscountDto>>.Failure("Coupon not found");
            }

            var result = _mapper.Map<IEnumerable<DiscountDto>>(discountCoupons);

            return Result<IEnumerable<DiscountDto>>.Success(result);
        }
    }
}