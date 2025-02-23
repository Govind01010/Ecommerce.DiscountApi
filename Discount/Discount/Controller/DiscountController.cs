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
    [Route("api/discount-coupon")]
    [ApiController]
    public class DiscountController : ControllerBase
    {
        private readonly IMediator _mediator;
        public DiscountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("get-coupon-by-id/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetDiscountCouponById([FromRoute] int id)
        {
            try
            {
                var query = new GetDiscountCouponByIdQuery(id);
                var response = await _mediator.Send(query);
                if (response.IsSuccess)
                {
                    var result = new ResponseDto
                    {
                        isSuccess = true,
                        message = "Successfully Fetched All Discount Coupons",
                        result = response.Value
                    };
                    return Ok(result);
                }
                return NotFound(new ResponseDto { isSuccess = false, message = "Discount coupon not found", result = null });
            }
            catch (Exception ex)
            {
                return NotFound(new ResponseDto { isSuccess = false, message = ex.Message, result = null });
            }
        }

        [HttpGet("get-all-coupons")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetAllDiscountCoupons()
        {
            try
            {
                var query = new GetDiscountCouponsQuery();
                var response = await _mediator.Send(query);
                if (response.IsSuccess)
                {
                    var result = new ResponseDto
                    {
                        isSuccess = true,
                        message = "Successfully Fetched All Discount Coupons",
                        result = response.Value
                    };
                    return Ok(result);
                }
                return NotFound(new ResponseDto { isSuccess = false, message = "Discount coupon not found", result = null });
            }
            catch (Exception ex)
            {
                return NotFound(new ResponseDto { isSuccess = false, message = ex.Message, result = null });
            }
        }

        [HttpPost("create-coupon")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> CreateDiscount([FromBody] Domain.Dtos.DiscountDto discountDto)
        {
            try
            {
                var request = new CreateDiscountCouponCommand(discountDto);
                var response = await _mediator.Send(request);
                if (response.IsSuccess)
                {
                    var result = new ResponseDto
                    {
                        isSuccess = true,
                        message = "Successfully Create Discount Coupons"
                    };
                }
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseDto { isSuccess = false, message = ex.Message, result = null });
            }
        }

        [HttpPut("update-coupon")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> UpdateDiscount([FromBody] DiscountDto coupon)
        {
            try
            {
                var request = new UpdateDiscountCouponCommand(coupon);
                var response = await _mediator.Send(request);
                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseDto { isSuccess = false, message = ex.Message, result = null });
            }
        }

        [HttpDelete("delete-coupon/{id}")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<IActionResult> DeleteDiscount([FromRoute] int id)
        {
            try
            {
                var request = new DeleteDiscountCouponCommand(id);
                var response = await _mediator.Send(request);
                if (response.IsSuccess)
                {
                    var result = new ResponseDto
                    {
                        isSuccess = true,
                        message = "Successfully deleted discount coupon",
                        result = null
                    };
                    return Ok(result);
                }
                return BadRequest(new ResponseDto { isSuccess = false, message = response.ErrorMessage, result = null });
            }
            catch (Exception ex)
            {
                return BadRequest(new ResponseDto { isSuccess = false, message = ex.Message, result = null });
            }
        }
    }
}
