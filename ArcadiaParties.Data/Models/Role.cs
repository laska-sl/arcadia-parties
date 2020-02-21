using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ArcadiaParties.Data.Models
{
    public class Role
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public List<UserRole> UserRoles { get; set; } = new List<UserRole>();
    }
}
