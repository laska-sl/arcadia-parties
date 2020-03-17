using System.Collections.Generic;

namespace ArcadiaParties.Data.Abstractions.DTOs
{
    public class UserDTO
    {
        public string Identity { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<CelebratingDateDTO> Dates { get; set; }

        public IEnumerable<string> UserRoles { get; set; }

        public DepartmentDTO Department { get; set; }
    }
}
