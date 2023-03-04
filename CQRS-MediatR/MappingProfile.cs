using CQRS_MediatR.DTOs;
using CQRS_MediatR.Models;
using AutoMapper;
using CQRS_MediatR.Commands;

namespace CQRS_MediatR
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Product, ProductDto>().ReverseMap();
        }
    }
}
