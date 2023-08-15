using Api.DTOs;
using Api.Models;
using AutoMapper;

namespace Api.Utils.Profiles
{
  public class CategoryProfile : Profile
  {
    public CategoryProfile() 
    {
      CreateMap<CategoryForCreationDto, Category>();
    }
  }
}
