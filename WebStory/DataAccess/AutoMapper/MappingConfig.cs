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

                config.CreateMap<Story, StoryDTO>()
                     .ForMember(dest => dest.ListOfCategory, opt => opt.MapFrom(src => MapStoryCategoryToDto(src.StoryCategories)))
                     .ForMember(dest => dest.ListOfChapter, opt => opt.MapFrom(src => MapChapterToDto(src.Chapters)))
                     .ReverseMap();

                config.CreateMap<Chapter, ChapterDTO>()
                     .ForMember(dest => dest.ListOfImage, opt => opt.MapFrom(src => MapImageToDto(src.Images)))
                     .ReverseMap();


            });
            return mappingConfig;
        }
        private static List<CategoryDTO> MapStoryCategoryToDto(ICollection<StoryCategory> storyCategories)
        {
            var listOfCategory = new List<CategoryDTO>();

            foreach (var storyCategory in storyCategories)
            {
                var chapterDto = new CategoryDTO
                {
                    CategoryId = storyCategory.CategoryId,
                    CategoryName = storyCategory.Category.CategoryName
                };
                listOfCategory.Add(chapterDto);
            }

            return listOfCategory;
        }
        private static List<ChapterDTO> MapChapterToDto(ICollection<Chapter> chapters)
        {
            var listOfChapter = new List<ChapterDTO>();

            foreach (var chapter in chapters)
            {
                var listOfImageDto = new List<ImageDTO>();
                foreach (var image in chapter.Images)
                {
                    var imageDto = new ImageDTO
                    {
                        ChapterId = image.ChapterId,
                        Index = image.Index,
                        ImageChapter = image.ImageChapter
                    };

                    listOfImageDto.Add(imageDto);
                }
                var chapterDto = new ChapterDTO
                {
                    ChapterId = chapter.ChapterId,
                    Index = chapter.Index,
                    View = chapter.View,
                    CreateAt = chapter.CreateAt,
                    StoryId = chapter.StoryId,
                    ListOfImage = listOfImageDto
                };
                listOfChapter.Add(chapterDto);
            }

            return listOfChapter;
        }
        private static List<ImageDTO> MapImageToDto(ICollection<Image> images)
        {
            var listOfImage = new List<ImageDTO>();

            foreach (var image in images)
            {
                var chapterDto = new ImageDTO
                {
                    ImageId = image.ImageId,
                    Index = image.Index,
                    ImageChapter = image.ImageChapter,
                    ChapterId = image.ChapterId
                };
                listOfImage.Add(chapterDto);
            }

            return listOfImage;
        }
    }
}
