using System;

namespace ArcadiaParties.Data.Abstractions.DTOs
{
    public class DetailedUserFromAssistantDTO
    {
        public string employeeId { get; set; }

        public string name { get; set; }

        public string departmentId { get; set; }

        public DateTime birthDate { get; set; }

        public DateTime hireDate { get; set; }
    }
}
