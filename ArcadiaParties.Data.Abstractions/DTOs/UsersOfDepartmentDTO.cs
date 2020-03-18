using System;
using System.Collections.Generic;

namespace ArcadiaParties.Data.Abstractions.DTOs
{
    public class UsersOfDepartmentDTO
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public ICollection<CelebratingDateDTO> Dates { get; set; }
    }
}