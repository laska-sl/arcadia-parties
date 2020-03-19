using System;

namespace ArcadiaParties.Data.Abstractions.DTOs
{
    class DetailedUserFromAssistantDTO
    {
        public string EmployeeId { get; set; }

        public string Name { get; set; }

        public string DepartmentId { get; set; }

        public DateTime BirthDate { get; set; }

        public DateTime HireDate { get; set; }
    }
}
