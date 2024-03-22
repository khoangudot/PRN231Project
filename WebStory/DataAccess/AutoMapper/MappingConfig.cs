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
                config.CreateMap<Category, CategoryDTO>()
                      .ReverseMap();

                config.CreateMap<User, UserDTO>()
                      .ReverseMap();

                config.CreateMap<Story, StoryDTO>().ReverseMap();

                config.CreateMap<Favourite, FavouriteDTO>()
                      .ForMember(dest => dest.UserDTO, opt => opt.MapFrom(src => src.User))
                      .ForMember(dest => dest.StoryDTO, opt => opt.MapFrom(src => src.Story))
                      .ReverseMap();

                config.CreateMap<Favourite, AddFavouriteDTO>()
                      .ReverseMap();

                config.CreateMap<Comment, CommentDTO>()
                   .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName))
                   .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.User.ImageUser));

                config.CreateMap<Comment, ReplyDTO>()
                    .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName))
                    .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.User.ImageUser));

                config.CreateMap<Comment, AddCommentDTO>().ReverseMap();

            });
            return mappingConfig;
        }

    }
}
