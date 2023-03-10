using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebRevamp.Models
{
    public class Approval
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("VacationRequest")]
        public int VacationRequestId { get; set; }
        public int ApproverId { get; set; }
        public DateTime ApprovalDate { get; set; }


        [InverseProperty("Approvals")]
        public virtual VacationRequest VacationRequest { get; set; }
        public virtual Employee? Approver { get; set; }
    }
}
