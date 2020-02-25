using System;
using System.Collections.Generic;
using System.Text;

namespace ArcadiaParties.Data.Abstractions.DTOs
{
    public class UserRoleDTO
    {
        public int Id { get; set; }

        public string UserId { get; set; }

        public UserDTO User { get; set; }

        public int RoleId { get; set; }

        public RoleDTO Role { get; set; }
    }
}
