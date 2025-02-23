using AutoMapper;
using Discount.Application.Messaging;
using Discount.Domain.Dtos;
using Discount.Domain.Repository;
using Discount.Domain.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Discount.Application.Query.GetDiscountCouponById
{
    public class GetDiscountCouponByIdQueryHandler:IQueryHandler<GetDiscountCouponByIdQuery,DiscountDto>
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;
        public GetDiscountCouponByIdQueryHandler(IUnitOfWork unitOfWork,IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task<Result<DiscountDto>> Handle(GetDiscountCouponByIdQuery query,CancellationToken cancellationToken)
        {
            if(query.Id <= 0)
            {
                return Result<DiscountDto>.Failure("Id must be greater than 0");
            }
            var discountCoupon = await _unitOfWork.DiscountRepository.GetByIdAsync(query.Id);
            if (discountCoupon == null)
            {
                return Result<DiscountDto>.Failure("Coupon not found");
            }
            
            var result = _mapper.Map<DiscountDto>(discountCoupon);

            return Result<DiscountDto>.Success(result);
        }
    }
}
