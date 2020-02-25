using System;
using System.Collections.Generic;
using System.Text;

namespace ArcadiaParties.Data.Abstractions.DTOs
{
    class RoleDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public List<UserRoleDTO> UserRoles { get; set; }
    }
}
