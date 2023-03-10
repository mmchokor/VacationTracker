using Microsoft.EntityFrameworkCore;
using WebRevamp.Models;

namespace WebRevamp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> option) : base(option)
        {
        }

        public DbSet<VacationRequest> VacationRequests { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Approval> Approvals { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Employee>()
                .HasMany(e => e.VacationRequests)
                .WithOne(v => v.Employee)
                .HasForeignKey(v => v.EmployeeId);

            modelBuilder.Entity<Approval>()
                .HasOne(a => a.VacationRequest)
                .WithMany(v => v.Approvals)
                .HasForeignKey(a => a.VacationRequestId)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}

