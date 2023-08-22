using Api.DTOs.UnitDTOs;
using Api.Models;
using AutoMapper;

namespace Api.Utils.Profiles
{
    public class UnitProfile : Profile
  {
    public UnitProfile() 
    {
      CreateMap<UnitForCreationDto, Unit>();
    }
  }
}
