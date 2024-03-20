using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Entities
{
    public class User
    {
        [Key]
        public int UserId { get; set; }

        public string FullName { get; set; }

        public string UserName { get; set; }

        public string ImageUser { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string Password { get; set; }

        public bool IsMale { get; set; }

        public int RoleId { get; set; }
        [ForeignKey("RoleId")]
        public virtual Role Role { get; set; }

        public bool IsActive { get; set; }
    }
}
