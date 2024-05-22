using DatabaseTask.Core.Domain;
using Microsoft.EntityFrameworkCore;


namespace DatabaseTask.Data
{
    public class DatabaseTaskDbContext : DbContext
    {
        public DatabaseTaskDbContext(DbContextOptions<DatabaseTaskDbContext> options)
            : base(options) { }

        // näide, kuidas teha, kui lisate domaini alla ühe objekti
        // migratsioonid peavad tulema siia libary-sse e TARge20.Data alla.
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Child> Children { get; set; }

        public DbSet<SickLeave> SickLeave { get; set; }
        public DbSet<Holiday> Holidays { get; set; }
        public DbSet<HealthInspection> HealthInspections { get; set; }
        public DbSet<Requests> Requests { get; set; }
        public DbSet<Renting> Renting { get; set; }
        public DbSet<Objects> Objects { get; set; }
        public DbSet<WorkingHistory> WorkingHistory { get; set; }
        public DbSet<Job> Jobs { get; set; }
        public DbSet<AccessPermission> AccessPermissions { get; set; }
        public DbSet<Hints> Hints { get; set; }
        public DbSet<Firm> Firms { get; set; }
        public DbSet<BranchOffice> BranchOffice { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            //JOB - EEMPLOYEE
            
            modelBuilder.Entity<Job>()
                .HasMany(j => j.WorkingHistory) // Job has many WorkingHistory
                .WithOne(w => w.Job)             // WorkingHistory has one Job
                .HasForeignKey(w => w.JobId);   // Use JobId as the foreign key

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.WorkingHistory) // Employee has many WorkingHistory
                .WithOne(w => w.Employee)        // WorkingHistory has one Employee
                .HasForeignKey(w => w.EmployeeId); // Use EmployeeId as the foreign key

            // EMPLOYEE-CHILD

                modelBuilder.Entity<Employee>()
                    .HasMany(e => e.Children) // Employee has many children
                    .WithOne(c => c.Employee) // Child belongs to one employee
                    .HasForeignKey(c => c.EmployeeId); // Foreign key

            // EMPLOYEE- SICKLEAVE

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.sickLeaves) 
                .WithOne(s => s.Employee) 
                .HasForeignKey(s => s.EmployeeId);


            // EMPLOYEE- HOLIDAY

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Holidays)
                .WithOne(h => h.Employee)
                .HasForeignKey(h => h.EmployeeId);

            // EMPLOYEE- HEALTHINSPECTION

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.HealthInspections)
                .WithOne(h => h.Employee)
                .HasForeignKey(h=> h.EmployeeId);

            // EMPLOYEE- REQUESTS
            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Requests)
                .WithOne(r => r.Employee)
                .HasForeignKey(r => r.EmployeeId);

            // EMPLOYEE- RENTING
            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Renting)
                .WithOne(r => r.Employee)
                .HasForeignKey(r => r.EmployeeId);

            // OBJECTS- RENTING
            modelBuilder.Entity<Objects>()
                .HasMany(o => o.Renting)
                .WithOne(r => r.Object)
                .HasForeignKey(r =>r.ObjectId);

            // EMPLOYEE- WORKING HISTORY
            modelBuilder.Entity<Employee>()
                .HasMany(e => e.WorkingHistory)
                .WithOne(w => w.Employee)
                .HasForeignKey(w => w.EmployeeId);

            // WORKING HISTORY - JOB
            modelBuilder.Entity<Job>()
                .HasMany(j => j.WorkingHistory)
                .WithOne(w => w.Job)
                .HasForeignKey(w => w.JobId)
                .OnDelete(DeleteBehavior.Restrict); // Disable cascading deletes

            //EMPLOYEE - ACCESSPERMISSIONS
            modelBuilder.Entity<Employee>()
                .HasMany(e => e.AccessPermissions)
                .WithOne(a => a.Employee)
                .HasForeignKey(a => a.EmployeeId);

            // JOB - ACCESSPERMISSIONS
            modelBuilder.Entity<Job>()
                .HasMany(j => j.AccessPermissions) // Job has many AccessPermissions
                .WithOne(a => a.Job)              // AccessPermission has one Job
                .HasForeignKey(a => a.JobId)
                .OnDelete(DeleteBehavior.Restrict);
            
            //HINTS - FIRM
            modelBuilder.Entity<Hints>()
                .HasOne(h => h.Firm)
                .WithMany(f => f.Hints)
                .HasForeignKey(h => h.FirmId)
                .OnDelete(DeleteBehavior.Cascade);

            //FIRM - BRANCHOFFICE
            modelBuilder.Entity<BranchOffice>()
               .HasOne(b => b.Firm)
               .WithMany(f => f.BranchOffices)
               .HasForeignKey(b => b.FirmId)
               .OnDelete(DeleteBehavior.Cascade);
        }   
    }
}

