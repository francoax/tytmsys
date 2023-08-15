using Api.DTOs;
using Api.Models;
using AutoMapper;

namespace Api.Utils.Profiles
{
  public class SupplierProfile : Profile
  {
    public SupplierProfile()
    {
      CreateMap<SupplierForCreationDto, Supplier>();
    }
  }
}
