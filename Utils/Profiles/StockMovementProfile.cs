using Api.DTOs;
using Api.Models;
using AutoMapper;

namespace Api.Utils.Profiles
{
  public class StockMovementProfile : Profile
  {
    public StockMovementProfile() 
    {
      CreateMap<StockMovementForCreationDto, StockMovement>();
    }
  }
}
