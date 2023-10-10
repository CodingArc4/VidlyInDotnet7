using AutoMapper;
using Vidly.Dtos;
using Vidly.Models;

namespace Vidly.Mappings
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<Customer, CustomerDto>();
            CreateMap<Movie, MovieDto>();
            CreateMap<MembershipType, MembershipDto>();
            CreateMap<Genre, GenreDto>();


            CreateMap<CustomerDto, Customer>();
            CreateMap<MovieDto, Movie>();
        }
    }
}
