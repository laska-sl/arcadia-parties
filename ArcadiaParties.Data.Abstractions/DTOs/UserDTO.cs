using System;
using System.Collections.Generic;
using System.Text;

namespace ArcadiaParties.Data.Abstractions.DTOs
{
    class UserDTO
    {
        public string Identity { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public DateTime HireDate { get; set; }

        public ICollection<UserRoleDTO> UserRoles { get; set; } = new List<UserRole>();

        public int DepartmentId { get; set; }

        public DepartmentDTO Department { get; set; }
    }
}
