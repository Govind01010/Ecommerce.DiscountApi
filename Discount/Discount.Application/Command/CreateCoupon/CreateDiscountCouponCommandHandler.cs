using Discount.Application.Messaging;
using Discount.Domain.Repository;
using Discount.Domain.Shared;

namespace Discount.Application.Command.CreateCoupon
{
    public class CreateDiscountCouponCommandHandler : ICommandHandler<CreateDiscountCouponCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public CreateDiscountCouponCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public async Task<Result> Handle(CreateDiscountCouponCommand request, CancellationToken cancellationToken)
        {
            // Validate the command
            if (string.IsNullOrEmpty(request.DiscountDto.Code) || request.DiscountDto.Percentage <= 0 || request.DiscountDto.MinimumAmount <= 0)
            {
                return Result.Failure("Invalid coupon data.");
            }

            // Create a new DiscountDto
            var newDiscountCoupon = new Domain.Entities.Discount
            {
                Code = request.DiscountDto.Code,
                Description = request.DiscountDto.Description,
                Percentage = request.DiscountDto.Percentage,
                MinimumAmount = request.DiscountDto.MinimumAmount,
                CreatedAt = DateTime.UtcNow,
                CreatedBy = "Admin",
                IsActive = true
            };

            await _unitOfWork.DiscountRepository.AddAsync(newDiscountCoupon);

            await _unitOfWork.SaveChangesAsync();

            // Return success
            return Result.Success();
        }
    }
}