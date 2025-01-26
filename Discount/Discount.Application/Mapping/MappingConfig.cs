using AutoMapper;
using Discount.Application.Command.UpdateDiscountCoupon;
using Discount.Domain.Dtos;

namespace Discount.Application.Mapping
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<Domain.Entities.Discount, DiscountDto>().ReverseMap();
            });
            return mappingConfig;
        }
    }
}
