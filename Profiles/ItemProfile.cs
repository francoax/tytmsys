using Api.Dto;
using Api.Models;
using AutoMapper;

namespace Api.Profiles
{
  public class ItemProfile : Profile
  {
    public ItemProfile() 
    {
      CreateMap<ItemForCreationDto, ItemModel>();
    }
  }
}
