using DataAccess.Entities;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Data
{
    public static class SeedingData
    {
        public static void Seeding(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Role>().HasData(
                new Role { RoleId = 1, RoleName = "Admin" },
                new Role { RoleId = 2, RoleName = "User" }
                );

            modelBuilder.Entity<User>().HasData(
                new User { UserId = 1, FullName = "Admin", UserName = "Admin", ImageUser = "https://firebasestorage.googleapis.com/v0/b/fir-react-87033.appspot.com/o/Users%2Fuser_1.jpeg?alt=media", Email = "admin@gmail.com", Password = "admin", IsMale = true, RoleId = 1, IsActive = true },
                new User { UserId = 2, FullName = "User1", UserName = "User1", ImageUser = "https://firebasestorage.googleapis.com/v0/b/fir-react-87033.appspot.com/o/Users%2Fuser_2.jpeg?alt=media", Email = "user1@gmail.com", Password = "12345", IsMale = true, RoleId = 2, IsActive = true },
                new User { UserId = 3, FullName = "User2", UserName = "User2", ImageUser = "https://firebasestorage.googleapis.com/v0/b/fir-react-87033.appspot.com/o/Users%2Fuser_3.jpeg?alt=media", Email = "user2@gmail.com", Password = "12345", IsMale = false, RoleId = 2, IsActive = true },
                new User { UserId = 4, FullName = "User3", UserName = "User3", ImageUser = "https://firebasestorage.googleapis.com/v0/b/fir-react-87033.appspot.com/o/Users%2Fuser_4.jpeg?alt=media", Email = "user3@gmail.com", Password = "12345", IsMale = true, RoleId = 2, IsActive = true },
                new User { UserId = 5, FullName = "User4", UserName = "User4", ImageUser = "https://firebasestorage.googleapis.com/v0/b/fir-react-87033.appspot.com/o/Users%2Fuser_5.jpeg?alt=media", Email = "user4@gmail.com", Password = "12345", IsMale = false, RoleId = 2, IsActive = true },
                new User { UserId = 6, FullName = "User5", UserName = "User5", ImageUser = "https://firebasestorage.googleapis.com/v0/b/fir-react-87033.appspot.com/o/Users%2Fuser_6.jpeg?alt=media", Email = "user5@gmail.com", Password = "12345", IsMale = true, RoleId = 2, IsActive = true },
                new User { UserId = 7, FullName = "User6", UserName = "User6", ImageUser = "https://firebasestorage.googleapis.com/v0/b/fir-react-87033.appspot.com/o/Users%2Fuser_7.jpeg?alt=media", Email = "user6@gmail.com", Password = "12345", IsMale = false, RoleId = 2, IsActive = true },
                new User { UserId = 8, FullName = "User7", UserName = "User7", ImageUser = "https://firebasestorage.googleapis.com/v0/b/fir-react-87033.appspot.com/o/Users%2Fuser_8.jpeg?alt=media", Email = "user7@gmail.com", Password = "12345", IsMale = true, RoleId = 2, IsActive = false }

                );

            modelBuilder.Entity<Story>().HasData(
                new Story
                {
                    StoryId = 1,
                    Title = "One Piece",
                    AuthorName = "Eiichiro Oda",
                    Content = "Greatness, Glory, Gold. A Pirate Named Gold Roger also known as the Pirate King has conquered this all. He was executed with an unknown reason but before he died he had revealed his last word about The legendary Treasure named One Piece which was hidden in the Grand Line. 22 years after his Death, A Pirate named Monkey D. Luffy appeared and has only one Goal, To Become the Next \"Pirate King\" and Find The Treasure \"One Piece\".",
                    View = 0,
                    CreateAt = DateTime.Now,
                    ImageStory = "",
                    IsActive = true
                },
                new Story
                {
                    StoryId = 2,
                    Title = "One Punch Man",
                    AuthorName = "Murata Yuusuke",
                    Content = "imitates the life of an average hero who wins all of his fights with only one punch! This is why he is called Onepunch man Manga. This story takes place in the fictional Z-City. The world is full of mysterious beings, villains and monsters that cause destruction and havoc. An association of heroes has been established to protect the citizens from all harms and enemies. People with superhuman ability can register themselves with the association that protects citizens.",
                    View = 0,
                    CreateAt = DateTime.Now,
                    ImageStory = "",
                    IsActive = true
                },
                new Story
                {
                    StoryId = 3,
                    Title = "I Returned as an FFF-Class Witch",
                    AuthorName = "Dian Hui Kuang",
                    Content = "Once it starts up, the dungeon goes through a process called “Reset the Next User”. Why doesn’t this reset process apply to me ?!I am the only one left from that endless reset of this dungeon. With simple skills and an overwhelming weapon, Jung-down game starts inside the dungeon",
                    View = 0,
                    CreateAt = DateTime.Now,
                    ImageStory = "",
                    IsActive = true
                },
                new Story
                {
                    StoryId = 4,
                    Title = "Solo Leveling",
                    AuthorName = "Jang Sung-Lak",
                    Content = "",
                    View = 0,
                    CreateAt = DateTime.Now,
                    ImageStory = "",
                    IsActive = true
                },
                new Story
                {
                    StoryId = 5,
                    Title = "Chainsaw Man",
                    AuthorName = "Fujimono Tatsuki",
                    Content = "There's a new hero in town and he's got a bad attitude and a chainsaw dog demon! A dangerous combo.",
                    View = 0,
                    CreateAt = DateTime.Now,
                    ImageStory = "",
                    IsActive = true
                },
                new Story
                {
                    StoryId = 6,
                    Title = "Spy x Family",
                    AuthorName = "Endou Tatsuya",
                    Content = "The master spy codenamed has spent his days on undercover missions, all for the dream of a better world. But one day, he receives a particularly difficult new order from command. For his mission, he must form a temporary family and start a new life?! A Spy/Action/Comedy about a one-of-a-kind family!",
                    View = 0,
                    CreateAt = DateTime.Now,
                    ImageStory = "",
                    IsActive = true
                },
                new Story
                {
                    StoryId = 7,
                    Title = "Kingdom",
                    AuthorName = "Hara Yasushia",
                    Content = "Millions of years have passed since the times of legends, when the worlds of man and gods were still the same. In these times it was the desires of man that moved the world. It is the era of the 500 year war: The warring states period. Kingdom is the story of a young boy named Shin who grew into a great general and all the trials and bloodshed that lead him there.",
                    View = 0,
                    CreateAt = DateTime.Now,
                    ImageStory = "",
                    IsActive = true
                },
                new Story
                {
                    StoryId = 8,
                    Title = "Bleach",
                    AuthorName = "Kisimoto Masashi",
                    Content = "Ichigo Kurosaki has always been able to see ghosts, but this ability doesn't change his life nearly as much as his close encounter with Rukia Kuchiki, a soul reaper and member of the mysterious Soul Society. While fighting a hollow, an evil spirit that preys on humans who display spiritual energy, Rukia attempts to lend Ichigo some of her powers so that he can save his family; but much to her surprise, Ichigo absorbs every last drop of her energy.",
                    View = 0,
                    CreateAt = DateTime.Now,
                    ImageStory = "",
                    IsActive = true
                },
                new Story
                {
                    StoryId = 9,
                    Title = "Dragon Ball Super",
                    AuthorName = "Toriyama Akira",
                    Content = "Son Goku's adventure starts with Bulma crashing into to him while she is searching for the seven magical Dragon Balls, which can grant any wish. Together, they meet many people and many foes in their adventure chasing after the Dragon Balls.",
                    View = 0,
                    CreateAt = DateTime.Now,
                    ImageStory = "",
                    IsActive = true
                },
                new Story
                {
                    StoryId = 10,
                    Title = "Gintama",
                    AuthorName = "Hieaki Sorachi",
                    Content = "The samurai didn't stand a chance. First, the aliens invaded Japan. Next, they took all the jobs. And then they confiscated everyone's swords. So what does a hotheaded former samurai like Sakata \"Gin\" Gintoki do to make ends meet? Take any odd job that comes his way, even if it means losing his dignity.",
                    View = 0,
                    CreateAt = DateTime.Now,
                    ImageStory = "",
                    IsActive = true
                },
                new Story
                {
                    StoryId = 11,
                    Title = "Tower Of God",
                    AuthorName = "Slave In Utero",
                    Content = "What do you desire? Fortune? Glory? Power? Revenge? Or something that surpasses all others? What ever you desire, 'that is here'. Tower of God.",
                    View = 0,
                    CreateAt = DateTime.Now,
                    ImageStory = "",
                    IsActive = true
                },
                new Story
                {
                    StoryId = 12,
                    Title = "The Gamer",
                    AuthorName = "Sang Ah",
                    Content = "What would happen if your world suddenly turned into a game?If you could level up and raise your stats?An adventure of a life-turned-game",
                    View = 0,
                    CreateAt = DateTime.Now,
                    ImageStory = "",
                    IsActive = true
                },
                new Story
                {
                    StoryId = 13,
                    Title = "Relife Player",
                    AuthorName = "Siyun",
                    Content = "Noh Eunha. After losing his family and closing off his heart, he just wanted to kill the monsters he loathed. I regressed before my life came to an end in the deepest part of the that was impossible for mankind to raid.",
                    View = 0,
                    CreateAt = DateTime.Now,
                    ImageStory = "",
                    IsActive = true
                },
                new Story
                {
                    StoryId = 14,
                    Title = "Baek XX",
                    AuthorName = "Park tae jun",
                    Content = "Federal Informant Baek Yisu and a criminal gangs boss, Baek Dogyeong are twin brothers. With the same faces the two twin brothers have lived different lives until now. Yisu, whos been betrayed by the gang, throws away his identity to become his brother. This federal agent is soon to become the gangs boss!",
                    View = 0,
                    CreateAt = DateTime.Now,
                    ImageStory = "",
                    IsActive = true
                }

                );

            modelBuilder.Entity<Favourite>().HasData(
                new Favourite { StoryId = 1, UserId = 2 },
                new Favourite { StoryId = 2, UserId = 2 },
                new Favourite { StoryId = 3, UserId = 2 },
                new Favourite { StoryId = 1, UserId = 3 },
                new Favourite { StoryId = 2, UserId = 4 }

                );

            modelBuilder.Entity<Comment>().HasData(
                new Comment { CommentId = 1, StoryId = 1, UserId = 2, Index = 1, Content = "Good Story", CreatedAt = DateTime.Now },
                new Comment { CommentId = 2, StoryId = 1, UserId = 3, ParentCommentId = 1, Index = 1, Content = "I don't think so", CreatedAt = DateTime.Now },
                new Comment { CommentId = 3, StoryId = 1, UserId = 4, ParentCommentId = 1, Index = 2, Content = "It's not good at all", CreatedAt = DateTime.Now },
                new Comment { CommentId = 4, StoryId = 1, UserId = 5, ParentCommentId = 1, Index = 3, Content = "LOL", CreatedAt = DateTime.Now },
                new Comment { CommentId = 5, StoryId = 1, UserId = 2, ParentCommentId = 2, Index = 1, Content = "Why", CreatedAt = DateTime.Now },
                new Comment { CommentId = 6, StoryId = 1, UserId = 3, ParentCommentId = 5, Index = 1, Content = "Because Main is OP", CreatedAt = DateTime.Now },
                new Comment { CommentId = 7, StoryId = 1, UserId = 3, Index = 2, Content = "This story is crazyyy", CreatedAt = DateTime.Now }
                );

            modelBuilder.Entity<Category>().HasData(
                new Category { CategoryId = 1, CategoryName = "Manga" }, // 1
                new Category { CategoryId = 2, CategoryName = "Manhwa" }, // 2
                new Category { CategoryId = 3, CategoryName = "Action" }, // 3
                new Category { CategoryId = 4, CategoryName = "Fantasy" }, // 4
                new Category { CategoryId = 5, CategoryName = "Shounen" }, // 5
                new Category { CategoryId = 6, CategoryName = "Drama" }, // 6
                new Category { CategoryId = 7, CategoryName = "Comedy" }, // 7
                new Category { CategoryId = 8, CategoryName = "Mystery" }, // 8
                new Category { CategoryId = 9, CategoryName = "Martial Arts" }, // 9
                new Category { CategoryId = 10, CategoryName = "Adventure" }, // 10
                new Category { CategoryId = 11, CategoryName = "Suppernatural" }, // 11
                new Category { CategoryId = 12, CategoryName = "Seinen" }, // 12
                new Category { CategoryId = 13, CategoryName = "Horror" }, // 13
                new Category { CategoryId = 14, CategoryName = "Historical" } // 14
                );

            modelBuilder.Entity<StoryCategory>().HasData(
                new StoryCategory { StoryId = 1, CategoryId = 1 },
                new StoryCategory { StoryId = 1, CategoryId = 3 },
                new StoryCategory { StoryId = 1, CategoryId = 4 },
                new StoryCategory { StoryId = 1, CategoryId = 5 },
                new StoryCategory { StoryId = 1, CategoryId = 6 },
                new StoryCategory { StoryId = 1, CategoryId = 7 },
                new StoryCategory { StoryId = 1, CategoryId = 8 },
                new StoryCategory { StoryId = 1, CategoryId = 9 },
                new StoryCategory { StoryId = 1, CategoryId = 10 },
                new StoryCategory { StoryId = 2, CategoryId = 1 },
                new StoryCategory { StoryId = 2, CategoryId = 3 },
                new StoryCategory { StoryId = 2, CategoryId = 7 },
                new StoryCategory { StoryId = 2, CategoryId = 11 },
                new StoryCategory { StoryId = 2, CategoryId = 12 },
                new StoryCategory { StoryId = 3, CategoryId = 2 },
                new StoryCategory { StoryId = 3, CategoryId = 3 },
                new StoryCategory { StoryId = 3, CategoryId = 4 },
                new StoryCategory { StoryId = 3, CategoryId = 10 },
                new StoryCategory { StoryId = 4, CategoryId = 2 },
                new StoryCategory { StoryId = 4, CategoryId = 4 },
                new StoryCategory { StoryId = 4, CategoryId = 5 },
                new StoryCategory { StoryId = 4, CategoryId = 10 },
                new StoryCategory { StoryId = 5, CategoryId = 1 },
                new StoryCategory { StoryId = 5, CategoryId = 5 },
                new StoryCategory { StoryId = 5, CategoryId = 6 },
                new StoryCategory { StoryId = 5, CategoryId = 13 },
                new StoryCategory { StoryId = 6, CategoryId = 1 },
                new StoryCategory { StoryId = 6, CategoryId = 3 },
                new StoryCategory { StoryId = 6, CategoryId = 7 },
                new StoryCategory { StoryId = 6, CategoryId = 10 },
                new StoryCategory { StoryId = 7, CategoryId = 1 },
                new StoryCategory { StoryId = 7, CategoryId = 3 },
                new StoryCategory { StoryId = 7, CategoryId = 14 },
                new StoryCategory { StoryId = 8, CategoryId = 1 },
                new StoryCategory { StoryId = 8, CategoryId = 3 },
                new StoryCategory { StoryId = 8, CategoryId = 4 },
                new StoryCategory { StoryId = 8, CategoryId = 5 },
                new StoryCategory { StoryId = 8, CategoryId = 6 },
                new StoryCategory { StoryId = 8, CategoryId = 7 },
                new StoryCategory { StoryId = 8, CategoryId = 10 },
                new StoryCategory { StoryId = 9, CategoryId = 1 },
                new StoryCategory { StoryId = 9, CategoryId = 3 },
                new StoryCategory { StoryId = 9, CategoryId = 4 },
                new StoryCategory { StoryId = 9, CategoryId = 5 },
                new StoryCategory { StoryId = 9, CategoryId = 7 },
                new StoryCategory { StoryId = 9, CategoryId = 9 },
                new StoryCategory { StoryId = 9, CategoryId = 10 },
                new StoryCategory { StoryId = 10, CategoryId = 1 },
                new StoryCategory { StoryId = 10, CategoryId = 3 },
                new StoryCategory { StoryId = 10, CategoryId = 5 },
                new StoryCategory { StoryId = 10, CategoryId = 7 },
                new StoryCategory { StoryId = 11, CategoryId = 2 },
                new StoryCategory { StoryId = 11, CategoryId = 3 },
                new StoryCategory { StoryId = 11, CategoryId = 4 },
                new StoryCategory { StoryId = 11, CategoryId = 5 },
                new StoryCategory { StoryId = 11, CategoryId = 6 },
                new StoryCategory { StoryId = 12, CategoryId = 2 },
                new StoryCategory { StoryId = 12, CategoryId = 3 },
                new StoryCategory { StoryId = 12, CategoryId = 4 },
                new StoryCategory { StoryId = 13, CategoryId = 2 },
                new StoryCategory { StoryId = 13, CategoryId = 3 },
                new StoryCategory { StoryId = 13, CategoryId = 4 },
                new StoryCategory { StoryId = 14, CategoryId = 2 },
                new StoryCategory { StoryId = 14, CategoryId = 3 },
                new StoryCategory { StoryId = 14, CategoryId = 4 }
                );


            modelBuilder.Entity<Chapter>().HasData(
                //One Piece
                new Chapter { ChapterId = 1, StoryId = 1, Index = 1, View = 0, CreateAt = DateTime.Now },
                new Chapter { ChapterId = 2, StoryId = 1, Index = 2, View = 0, CreateAt = DateTime.Now },
                new Chapter { ChapterId = 3, StoryId = 1, Index = 3, View = 0, CreateAt = DateTime.Now },
                new Chapter { ChapterId = 4, StoryId = 1, Index = 4, View = 0, CreateAt = DateTime.Now },
                new Chapter { ChapterId = 5, StoryId = 1, Index = 5, View = 0, CreateAt = DateTime.Now },
                new Chapter { ChapterId = 6, StoryId = 1, Index = 6, View = 0, CreateAt = DateTime.Now },
                new Chapter { ChapterId = 7, StoryId = 1, Index = 7, View = 0, CreateAt = DateTime.Now },
                new Chapter { ChapterId = 8, StoryId = 1, Index = 8, View = 0, CreateAt = DateTime.Now },
                new Chapter { ChapterId = 9, StoryId = 1, Index = 9, View = 0, CreateAt = DateTime.Now },
                new Chapter { ChapterId = 10, StoryId = 1, Index = 10, View = 0, CreateAt = DateTime.Now },

                            //One Punch Man
                            new Chapter { ChapterId = 11, StoryId = 2, Index = 1, View = 0, CreateAt = DateTime.Now },
                            new Chapter { ChapterId = 12, StoryId = 2, Index = 2, View = 0, CreateAt = DateTime.Now },
                            new Chapter { ChapterId = 13, StoryId = 2, Index = 3, View = 0, CreateAt = DateTime.Now },
                            new Chapter { ChapterId = 14, StoryId = 2, Index = 4, View = 0, CreateAt = DateTime.Now },
                            new Chapter { ChapterId = 15, StoryId = 2, Index = 5, View = 0, CreateAt = DateTime.Now },

                            //Return FFF Class
                            new Chapter { ChapterId = 16, StoryId = 3, Index = 1, View = 0, CreateAt = DateTime.Now },
                            new Chapter { ChapterId = 17, StoryId = 3, Index = 2, View = 0, CreateAt = DateTime.Now },
                            new Chapter { ChapterId = 18, StoryId = 3, Index = 3, View = 0, CreateAt = DateTime.Now },
                            new Chapter { ChapterId = 19, StoryId = 3, Index = 4, View = 0, CreateAt = DateTime.Now },
                            new Chapter { ChapterId = 20, StoryId = 3, Index = 5, View = 0, CreateAt = DateTime.Now },

                            //Solo Leveling
                            new Chapter { ChapterId = 21, StoryId = 4, Index = 1, View = 0, CreateAt = DateTime.Now },
                            new Chapter { ChapterId = 22, StoryId = 4, Index = 2, View = 0, CreateAt = DateTime.Now },
                            new Chapter { ChapterId = 23, StoryId = 4, Index = 3, View = 0, CreateAt = DateTime.Now },
                            new Chapter { ChapterId = 24, StoryId = 4, Index = 4, View = 0, CreateAt = DateTime.Now },
                            new Chapter { ChapterId = 25, StoryId = 4, Index = 5, View = 0, CreateAt = DateTime.Now },

                            //Chainsaw Man
                            new Chapter { ChapterId = 26, StoryId = 5, Index = 1, View = 0, CreateAt = DateTime.Now },
                            new Chapter { ChapterId = 27, StoryId = 5, Index = 2, View = 0, CreateAt = DateTime.Now },
                            new Chapter { ChapterId = 28, StoryId = 5, Index = 3, View = 0, CreateAt = DateTime.Now },
                            new Chapter { ChapterId = 29, StoryId = 5, Index = 4, View = 0, CreateAt = DateTime.Now },
                            new Chapter { ChapterId = 30, StoryId = 5, Index = 5, View = 0, CreateAt = DateTime.Now },

                            //Spy X Family
                            new Chapter { ChapterId = 31, StoryId = 6, Index = 1, View = 0, CreateAt = DateTime.Now },
                            new Chapter { ChapterId = 32, StoryId = 6, Index = 2, View = 0, CreateAt = DateTime.Now },
                            new Chapter { ChapterId = 33, StoryId = 6, Index = 3, View = 0, CreateAt = DateTime.Now },
                            new Chapter { ChapterId = 34, StoryId = 6, Index = 4, View = 0, CreateAt = DateTime.Now },
                            new Chapter { ChapterId = 35, StoryId = 6, Index = 5, View = 0, CreateAt = DateTime.Now },

                            //Kingdom
                            new Chapter { ChapterId = 36, StoryId = 7, Index = 1, View = 0, CreateAt = DateTime.Now },
                            new Chapter { ChapterId = 37, StoryId = 7, Index = 2, View = 0, CreateAt = DateTime.Now },
                            new Chapter { ChapterId = 38, StoryId = 7, Index = 3, View = 0, CreateAt = DateTime.Now },
                            new Chapter { ChapterId = 39, StoryId = 7, Index = 4, View = 0, CreateAt = DateTime.Now },
                            new Chapter { ChapterId = 40, StoryId = 7, Index = 5, View = 0, CreateAt = DateTime.Now },

                            //Bleach
                            new Chapter { ChapterId = 41, StoryId = 8, Index = 1, View = 0, CreateAt = DateTime.Now },
                            new Chapter { ChapterId = 42, StoryId = 8, Index = 2, View = 0, CreateAt = DateTime.Now },
                            new Chapter { ChapterId = 43, StoryId = 8, Index = 3, View = 0, CreateAt = DateTime.Now },
                            new Chapter { ChapterId = 44, StoryId = 8, Index = 4, View = 0, CreateAt = DateTime.Now },
                            new Chapter { ChapterId = 45, StoryId = 8, Index = 5, View = 0, CreateAt = DateTime.Now },

                            //Dragon Ball Super
                            new Chapter { ChapterId = 46, StoryId = 9, Index = 1, View = 0, CreateAt = DateTime.Now },
                            new Chapter { ChapterId = 47, StoryId = 9, Index = 2, View = 0, CreateAt = DateTime.Now },
                            new Chapter { ChapterId = 48, StoryId = 9, Index = 3, View = 0, CreateAt = DateTime.Now },
                            new Chapter { ChapterId = 49, StoryId = 9, Index = 4, View = 0, CreateAt = DateTime.Now },
                            new Chapter { ChapterId = 50, StoryId = 9, Index = 5, View = 0, CreateAt = DateTime.Now },

                            //Gintama
                            new Chapter { ChapterId = 51, StoryId = 10, Index = 1, View = 0, CreateAt = DateTime.Now },
                            new Chapter { ChapterId = 52, StoryId = 10, Index = 2, View = 0, CreateAt = DateTime.Now },
                            new Chapter { ChapterId = 53, StoryId = 10, Index = 3, View = 0, CreateAt = DateTime.Now },
                            new Chapter { ChapterId = 54, StoryId = 10, Index = 4, View = 0, CreateAt = DateTime.Now },
                            new Chapter { ChapterId = 55, StoryId = 10, Index = 5, View = 0, CreateAt = DateTime.Now },

                            //Tower Of God
                            new Chapter { ChapterId = 56, StoryId = 11, Index = 1, View = 0, CreateAt = DateTime.Now },
                            new Chapter { ChapterId = 57, StoryId = 11, Index = 2, View = 0, CreateAt = DateTime.Now },
                            new Chapter { ChapterId = 58, StoryId = 11, Index = 3, View = 0, CreateAt = DateTime.Now },
                            new Chapter { ChapterId = 59, StoryId = 11, Index = 4, View = 0, CreateAt = DateTime.Now },
                            new Chapter { ChapterId = 60, StoryId = 11, Index = 5, View = 0, CreateAt = DateTime.Now },

                            //The Gamer
                            new Chapter { ChapterId = 61, StoryId = 12, Index = 1, View = 0, CreateAt = DateTime.Now },
                            new Chapter { ChapterId = 62, StoryId = 12, Index = 2, View = 0, CreateAt = DateTime.Now },
                            new Chapter { ChapterId = 63, StoryId = 12, Index = 3, View = 0, CreateAt = DateTime.Now },
                            new Chapter { ChapterId = 64, StoryId = 12, Index = 4, View = 0, CreateAt = DateTime.Now },
                            new Chapter { ChapterId = 65, StoryId = 12, Index = 5, View = 0, CreateAt = DateTime.Now },

                            //Relife Player
                            new Chapter { ChapterId = 66, StoryId = 13, Index = 1, View = 0, CreateAt = DateTime.Now },
                            new Chapter { ChapterId = 67, StoryId = 13, Index = 2, View = 0, CreateAt = DateTime.Now },
                            new Chapter { ChapterId = 68, StoryId = 13, Index = 3, View = 0, CreateAt = DateTime.Now },
                            new Chapter { ChapterId = 69, StoryId = 13, Index = 4, View = 0, CreateAt = DateTime.Now },
                            new Chapter { ChapterId = 70, StoryId = 13, Index = 5, View = 0, CreateAt = DateTime.Now },

                            //Baek XX
                            new Chapter { ChapterId = 71, StoryId = 14, Index = 1, View = 0, CreateAt = DateTime.Now },
                            new Chapter { ChapterId = 72, StoryId = 14, Index = 2, View = 0, CreateAt = DateTime.Now },
                            new Chapter { ChapterId = 73, StoryId = 14, Index = 3, View = 0, CreateAt = DateTime.Now },
                            new Chapter { ChapterId = 74, StoryId = 14, Index = 4, View = 0, CreateAt = DateTime.Now },
                            new Chapter { ChapterId = 75, StoryId = 14, Index = 5, View = 0, CreateAt = DateTime.Now }
                );

            //One Piece
            for (int i = 1; i <= 52; i++)
            {
                modelBuilder.Entity<Image>().HasData(
                    new Image { ImageId = i, ChapterId = 1, Index = i, ImageChapter = $"https://firebasestorage.googleapis.com/v0/b/fir-react-87033.appspot.com/o/OnePiece%2Fes1%2Fimage_{i}.jpg?alt=media" }
                );
            }
            for (int i = 1; i <= 23; i++)
            {
                modelBuilder.Entity<Image>().HasData(
                    new Image { ImageId = i + 52, ChapterId = 2, Index = i, ImageChapter = $"https://firebasestorage.googleapis.com/v0/b/fir-react-87033.appspot.com/o/OnePiece%2Fes2%2Fimage_{i}.jpg?alt=media" }
                );
            }
            for (int i = 1; i <= 21; i++)
            {
                modelBuilder.Entity<Image>().HasData(
                    new Image { ImageId = i + 75, ChapterId = 3, Index = i, ImageChapter = $"https://firebasestorage.googleapis.com/v0/b/fir-react-87033.appspot.com/o/OnePiece%2Fes3%2Fimage_{i}.jpg?alt=media" }
                );
            }
            for (int i = 1; i <= 19; i++)
            {
                modelBuilder.Entity<Image>().HasData(
                    new Image { ImageId = i + 96, ChapterId = 4, Index = i, ImageChapter = $"https://firebasestorage.googleapis.com/v0/b/fir-react-87033.appspot.com/o/OnePiece%2Fes4%2Fimage_{i}.jpg?alt=media" }
                );
            }
            for (int i = 1; i <= 21; i++)
            {
                modelBuilder.Entity<Image>().HasData(
                    new Image { ImageId = i + 115, ChapterId = 5, Index = i, ImageChapter = $"https://firebasestorage.googleapis.com/v0/b/fir-react-87033.appspot.com/o/OnePiece%2Fes5%2Fimage_{i}.jpg?alt=media" }
                );
            }
            for (int i = 1; i <= 22; i++)
            {
                modelBuilder.Entity<Image>().HasData(
                    new Image { ImageId = i + 136, ChapterId = 6, Index = i, ImageChapter = $"https://firebasestorage.googleapis.com/v0/b/fir-react-87033.appspot.com/o/OnePiece%2Fes6%2Fimage_{i}.jpg?alt=media" }
                );
            }
            for (int i = 1; i <= 21; i++)
            {
                modelBuilder.Entity<Image>().HasData(
                    new Image { ImageId = i + 158, ChapterId = 7, Index = i, ImageChapter = $"https://firebasestorage.googleapis.com/v0/b/fir-react-87033.appspot.com/o/OnePiece%2Fes7%2Fimage_{i}.jpg?alt=media" }
                );
            }
            for (int i = 1; i <= 20; i++)
            {
                modelBuilder.Entity<Image>().HasData(
                    new Image { ImageId = i + 179, ChapterId = 8, Index = i, ImageChapter = $"https://firebasestorage.googleapis.com/v0/b/fir-react-87033.appspot.com/o/OnePiece%2Fes8%2Fimage_{i}.jpg?alt=media" }
                );
            }
            for (int i = 1; i <= 27; i++)
            {
                modelBuilder.Entity<Image>().HasData(
                    new Image { ImageId = i + 199, ChapterId = 9, Index = i, ImageChapter = $"https://firebasestorage.googleapis.com/v0/b/fir-react-87033.appspot.com/o/OnePiece%2Fes9%2Fimage_{i}.jpg?alt=media" }
                );
            }
            for (int i = 1; i <= 24; i++)
            {
                modelBuilder.Entity<Image>().HasData(
                    new Image { ImageId = i + 226, ChapterId = 10, Index = i, ImageChapter = $"https://firebasestorage.googleapis.com/v0/b/fir-react-87033.appspot.com/o/OnePiece%2Fes10%2Fimage_{i}.jpg?alt=media" }
                );
            }

            //One Punch Man
            for (int i = 1; i <= 26; i++)
            {
                modelBuilder.Entity<Image>().HasData(
                    new Image { ImageId = i + 250, ChapterId = 11, Index = i, ImageChapter = $"https://firebasestorage.googleapis.com/v0/b/fir-react-87033.appspot.com/o/OnePunchMan%2Fes1%2Fimage_{i}.jpg?alt=media" }
                );
            }
            for (int i = 1; i <= 16; i++)
            {
                modelBuilder.Entity<Image>().HasData(
                    new Image { ImageId = i + 276, ChapterId = 12, Index = i, ImageChapter = $"https://firebasestorage.googleapis.com/v0/b/fir-react-87033.appspot.com/o/OnePunchMan%2Fes2%2Fimage_{i}.jpg?alt=media" }
                );
            }
            for (int i = 1; i <= 20; i++)
            {
                modelBuilder.Entity<Image>().HasData(
                    new Image { ImageId = i + 292, ChapterId = 13, Index = i, ImageChapter = $"https://firebasestorage.googleapis.com/v0/b/fir-react-87033.appspot.com/o/OnePunchMan%2Fes3%2Fimage_{i}.jpg?alt=media" }
                );
            }
            for (int i = 1; i <= 25; i++)
            {
                modelBuilder.Entity<Image>().HasData(
                    new Image { ImageId = i + 312, ChapterId = 14, Index = i, ImageChapter = $"https://firebasestorage.googleapis.com/v0/b/fir-react-87033.appspot.com/o/OnePunchMan%2Fes4%2Fimage_{i}.jpg?alt=media" }
                );
            }
            for (int i = 1; i <= 20; i++)
            {
                modelBuilder.Entity<Image>().HasData(
                    new Image { ImageId = i + 337, ChapterId = 15, Index = i, ImageChapter = $"https://firebasestorage.googleapis.com/v0/b/fir-react-87033.appspot.com/o/OnePunchMan%2Fes5%2Fimage_{i}.jpg?alt=media" }
                );
            }

            //Return FFF Class
            for (int i = 1; i <= 72; i++)
            {
                modelBuilder.Entity<Image>().HasData(
                    new Image { ImageId = i + 357, ChapterId = 16, Index = i, ImageChapter = $"https://firebasestorage.googleapis.com/v0/b/fir-react-87033.appspot.com/o/ReturnFFFClass%2Fes1%2Fimage_{i}.jpg?alt=media" }
                );
            }
            for (int i = 1; i <= 49; i++)
            {
                modelBuilder.Entity<Image>().HasData(
                    new Image { ImageId = i + 429, ChapterId = 17, Index = i, ImageChapter = $"https://firebasestorage.googleapis.com/v0/b/fir-react-87033.appspot.com/o/ReturnFFFClass%2Fes2%2Fimage_{i}.jpg?alt=media" }
                );
            }
            for (int i = 1; i <= 50; i++)
            {
                modelBuilder.Entity<Image>().HasData(
                    new Image { ImageId = i + 478, ChapterId = 18, Index = i, ImageChapter = $"https://firebasestorage.googleapis.com/v0/b/fir-react-87033.appspot.com/o/ReturnFFFClass%2Fes3%2Fimage_{i}.jpg?alt=media" }
                );
            }
            for (int i = 1; i <= 54; i++)
            {
                modelBuilder.Entity<Image>().HasData(
                    new Image { ImageId = i + 528, ChapterId = 19, Index = i, ImageChapter = $"https://firebasestorage.googleapis.com/v0/b/fir-react-87033.appspot.com/o/ReturnFFFClass%2Fes4%2Fimage_{i}.jpg?alt=media" }
                );
            }
            for (int i = 1; i <= 54; i++)
            {
                modelBuilder.Entity<Image>().HasData(
                    new Image { ImageId = i + 582, ChapterId = 20, Index = i, ImageChapter = $"https://firebasestorage.googleapis.com/v0/b/fir-react-87033.appspot.com/o/ReturnFFFClass%2Fes5%2Fimage_{i}.jpg?alt=media" }
                );
            }

            //Solo Leveling
            for (int i = 1; i <= 10; i++)
            {
                modelBuilder.Entity<Image>().HasData(
                    new Image { ImageId = i + 636, ChapterId = 21, Index = i, ImageChapter = $"https://firebasestorage.googleapis.com/v0/b/fir-react-87033.appspot.com/o/SoloLeveling%2Fes1%2Fimage_{i}.jpg?alt=media" }
                );
            }
            for (int i = 1; i <= 17; i++)
            {
                modelBuilder.Entity<Image>().HasData(
                    new Image { ImageId = i + 646, ChapterId = 22, Index = i, ImageChapter = $"https://firebasestorage.googleapis.com/v0/b/fir-react-87033.appspot.com/o/SoloLeveling%2Fes2%2Fimage_{i}.jpg?alt=media" }
                );
            }
            for (int i = 1; i <= 18; i++)
            {
                modelBuilder.Entity<Image>().HasData(
                    new Image { ImageId = i + 663, ChapterId = 23, Index = i, ImageChapter = $"https://firebasestorage.googleapis.com/v0/b/fir-react-87033.appspot.com/o/SoloLeveling%2Fes3%2Fimage_{i}.jpg?alt=media" }
                );
            }
            for (int i = 1; i <= 12; i++)
            {
                modelBuilder.Entity<Image>().HasData(
                    new Image { ImageId = i + 681, ChapterId = 24, Index = i, ImageChapter = $"https://firebasestorage.googleapis.com/v0/b/fir-react-87033.appspot.com/o/SoloLeveling%2Fes4%2Fimage_{i}.jpg?alt=media" }
                );
            }
            for (int i = 1; i <= 18; i++)
            {
                modelBuilder.Entity<Image>().HasData(
                    new Image { ImageId = i + 693, ChapterId = 25, Index = i, ImageChapter = $"https://firebasestorage.googleapis.com/v0/b/fir-react-87033.appspot.com/o/SoloLeveling%2Fes5%2Fimage_{i}.jpg?alt=media" }
                );
            }

            //Chainsaw Man
            for (int i = 1; i <= 53; i++)
            {
                modelBuilder.Entity<Image>().HasData(
                    new Image { ImageId = i + 711, ChapterId = 26, Index = i, ImageChapter = $"https://firebasestorage.googleapis.com/v0/b/fir-react-87033.appspot.com/o/ChainsawMan%2Fes1%2Fimage_{i}.jpg?alt=media" }
                );
            }
            for (int i = 1; i <= 55; i++)
            {
                modelBuilder.Entity<Image>().HasData(
                    new Image { ImageId = i + 764, ChapterId = 27, Index = i, ImageChapter = $"https://firebasestorage.googleapis.com/v0/b/fir-react-87033.appspot.com/o/ChainsawMan%2Fes2%2Fimage_{i}.jpg?alt=media" }
                );
            }
            for (int i = 1; i <= 18; i++)
            {
                modelBuilder.Entity<Image>().HasData(
                    new Image { ImageId = i + 819, ChapterId = 28, Index = i, ImageChapter = $"https://firebasestorage.googleapis.com/v0/b/fir-react-87033.appspot.com/o/ChainsawMan%2Fes3%2Fimage_{i}.jpg?alt=media" }
                );
            }
            for (int i = 1; i <= 36; i++)
            {
                modelBuilder.Entity<Image>().HasData(
                    new Image { ImageId = i + 837, ChapterId = 29, Index = i, ImageChapter = $"https://firebasestorage.googleapis.com/v0/b/fir-react-87033.appspot.com/o/ChainsawMan%2Fes4%2Fimage_{i}.jpg?alt=media" }
                );
            }
            for (int i = 1; i <= 43; i++)
            {
                modelBuilder.Entity<Image>().HasData(
                    new Image { ImageId = i + 873, ChapterId = 30, Index = i, ImageChapter = $"https://firebasestorage.googleapis.com/v0/b/fir-react-87033.appspot.com/o/ChainsawMan%2Fes5%2Fimage_{i}.jpg?alt=media" }
                );
            }

            //Spy X Family
            for (int i = 1; i <= 71; i++)
            {
                modelBuilder.Entity<Image>().HasData(
                    new Image { ImageId = i + 916, ChapterId = 31, Index = i, ImageChapter = $"https://firebasestorage.googleapis.com/v0/b/fir-react-87033.appspot.com/o/SpyFamily%2Fes1%2Fimage_{i}.jpg?alt=media" }
                );
            }
            for (int i = 1; i <= 55; i++)
            {
                modelBuilder.Entity<Image>().HasData(
                    new Image { ImageId = i + 987, ChapterId = 32, Index = i, ImageChapter = $"https://firebasestorage.googleapis.com/v0/b/fir-react-87033.appspot.com/o/SpyFamily%2Fes2%2Fimage_{i}.jpg?alt=media" }
                );
            }
            for (int i = 1; i <= 27; i++)
            {
                modelBuilder.Entity<Image>().HasData(
                    new Image { ImageId = i + 1042, ChapterId = 33, Index = i, ImageChapter = $"https://firebasestorage.googleapis.com/v0/b/fir-react-87033.appspot.com/o/SpyFamily%2Fes3%2Fimage_{i}.jpg?alt=media" }
                );
            }
            for (int i = 1; i <= 25; i++)
            {
                modelBuilder.Entity<Image>().HasData(
                    new Image { ImageId = i + 1069, ChapterId = 34, Index = i, ImageChapter = $"https://firebasestorage.googleapis.com/v0/b/fir-react-87033.appspot.com/o/SpyFamily%2Fes4%2Fimage_{i}.jpg?alt=media" }
                );
            }
            for (int i = 1; i <= 25; i++)
            {
                modelBuilder.Entity<Image>().HasData(
                    new Image { ImageId = i + 1094, ChapterId = 35, Index = i, ImageChapter = $"https://firebasestorage.googleapis.com/v0/b/fir-react-87033.appspot.com/o/SpyFamily%2Fes5%2Fimage_{i}.jpg?alt=media" }
                );
            }

            //Kingdom
            for (int i = 1; i <= 54; i++)
            {
                modelBuilder.Entity<Image>().HasData(
                    new Image { ImageId = i + 1119, ChapterId = 36, Index = i, ImageChapter = $"https://firebasestorage.googleapis.com/v0/b/fir-react-87033.appspot.com/o/Kingdom%2Fes1%2Fimage_{i}.jpg?alt=media" }
                );
            }
            for (int i = 1; i <= 39; i++)
            {
                modelBuilder.Entity<Image>().HasData(
                    new Image { ImageId = i + 1173, ChapterId = 37, Index = i, ImageChapter = $"https://firebasestorage.googleapis.com/v0/b/fir-react-87033.appspot.com/o/Kingdom%2Fes2%2Fimage_{i}.jpg?alt=media" }
                );
            }
            for (int i = 1; i <= 26; i++)
            {
                modelBuilder.Entity<Image>().HasData(
                    new Image { ImageId = i + 1212, ChapterId = 38, Index = i, ImageChapter = $"https://firebasestorage.googleapis.com/v0/b/fir-react-87033.appspot.com/o/Kingdom%2Fes3%2Fimage_{i}.jpg?alt=media" }
                );
            }
            for (int i = 1; i <= 17; i++)
            {
                modelBuilder.Entity<Image>().HasData(
                    new Image { ImageId = i + 1238, ChapterId = 39, Index = i, ImageChapter = $"https://firebasestorage.googleapis.com/v0/b/fir-react-87033.appspot.com/o/Kingdom%2Fes4%2Fimage_{i}.jpg?alt=media" }
                );
            }
            for (int i = 1; i <= 20; i++)
            {
                modelBuilder.Entity<Image>().HasData(
                    new Image { ImageId = i + 1255, ChapterId = 40, Index = i, ImageChapter = $"https://firebasestorage.googleapis.com/v0/b/fir-react-87033.appspot.com/o/Kingdom%2Fes5%2Fimage_{i}.jpg?alt=media" }
                );
            }

            //Bleach
            for (int i = 1; i <= 55; i++)
            {
                modelBuilder.Entity<Image>().HasData(
                    new Image { ImageId = i + 1275, ChapterId = 41, Index = i, ImageChapter = $"https://firebasestorage.googleapis.com/v0/b/fir-react-87033.appspot.com/o/Bleach%2Fes1%2Fimage_{i}.jpg?alt=media" }
                );
            }
            for (int i = 1; i <= 24; i++)
            {
                modelBuilder.Entity<Image>().HasData(
                    new Image { ImageId = i + 1330, ChapterId = 42, Index = i, ImageChapter = $"https://firebasestorage.googleapis.com/v0/b/fir-react-87033.appspot.com/o/Bleach%2Fes2%2Fimage_{i}.jpg?alt=media" }
                );
            }
            for (int i = 1; i <= 22; i++)
            {
                modelBuilder.Entity<Image>().HasData(
                    new Image { ImageId = i + 1354, ChapterId = 43, Index = i, ImageChapter = $"https://firebasestorage.googleapis.com/v0/b/fir-react-87033.appspot.com/o/Bleach%2Fes3%2Fimage_{i}.jpg?alt=media" }
                );
            }
            for (int i = 1; i <= 20; i++)
            {
                modelBuilder.Entity<Image>().HasData(
                    new Image { ImageId = i + 1376, ChapterId = 44, Index = i, ImageChapter = $"https://firebasestorage.googleapis.com/v0/b/fir-react-87033.appspot.com/o/Bleach%2Fes4%2Fimage_{i}.jpg?alt=media" }
                );
            }
            for (int i = 1; i <= 20; i++)
            {
                modelBuilder.Entity<Image>().HasData(
                    new Image { ImageId = i + 1396, ChapterId = 45, Index = i, ImageChapter = $"https://firebasestorage.googleapis.com/v0/b/fir-react-87033.appspot.com/o/Bleach%2Fes5%2Fimage_{i}.jpg?alt=media" }
                );
            }

            //Dragon Ball Super
            for (int i = 1; i <= 21; i++)
            {
                modelBuilder.Entity<Image>().HasData(
                    new Image { ImageId = i + 1416, ChapterId = 46, Index = i, ImageChapter = $"https://firebasestorage.googleapis.com/v0/b/fir-react-87033.appspot.com/o/DragonBallSuper%2Fes1%2Fimage_{i}.jpg?alt=media" }
                );
            }
            for (int i = 1; i <= 16; i++)
            {
                modelBuilder.Entity<Image>().HasData(
                    new Image { ImageId = i + 1437, ChapterId = 47, Index = i, ImageChapter = $"https://firebasestorage.googleapis.com/v0/b/fir-react-87033.appspot.com/o/DragonBallSuper%2Fes2%2Fimage_{i}.jpg?alt=media" }
                );
            }
            for (int i = 1; i <= 16; i++)
            {
                modelBuilder.Entity<Image>().HasData(
                    new Image { ImageId = i + 1453, ChapterId = 48, Index = i, ImageChapter = $"https://firebasestorage.googleapis.com/v0/b/fir-react-87033.appspot.com/o/DragonBallSuper%2Fes3%2Fimage_{i}.jpg?alt=media" }
                );
            }
            for (int i = 1; i <= 19; i++)
            {
                modelBuilder.Entity<Image>().HasData(
                    new Image { ImageId = i + 1469, ChapterId = 49, Index = i, ImageChapter = $"https://firebasestorage.googleapis.com/v0/b/fir-react-87033.appspot.com/o/DragonBallSuper%2Fes4%2Fimage_{i}.jpg?alt=media" }
                );
            }
            for (int i = 1; i <= 21; i++)
            {
                modelBuilder.Entity<Image>().HasData(
                    new Image { ImageId = i + 1488, ChapterId = 50, Index = i, ImageChapter = $"https://firebasestorage.googleapis.com/v0/b/fir-react-87033.appspot.com/o/DragonBallSuper%2Fes5%2Fimage_{i}.jpg?alt=media" }
                );
            }

            //Gintama
            for (int i = 1; i <= 58; i++)
            {
                modelBuilder.Entity<Image>().HasData(
                    new Image { ImageId = i + 1509, ChapterId = 51, Index = i, ImageChapter = $"https://firebasestorage.googleapis.com/v0/b/fir-react-87033.appspot.com/o/Gintama%2Fes1%2Fimage_{i}.jpg?alt=media" }
                );
            }
            for (int i = 1; i <= 26; i++)
            {
                modelBuilder.Entity<Image>().HasData(
                    new Image { ImageId = i + 1567, ChapterId = 52, Index = i, ImageChapter = $"https://firebasestorage.googleapis.com/v0/b/fir-react-87033.appspot.com/o/Gintama%2Fes2%2Fimage_{i}.jpg?alt=media" }
                );
            }
            for (int i = 1; i <= 25; i++)
            {
                modelBuilder.Entity<Image>().HasData(
                    new Image { ImageId = i + 1593, ChapterId = 53, Index = i, ImageChapter = $"https://firebasestorage.googleapis.com/v0/b/fir-react-87033.appspot.com/o/Gintama%2Fes3%2Fimage_{i}.jpg?alt=media" }
                );
            }
            for (int i = 1; i <= 20; i++)
            {
                modelBuilder.Entity<Image>().HasData(
                    new Image { ImageId = i + 1618, ChapterId = 54, Index = i, ImageChapter = $"https://firebasestorage.googleapis.com/v0/b/fir-react-87033.appspot.com/o/Gintama%2Fes4%2Fimage_{i}.jpg?alt=media" }
                );
            }
            for (int i = 1; i <= 20; i++)
            {
                modelBuilder.Entity<Image>().HasData(
                    new Image { ImageId = i + 1638, ChapterId = 55, Index = i, ImageChapter = $"https://firebasestorage.googleapis.com/v0/b/fir-react-87033.appspot.com/o/Gintama%2Fes5%2Fimage_{i}.jpg?alt=media" }
                );
            }

            //Tower Of God
            for (int i = 1; i <= 6; i++)
            {
                modelBuilder.Entity<Image>().HasData(
                    new Image { ImageId = i + 1658, ChapterId = 56, Index = i, ImageChapter = $"https://firebasestorage.googleapis.com/v0/b/fir-react-87033.appspot.com/o/TowerOfGod%2Fes1%2Fimage_{i}.jpg?alt=media" }
                );
            }
            for (int i = 1; i <= 8; i++)
            {
                modelBuilder.Entity<Image>().HasData(
                    new Image { ImageId = i + 1664, ChapterId = 57, Index = i, ImageChapter = $"https://firebasestorage.googleapis.com/v0/b/fir-react-87033.appspot.com/o/TowerOfGod%2Fes2%2Fimage_{i}.jpg?alt=media" }
                );
            }
            for (int i = 1; i <= 6; i++)
            {
                modelBuilder.Entity<Image>().HasData(
                    new Image { ImageId = i + 1672, ChapterId = 58, Index = i, ImageChapter = $"https://firebasestorage.googleapis.com/v0/b/fir-react-87033.appspot.com/o/TowerOfGod%2Fes3%2Fimage_{i}.jpg?alt=media" }
                );
            }
            for (int i = 1; i <= 7; i++)
            {
                modelBuilder.Entity<Image>().HasData(
                    new Image { ImageId = i + 1678, ChapterId = 59, Index = i, ImageChapter = $"https://firebasestorage.googleapis.com/v0/b/fir-react-87033.appspot.com/o/TowerOfGod%2Fes4%2Fimage_{i}.jpg?alt=media" }
                );
            }
            for (int i = 1; i <= 5; i++)
            {
                modelBuilder.Entity<Image>().HasData(
                    new Image { ImageId = i + 1685, ChapterId = 60, Index = i, ImageChapter = $"https://firebasestorage.googleapis.com/v0/b/fir-react-87033.appspot.com/o/TowerOfGod%2Fes5%2Fimage_{i}.jpg?alt=media" }
                );
            }

            //The Gamer
            for (int i = 1; i <= 23; i++)
            {
                modelBuilder.Entity<Image>().HasData(
                    new Image { ImageId = i + 1690, ChapterId = 61, Index = i, ImageChapter = $"https://firebasestorage.googleapis.com/v0/b/fir-react-87033.appspot.com/o/TheGamer%2Fes1%2Fimage_{i}.jpg?alt=media" }
                );
            }
            for (int i = 1; i <= 26; i++)
            {
                modelBuilder.Entity<Image>().HasData(
                    new Image { ImageId = i + 1713, ChapterId = 62, Index = i, ImageChapter = $"https://firebasestorage.googleapis.com/v0/b/fir-react-87033.appspot.com/o/TheGamer%2Fes2%2Fimage_{i}.jpg?alt=media" }
                );
            }
            for (int i = 1; i <= 27; i++)
            {
                modelBuilder.Entity<Image>().HasData(
                    new Image { ImageId = i + 1739, ChapterId = 63, Index = i, ImageChapter = $"https://firebasestorage.googleapis.com/v0/b/fir-react-87033.appspot.com/o/TheGamer%2Fes3%2Fimage_{i}.jpg?alt=media" }
                );
            }
            for (int i = 1; i <= 33; i++)
            {
                modelBuilder.Entity<Image>().HasData(
                    new Image { ImageId = i + 1766, ChapterId = 64, Index = i, ImageChapter = $"https://firebasestorage.googleapis.com/v0/b/fir-react-87033.appspot.com/o/TheGamer%2Fes4%2Fimage_{i}.jpg?alt=media" }
                );
            }
            for (int i = 1; i <= 30; i++)
            {
                modelBuilder.Entity<Image>().HasData(
                    new Image { ImageId = i + 1799, ChapterId = 65, Index = i, ImageChapter = $"https://firebasestorage.googleapis.com/v0/b/fir-react-87033.appspot.com/o/TheGamer%2Fes5%2Fimage_{i}.jpg?alt=media" }
                );
            }

            //Relife Player
            for (int i = 1; i <= 72; i++)
            {
                modelBuilder.Entity<Image>().HasData(
                    new Image { ImageId = i + 1829, ChapterId = 66, Index = i, ImageChapter = $"https://firebasestorage.googleapis.com/v0/b/fir-react-87033.appspot.com/o/RelifePlayer%2Fes1%2Fimage_{i}.jpg?alt=media" }
                );
            }
            for (int i = 1; i <= 49; i++)
            {
                modelBuilder.Entity<Image>().HasData(
                    new Image { ImageId = i + 1901, ChapterId = 67, Index = i, ImageChapter = $"https://firebasestorage.googleapis.com/v0/b/fir-react-87033.appspot.com/o/RelifePlayer%2Fes2%2Fimage_{i}.jpg?alt=media" }
                );
            }
            for (int i = 1; i <= 50; i++)
            {
                modelBuilder.Entity<Image>().HasData(
                    new Image { ImageId = i + 1950, ChapterId = 68, Index = i, ImageChapter = $"https://firebasestorage.googleapis.com/v0/b/fir-react-87033.appspot.com/o/RelifePlayer%2Fes3%2Fimage_{i}.jpg?alt=media" }
                );
            }
            for (int i = 1; i <= 54; i++)
            {
                modelBuilder.Entity<Image>().HasData(
                    new Image { ImageId = i + 2000, ChapterId = 69, Index = i, ImageChapter = $"https://firebasestorage.googleapis.com/v0/b/fir-react-87033.appspot.com/o/RelifePlayer%2Fes4%2Fimage_{i}.jpg?alt=media" }
                );
            }
            for (int i = 1; i <= 54; i++)
            {
                modelBuilder.Entity<Image>().HasData(
                    new Image { ImageId = i + 2054, ChapterId = 70, Index = i, ImageChapter = $"https://firebasestorage.googleapis.com/v0/b/fir-react-87033.appspot.com/o/RelifePlayer%2Fes5%2Fimage_{i}.jpg?alt=media" }
                );
            }

            //Beak XX
            for (int i = 1; i <= 33; i++)
            {
                modelBuilder.Entity<Image>().HasData(
                    new Image { ImageId = i + 2108, ChapterId = 70, Index = i, ImageChapter = $"https://firebasestorage.googleapis.com/v0/b/fir-react-87033.appspot.com/o/BaekXX%2Fes1%2Fimage_{i}.jpg?alt=media" }
                );
            }
            for (int i = 1; i <= 32; i++)
            {
                modelBuilder.Entity<Image>().HasData(
                    new Image { ImageId = i + 2141, ChapterId = 70, Index = i, ImageChapter = $"https://firebasestorage.googleapis.com/v0/b/fir-react-87033.appspot.com/o/BaekXX%2Fes2%2Fimage_{i}.jpg?alt=media" }
                );
            }
            for (int i = 1; i <= 26; i++)
            {
                modelBuilder.Entity<Image>().HasData(
                    new Image { ImageId = i + 2173, ChapterId = 70, Index = i, ImageChapter = $"https://firebasestorage.googleapis.com/v0/b/fir-react-87033.appspot.com/o/BaekXX%2Fes3%2Fimage_{i}.jpg?alt=media" }
                );
            }
            for (int i = 1; i <= 23; i++)
            {
                modelBuilder.Entity<Image>().HasData(
                    new Image { ImageId = i + 2199, ChapterId = 70, Index = i, ImageChapter = $"https://firebasestorage.googleapis.com/v0/b/fir-react-87033.appspot.com/o/BaekXX%2Fes4%2Fimage_{i}.jpg?alt=media" }
                );
            }
            for (int i = 1; i <= 28; i++)
            {
                modelBuilder.Entity<Image>().HasData(
                    new Image { ImageId = i + 2222, ChapterId = 70, Index = i, ImageChapter = $"https://firebasestorage.googleapis.com/v0/b/fir-react-87033.appspot.com/o/BaekXX%2Fes5%2Fimage_{i}.jpg?alt=media" }
                );
            }

        }
    }
}
