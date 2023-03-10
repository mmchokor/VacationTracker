using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace WebRevamp.Models
{
    public class VacationRequest
    {
        [Key]
        public int Id { get; set; }
        public int EmployeeId { get; set; }   // foreign key property
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }
        public string HODApprovalStatus { get; set; }
        public int? HODApproverId { get; set; }
        public string OpsApprovalStatus { get; set; }
        public int? OpsApproverId { get; set; }

        public virtual Employee Employee { get; set; }
        public virtual Employee HODApprover { get; set; }
        public virtual Employee OpsApprover { get; set; }
        public virtual ICollection<Approval> Approvals { get; set; }
    }

}
