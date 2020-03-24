using System.Collections.Generic;

namespace ArcadiaParties.Data.Abstractions.DTOs
{
    public class UserDTO
    {
        public string Identity { get; set; }

        public string Name { get; set; }

        public ICollection<CelebratingDateDTO> Dates { get; set; }

        public IEnumerable<string> Roles { get; set; }

        public string DepartmentId { get; set; }
    }
}
