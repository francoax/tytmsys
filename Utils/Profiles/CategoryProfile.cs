using Api.DTOs.CategoryDTOs;
using Api.Models;
using AutoMapper;

namespace Api.Utils.Profiles
{
    public class CategoryProfile : Profile
  {
    public CategoryProfile() 
    {
      CreateMap<CategoryForCreationDto, Category>();

      CreateMap<Category, CategoryDto>();
    }
  }
}
