using Api.DTOs.StockMovementDTOs;
using Api.Models;
using AutoMapper;

namespace Api.Utils.Profiles
{
    public class StockMovementProfile : Profile
  {
    public StockMovementProfile() 
    {
      CreateMap<StockMovementForDeposit, StockMovement>()
        .ForMember(dest => dest.Action, opt =>
        opt.MapFrom(src => "ingreso"))
        .ForMember(dest => dest.DateOfAction, opt =>
          opt.MapFrom(src => DateTime.UtcNow));

      CreateMap<StockMovementForWithdraw, StockMovement>()
        .ForMember(dest => dest.Action, opt =>
        opt.MapFrom(src => "retiro"))
        .ForMember(dest => dest.State, opt =>
          opt.MapFrom(src => "pendiente"))
        .ForMember(dest => dest.DateOfAction, opt =>
          opt.MapFrom(src => DateTime.UtcNow));

      CreateMap<StockMovementForUpdate, StockMovement>()
        .ForMember(dest => dest.State, opt =>
        opt.MapFrom(src => "confirmado"))
        .ForAllMembers(opts => opts.Condition((src, dest, srcField) => srcField != null));

      CreateMap<StockMovement, StockMovementDto>()
        .ForMember(dest => dest.DateOfAction, opt =>
          opt.MapFrom(src => $"{src.DateOfAction.ToLocalTime()}"
        ));

      CreateMap<StockMovement, StockMovementsDto>()
        .ForMember(dest => dest.ItemId, opt =>
          opt.MapFrom(src => src.Item.Id
        ))
        .ForMember(dest => dest.Item, opt =>
          opt.MapFrom(src => $"{src.Item.Name}"
        ))
        .ForMember(dest => dest.ItemUnit, opt =>
          opt.MapFrom(src => $"{src.Item.Unit.Description}"
        ))
        .ForMember(dest => dest.DateOfAction, opt =>
          opt.MapFrom(src => $"{src.DateOfAction.ToLocalTime()}"
        ));
    }
  }
}
