using AutoMapper;
using AutoMapper.Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Vidly.Models;

namespace Vidly.App_Start
{
    public class AutoMapperConfiguration : Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<CustomerViewModel, Customers>()
                .ForMember(dest => dest.id, opts => opts.MapFrom(src => src.customer.id))
                .ForMember(dest => dest.Name, opts => opts.MapFrom(src => src.customer.Name))
                .ForMember(dest => dest.BirthDate, opts => opts.MapFrom(src => src.customer.BirthDate))
                .ForMember(dest => dest.MembershipTypeId, opts => opts.MapFrom(src => src.customer.MembershipTypeId))
                .ForMember(dest => dest.IsSubscribedToNewsletter, opts => opts.MapFrom(src => src.customer.IsSubscribedToNewsletter));

          CreateMap<MovieViewModel, Movies>()
                .ForMember(dest => dest.id, opts => opts.MapFrom(src => src.movie.id))
                .ForMember(dest => dest.Name, opts => opts.MapFrom(src => src.movie.Name))
                .ForMember(dest => dest.GenreId, opts => opts.MapFrom(src => src.movie.GenreId))
                .ForMember(dest => dest.ReleasedDate, opts => opts.MapFrom(src => src.movie.ReleasedDate))
                .ForMember(dest => dest.NumberInStock, opts => opts.MapFrom(src => src.movie.NumberInStock))
                .ForMember(dest => dest.DateAdded, opts => opts.MapFrom(src => (object)null));


        }
    }
}