using Api.DTOs.ItemDTOs;
using Api.DTOs.StockMovementDTOs;
using Api.Models;
using AutoMapper;

namespace Api.Utils.Profiles
{
    public class ItemProfile : Profile
  {
    public ItemProfile()
    {
      CreateMap<ItemForCreationDto, Item>();
      CreateMap<ItemForUpdateDto, Item>()
        .ForMember(dest => dest.Suppliers, opt => opt.Ignore());
      CreateMap<ItemSupplierForCreationDto, Supplier>()
        .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.SupplierId));

      CreateMap<Item, ItemDto>()
        .ForMember(dest => dest.Suppliers, opt =>
          opt.MapFrom(src => src.Suppliers.Select(s => $"{s.Name}")))
        .ForMember(dest => dest.Unit, opt =>
          opt.MapFrom(src => $"{src.Unit.Description}"))
        .ForMember(dest => dest.Category, opt =>
          opt.MapFrom(src => $"{src.Category.Name}"));

      CreateMap<StockMovement, StockMovementDto>();
    }
  }
}
