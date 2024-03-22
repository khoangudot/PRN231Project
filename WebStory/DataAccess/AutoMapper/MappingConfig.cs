using AutoMapper;
using BussinessObjects.Dtos;
using DataAccess.Entities;

namespace DataAccess.AutoMapper
{
    public class MappingConfig : Profile
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<Category, CategoryDTO>().ReverseMap();
                config.CreateMap<User, UserDTO>().ReverseMap();
               
            });
            return mappingConfig;
        }

    }
}
