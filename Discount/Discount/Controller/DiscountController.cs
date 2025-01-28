using Discount.Application.Command.CreateCoupon;
using Discount.Application.Command.DeleteDiscountCoupon;
using Discount.Application.Command.UpdateDiscountCoupon;
using Discount.Application.Query.GetDiscountCouponById;
using Discount.Application.Query.GetDiscountCoupons;
using Discount.Domain.Dtos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Discount.Controller
{
    [Route("api/Discount")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DiscountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("GetDiscountCouponById/{discountCouponId}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetDiscountCouponById([FromRoute] int discountCouponId)
        {
            var query = new GetDiscountCouponByIdQuery(discountCouponId);
            var response = await _mediator.Send(query);
            return Ok(response);
        }

        [HttpGet("GetAllDiscountCoupons")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllDiscountCoupons()
        {
            var query = new GetDiscountCouponsQuery();
            var response = await _mediator.Send(query);
            return Ok(response);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateDiscount([FromBody] Domain.Dtos.DiscountDto discountDto)
        {
            var request = new CreateDiscountCouponCommand(discountDto);
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpPut]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateDiscount([FromBody] DiscountDto coupon)
        {
            var request = new UpdateDiscountCouponCommand(coupon);
            var response = await _mediator.Send(request);
            return Ok(response);
        }

        [HttpDelete("DeleteDiscount/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteDiscount([FromRoute]int id)
        {
            var request = new DeleteDiscountCouponCommand(id);
            var response = await _mediator.Send(request);
            return Ok();
        }
    }
}
