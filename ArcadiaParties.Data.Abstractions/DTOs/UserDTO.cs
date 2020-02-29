using System;
using System.Collections.Generic;

namespace ArcadiaParties.Data.Abstractions.DTOs
{
    public class UserDTO
    {
        public string Identity { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public DateTime BirthDate { get; set; }

        public DateTime HireDate { get; set; }

        public IEnumerable<string> UserRoles { get; set; }

        public string Department { get; set; }
    }
}
