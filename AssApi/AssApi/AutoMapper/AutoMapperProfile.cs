using AssApi.Dtos;
using AssApi.Models;
using AutoMapper;

namespace AssApi.AutoMapper
{
    public class AutoMapperProfile :Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<Person, GetPersonDto>().ReverseMap();
            CreateMap<Person,AddPersonDto>().ReverseMap();
        }

    }
}
