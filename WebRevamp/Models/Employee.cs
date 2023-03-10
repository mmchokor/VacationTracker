using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebRevamp.Models
{
    public class Employee
    {
        [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Role { get; set; }

        public virtual ICollection<VacationRequest> VacationRequests { get; set; }   // collection navigation property
        public virtual ICollection<Approval> Approvals { get; set; }
    }

}
