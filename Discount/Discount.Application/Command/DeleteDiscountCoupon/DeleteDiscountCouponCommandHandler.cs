using Discount.Application.Messaging;
using Discount.Domain.Dtos;
using Discount.Domain.Repository;
using Discount.Domain.Shared;

namespace Discount.Application.Command.DeleteDiscountCoupon
{
    public class DeleteDiscountCouponCommandHandler : ICommandHandler<DeleteDiscountCouponCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public DeleteDiscountCouponCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<Result> Handle(DeleteDiscountCouponCommand query, CancellationToken cancellationToken)
        {
            if (query.Id <= 0)
            {
                return Result<DiscountDto>.Failure("Id must be greater than 0");
            }
            var discountCoupon = await _unitOfWork.DiscountRepository.GetByIdAsync(query.Id);
            if (discountCoupon == null)
            {
                return Result.Failure("Coupon not found");
            }

            await _unitOfWork.DiscountRepository.DeleteAsync(discountCoupon);
            await _unitOfWork.SaveChangesAsync();

            return Result.Success();
        }
    }
}
