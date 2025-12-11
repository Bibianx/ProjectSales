using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Models.Entities
{
    [Index(nameof(LastName))]
    public class Employees
    {
        [Key]
        public Guid EmployeeId { get; set; } = Guid.NewGuid();
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public DateOnly? BirthDate { get; set; }
        public string Notes { get; set; }
    }
}