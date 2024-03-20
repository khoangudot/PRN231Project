using System.ComponentModel.DataAnnotations;

namespace DataAccess.Entities
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        public string CategoryName { get; set; }

        public virtual ICollection<StoryCategory> StoryCategories { get; set; }
    }
}
