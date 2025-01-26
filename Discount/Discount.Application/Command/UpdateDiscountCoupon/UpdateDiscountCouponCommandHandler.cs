using AutoMapper;
using Discount.Application.Messaging;
using Discount.Domain.Dtos;
using Discount.Domain.Repository;
using Discount.Domain.Shared;

namespace Discount.Application.Command.UpdateDiscountCoupon;

public class UpdateDiscountCouponCommandHandler : ICommandHandler<UpdateDiscountCouponCommand, DiscountDto>
{
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    public UpdateDiscountCouponCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
    {
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }

    public async Task<Result<DiscountDto>> Handle(UpdateDiscountCouponCommand request, CancellationToken cancellationToken)
    {
        if (request.DiscountDto.Id<= 0)
        {
            return Result<DiscountDto>.Failure("Id must be greater than 0");
        }
        else if (request.DiscountDto.Percentage < 0 || request.DiscountDto.Percentage > 100)
        {
            return Result<DiscountDto>.Failure("Percentage must be between 0 and 100");
        }
        else if (request.DiscountDto.MinimumAmount < 0)
        {
            return Result<DiscountDto>.Failure("Minimum amount must be greater than 0");
        }
        var discountCoupon = await _unitOfWork.DiscountRepository.GetByIdAsync(request.DiscountDto.Id);
        if (discountCoupon == null)
        {
            return Result<DiscountDto>.Failure("Coupon not found");
        }

        _mapper.Map(request.DiscountDto, discountCoupon);
        await _unitOfWork.DiscountRepository.UpdateAsync(discountCoupon);
        await _unitOfWork.SaveChangesAsync();

        return Result<DiscountDto>.Success(_mapper.Map<DiscountDto>(discountCoupon));
    }
}