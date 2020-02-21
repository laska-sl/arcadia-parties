using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ArcadiaParties.Data.Models
{
    public class User
    {
        [Key]
        public string Identity { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        public DateTime BirthDate { get; set; }

        [Required]
        public DateTime HireDate { get; set; }

        public ICollection<UserRole> UserRoles { get; set; } = new List<UserRole>();
    }
}
