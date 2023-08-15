using Api.DTOs;
using Api.Models;
using AutoMapper;

namespace Api.Utils.Profiles
{
  public class ItemProfile : Profile
  {
    public ItemProfile()
    {
      CreateMap<ItemForCreationDto, Item>();
    }
  }
}
