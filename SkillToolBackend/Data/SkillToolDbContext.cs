using Microsoft.EntityFrameworkCore;
using SkillToolBackend.Models.SkillTool;

namespace SkillToolBackend.Data {
    public class SkillToolDbContext : DbContext {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Skill> Skills { get; set; }
        public DbSet<EmployeeSkill> EmployeeSkills { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder options)
            => options.UseSqlite("Data Source=skilltool.db");

        protected override void OnModelCreating(ModelBuilder modelBuilder) {

            #region seed data

            Employee[] employees = new Employee[] {
                new Employee { EmployeeId = 1, FirstName = "Rolf", LastName = "Augustin", Location = "Bremen" },
                new Employee { EmployeeId = 2, FirstName = "Mario", LastName = "Theuner", Location = "Bielefeld" },
                new Employee { EmployeeId = 3, FirstName = "Timo", LastName = "Heil", Location = "Cottbus" },
                new Employee { EmployeeId = 4, FirstName = "Lilly", LastName = "Steinkamp", Location = "Berlin" },
                new Employee { EmployeeId = 5, FirstName = "Irmgard", LastName = "Seifried", Location = "Bremen" },
                new Employee { EmployeeId = 6, FirstName = "Ilja", LastName = "Lohmann", Location = "Berlin" }
            };

            modelBuilder.Entity<Employee>().HasData(employees);

            Skill[] skills = new Skill[] {
                new Skill { SkillId = 1, Name = "C"},
                new Skill { SkillId = 2, Name = "C++"},
                new Skill { SkillId = 3, Name = "C#"},
                new Skill { SkillId = 4, Name = "PHP"},
                new Skill { SkillId = 5, Name = "Java"},
                new Skill { SkillId = 6, Name = "JavaScript"},
            };

            modelBuilder.Entity<Skill>().HasData(skills);

            modelBuilder.Entity<EmployeeSkill>()
                .HasKey(employeeSkill => new { employeeSkill.EmployeeId, employeeSkill.SkillId });

            modelBuilder.Entity<EmployeeSkill>()
                .HasOne(employeeSkill => employeeSkill.Employee)
                .WithMany(employee => employee.EmployeeSkills)
                .HasForeignKey(employeeSkill => employeeSkill.EmployeeId);

            modelBuilder.Entity<EmployeeSkill>()
                .HasOne(employeeSkill => employeeSkill.Skill)
                .WithMany(skill => skill.EmployeeSkills)
                .HasForeignKey(employeeSkill => employeeSkill.EmployeeId);

            EmployeeSkill[] employeeSkills = new EmployeeSkill[] {
                new EmployeeSkill { EmployeeId = 1, SkillId = 1, Rating = 8 },
                new EmployeeSkill { EmployeeId = 1, SkillId = 2, Rating = 7 },
                new EmployeeSkill { EmployeeId = 2, SkillId = 5, Rating = 8 },
                new EmployeeSkill { EmployeeId = 3, SkillId = 4, Rating = 9 },
                new EmployeeSkill { EmployeeId = 3, SkillId = 6, Rating = 5 },
                new EmployeeSkill { EmployeeId = 4, SkillId = 5, Rating = 9 },
                new EmployeeSkill { EmployeeId = 5, SkillId = 3, Rating = 7 },
                new EmployeeSkill { EmployeeId = 5, SkillId = 5, Rating = 8 },
                new EmployeeSkill { EmployeeId = 6, SkillId = 6, Rating = 10 },
                new EmployeeSkill { EmployeeId = 6, SkillId = 4, Rating = 6 }
            };

            modelBuilder.Entity<EmployeeSkill>().HasData(employeeSkills);

            #endregion

            base.OnModelCreating(modelBuilder);
        }
    }
}