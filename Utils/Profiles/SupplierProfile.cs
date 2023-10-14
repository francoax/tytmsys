using Api.DTOs.SupplierDTOs;
using Api.Models;
using AutoMapper;

namespace Api.Utils.Profiles
{
    public class SupplierProfile : Profile
  {
    public SupplierProfile()
    {
      CreateMap<SupplierForCreationDto, Supplier>();

      CreateMap<Direction, DirectionDto>()
        .ReverseMap()
        .ForAllMembers(opts => opts.Condition((src, dest, srcField) => srcField != null));

      CreateMap<SupplierForUpdateDto, Supplier>()
        .ForAllMembers(opts => opts.Condition((src, dest, srcField) => srcField != null));

      CreateMap<Supplier, SupplierDto>()
        .ForMember(dest => dest.Items, opt => opt.MapFrom(src => src.Items.Select(i => new ItemSupplier { Id = i.Id, Name = i.Name })));
    }
  }
}
