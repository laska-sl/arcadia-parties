using System;
using System.Collections.Generic;
using System.Text;

namespace ArcadiaParties.Data.Abstractions.DTOs
{
    public class DepartmentDTO
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public ICollection<UserDTO> Users { get; set; }
    }
}
