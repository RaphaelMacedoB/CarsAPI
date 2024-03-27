using AutoMapper;
using CarsUsingLazyLoad.Data.Dtos;
using CarsUsingLazyLoad.Data.Models;

namespace CarsUsingLazyLoad.Helpers
{
  public class CarsUsingLazyLoadProfile : Profile
  {
    public CarsUsingLazyLoadProfile()
    {
      CreateMap<Car, CarDetail>().ReverseMap();
      CreateMap<Car, CarDto>();
      CreateMap<CarAddDto, Car>()
        .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
      CreateMap<Client, ClientDto>();
      CreateMap<ClientAddDto, Client>();
      CreateMap<ClientAddDto, ClientDto>()
        .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
      CreateMap<Seller, SellerDto>();
      CreateMap<SellerAddDto, SellerDto>()
        .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
      CreateMap<Sale, SaleDto>();
      CreateMap<SaleDto, Sale>();
      CreateMap<SaleAddDto, Sale>()
        .ForAllMembers(opts => opts.Condition((src, dest, srcMember) => srcMember != null));
    }
  }
}
