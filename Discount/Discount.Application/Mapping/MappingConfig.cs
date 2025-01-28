using AutoMapper;
using Discount.Application.Command.UpdateDiscountCoupon;
using Discount.Domain.Dtos;

namespace Discount.Application.Mapping
{
    public class MappingConfig:Profile
    {
        public MappingConfig()
        {
          CreateMap<Domain.Entities.Discount, DiscountDto>().ReverseMap();
        }
    }
}
