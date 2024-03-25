using System;
using AutoMapper;
using DataAccess.Models;
using ObjectModel.Dtos;
using StoryAPI.Models;

namespace DataAccess.AutoMapper
{
    public class MappingConfig
    {
        public static MapperConfiguration RegisterMaps()
        {
            var mappingConfig = new MapperConfiguration(config =>
            {
                config.CreateMap<Category, CategoryDTO>();
                config.CreateMap<CategoryDTO, Category>();
                config.CreateMap<User, UserDTO>();
                config.CreateMap<UserDTO, User>();
                config.CreateMap<Story, StoryDTO>()
                      .ForMember(dest => dest.StoryId, opt => opt.MapFrom(src => src.StoryId))
                      .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                      .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.AuthorName))
                      .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Content))
                      .ForMember(dest => dest.View, opt => opt.MapFrom(src => src.View))
                      .ForMember(dest => dest.CreateAt, opt => opt.MapFrom(src => src.CreateAt))
                      .ForMember(dest => dest.ImageStory, opt => opt.MapFrom(src => src.ImageStory))
                      .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
                      .ForMember(dest => dest.ListOfCategory, opt => opt.MapFrom(src => MapStoryCategoryToDto(src.StoryCategories)))
                      .ForMember(dest => dest.ListOfChapter, opt => opt.MapFrom(src => MapChapterToDto(src.Chapters)));
                config.CreateMap<StoryDTO, Story>()
                      .ForMember(dest => dest.StoryId, opt => opt.MapFrom(src => src.StoryId))
                      .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                      .ForMember(dest => dest.AuthorName, opt => opt.MapFrom(src => src.AuthorName))
                      .ForMember(dest => dest.Content, opt => opt.MapFrom(src => src.Content))
                      .ForMember(dest => dest.View, opt => opt.MapFrom(src => src.View))
                      .ForMember(dest => dest.CreateAt, opt => opt.MapFrom(src => src.CreateAt))
                      .ForMember(dest => dest.ImageStory, opt => opt.MapFrom(src => src.ImageStory))
                      .ForMember(dest => dest.IsActive, opt => opt.MapFrom(src => src.IsActive))
                      .ForMember(dest => dest.StoryCategories, opt => opt.MapFrom(src => MapDtoToStoryCategory(src.ListOfCategory, src.StoryId)))
                      .ForMember(dest => dest.Chapters, opt => opt.MapFrom(src => MapDtoToChapter(src.ListOfChapter, src.StoryId)));
                config.CreateMap<Chapter, ChapterDTO>()
                      .ForMember(dest => dest.ChapterId, opt => opt.MapFrom(src => src.ChapterId))
                      .ForMember(dest => dest.Index, opt => opt.MapFrom(src => src.Index))
                      .ForMember(dest => dest.View, opt => opt.MapFrom(src => src.View))
                      .ForMember(dest => dest.CreateAt, opt => opt.MapFrom(src => src.CreateAt))
                      .ForMember(dest => dest.StoryId, opt => opt.MapFrom(src => src.StoryId))
                      .ForMember(dest => dest.ListOfImage, opt => opt.MapFrom(src => MapImageToDto(src.Images)));
                config.CreateMap<ChapterDTO, Chapter>()
                      .ForMember(dest => dest.ChapterId, opt => opt.MapFrom(src => src.ChapterId))
                      .ForMember(dest => dest.Index, opt => opt.MapFrom(src => src.Index))
                      .ForMember(dest => dest.View, opt => opt.MapFrom(src => src.View))
                      .ForMember(dest => dest.CreateAt, opt => opt.MapFrom(src => src.CreateAt))
                      .ForMember(dest => dest.StoryId, opt => opt.MapFrom(src => src.StoryId))
                      .ForMember(dest => dest.Images, opt => opt.MapFrom(src => MapDtoToImage(src.ListOfImage)));

                config.CreateMap<Comment, CommentDTO>()
                    .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName))
                    .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.User.ImageUser));

                config.CreateMap<Comment, ReplyDTO>()
                    .ForMember(dest => dest.UserName, opt => opt.MapFrom(src => src.User.UserName))
                    .ForMember(dest => dest.Image, opt => opt.MapFrom(src => src.User.ImageUser)); ;
                config.CreateMap<Favourite, AddFavouriteDTO>().ReverseMap();
                config.CreateMap<Comment, AddCommentDTO>().ReverseMap();
                config.CreateMap<Favourite, FavouriteDTO>().ForMember(dest => dest.UserDTO, opt => opt.MapFrom(src => src.User))
                .ForMember(dest => dest.StoryDTO, opt => opt.MapFrom(src => src.Story));
                config.CreateMap<FavouriteDTO, Favourite>().ForMember(dest => dest.User, opt => opt.MapFrom(src => src.UserDTO))
                .ForMember(dest => dest.Story, opt => opt.MapFrom(src => src.StoryDTO));
            });

            return mappingConfig;
        }

        private static ICollection<StoryCategory> MapDtoToStoryCategory(List<CategoryDTO>? listOfCategory, int storyId)
        {
            var categories = new List<StoryCategory>();

            foreach (var categoryDto in listOfCategory)
            {
                var category = new StoryCategory
                {
                    CategoryId = categoryDto.CategoryId,
                    StoryId = storyId
                };

                categories.Add(category);
            }
            return categories;
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

        private static ICollection<Chapter> MapDtoToChapter(List<ChapterDTO> listOfChapter, int storyId)
        {
            var chapters = new List<Chapter>();

            foreach (var chapterDto in listOfChapter)
            {
                var listOfImage = new List<Image>();
                foreach (var imageDto in chapterDto.ListOfImage)
                {
                    var image = new Image
                    {
                        ChapterId = chapterDto.ChapterId,
                        Index = imageDto.Index,
                        ImageChapter = imageDto.ImageChapter
                    };

                    listOfImage.Add(image);
                }
                var chapter = new Chapter
                {
                    ChapterId = chapterDto.ChapterId,
                    Index = chapterDto.Index,
                    View = chapterDto.View,
                    CreateAt = chapterDto.CreateAt,
                    StoryId = storyId,
                    Images = listOfImage
                };

                chapters.Add(chapter);
            }

            return chapters;
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

        private static ICollection<Image> MapDtoToImage(List<ImageDTO> listOfImage)
        {
            var images = new List<Image>();

            foreach (var imageDto in listOfImage)
            {
                var chapter = new Image
                {
                    ImageId = imageDto.ImageId,
                    Index = imageDto.Index,
                    ImageChapter = imageDto.ImageChapter,
                    ChapterId = imageDto.ChapterId
                };

                images.Add(chapter);
            }

            return images;
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

