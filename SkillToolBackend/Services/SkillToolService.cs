using Microsoft.EntityFrameworkCore;
using SkillToolBackend.Data;
using SkillToolBackend.Models.SkillTool;
using System.Linq;

namespace SkillToolBackend.Services {
    public interface ISkillToolService {
        bool AddEmployee(string firstName, string lastName, string location, out Employee employee);
        bool GetEmployee(int employeeId, out Employee employee);
        bool GetEmployees(out IEnumerable<Employee> employees);
        bool RemoveEmployee(int id, out IEnumerable<Employee> employees);
        bool AddSkill(int employeeId, int skillId, int rating, out Employee employee);
        bool GetEmployeeSkill(int employeeId, int skillId, out EmployeeSkill employeeSkill);
        bool GetEmployeeSkills(int employeeId, out IEnumerable<EmployeeSkill> employeeSkills);
        bool RemoveEmployeeSkill(int employeeId, int skillId, out IEnumerable<EmployeeSkill> employeeSkills);
    }

    public class SkillToolService : ISkillToolService {
        public bool AddEmployee(string firstName, string lastName, string location, out Employee employee) {
            using var db = new SkillToolDbContext();
            employee = null;

            if (IsEmployeeAlreadyExist(firstName, lastName, location)) {
                return false;
            }

            employee = db.Add(new Employee { FirstName = firstName, LastName = lastName, Location = location }).Entity;
            db.SaveChanges();

            return true;
        }

        public bool GetEmployee(int employeeId, out Employee employee) {
            employee = FindEmployeeById(employeeId);
            return employee != null;
        }

        public bool GetEmployees(out IEnumerable<Employee> employees) {
            employees = GetEmployees();
            return employees != null;
        }

        public bool RemoveEmployee(int employeeId, out IEnumerable<Employee> employees) {
            using var db = new SkillToolDbContext();
            employees = null;

            Employee employee = FindEmployeeById(employeeId);

            if (employee != null) {
                db.Remove(employee);
                db.SaveChanges();
                employees = GetEmployees();
                return true;
            }

            return false;
        }

        public bool AddSkill(int employeeId, int skillId, int rating, out Employee employee) {
            using var db = new SkillToolDbContext();

            employee = db.Employees.First<Employee>(employee => employee.EmployeeId == employeeId);
            Skill skill = db.Skills.First<Skill>(skill => skill.SkillId == skillId);

            // Das geht bestimmt einfacher?
            if (IsSkillAlreadyExist(employeeId, skillId)) {
                return false;
            }

            EmployeeSkill employeeSkill = new EmployeeSkill();

            db.EmployeeSkills.Add(employeeSkill);

            employeeSkill.Employee = employee;
            employeeSkill.Skill = skill;
            employeeSkill.Rating = rating;

            // Bringt scheinbar nichts?
            employee.EmployeeSkills.Add(employeeSkill);

            skill.EmployeeSkills.Add(employeeSkill);

            db.SaveChanges();

            return true;
        }

        public bool GetEmployeeSkill(int employeeId, int skillId, out EmployeeSkill employeeSkill) {
            using (var db = new SkillToolDbContext()) {
                employeeSkill = null;

                Employee employee = FindEmployeeById(employeeId);

                if (employee == null) {
                    return false;
                }

                employeeSkill = FindSkillBySkillId(employee.EmployeeSkills, skillId);

                if (employeeSkill == null) {
                    return false;
                }

                return true;
            }
        }

        public bool GetEmployeeSkills(int employeeId, out IEnumerable<EmployeeSkill> employeeSkills) {
            using (var db = new SkillToolDbContext()) {
                employeeSkills = null;

                Employee employee = FindEmployeeById(employeeId);

                if (employee == null) {
                    return false;
                }

                employeeSkills = employee.EmployeeSkills;

                return true;
            }
        }

        public bool RemoveEmployeeSkill(int employeeId, int skillId, out IEnumerable<EmployeeSkill> employeeSkills) {
            using (var db = new SkillToolDbContext()) {
                employeeSkills = null;

                Employee employee = FindEmployeeById(employeeId);

                if (employee == null) {
                    return false;
                }

                EmployeeSkill employeeSkill = FindSkillBySkillId(employee.EmployeeSkills, skillId);

                if (employeeSkill == null) {
                    return false;
                }

                db.Remove(employeeSkill);
                db.SaveChanges();

                employeeSkills = employee.EmployeeSkills;

                return true;
            }
        }

        private bool IsEmployeeAlreadyExist(string firstName, string lastName, string location) {
            using var db = new SkillToolDbContext();

            List<Employee> existingEmployees = db.Employees.ToList();
            foreach (Employee existingEmployee in existingEmployees) {
                if (existingEmployee.FirstName == firstName
                    && existingEmployee.LastName == lastName
                    && existingEmployee.Location == location) {
                    return true;
                }
            }

            return false;
        }

        private List<Employee> GetEmployees() {
            using var db = new SkillToolDbContext();
            return db.Employees.Include(employee => employee.EmployeeSkills).ThenInclude(employeeSkill => employeeSkill.Skill).ToList();
        }

        private Employee FindEmployeeById(int employeeId) {
            foreach (Employee employee in GetEmployees()) {
                if (employee.EmployeeId == employeeId) {
                    return employee;
                }
            }

            return null;
        }

        private EmployeeSkill FindSkillBySkillId(List<EmployeeSkill> employeeSkills, int skillId) {
            foreach (EmployeeSkill employeeSkill in employeeSkills) {
                if (employeeSkill.SkillId == skillId) {
                    return employeeSkill;
                }
            }

            return null;
        }

        private bool IsSkillAlreadyExist(int employeeId, int skillId) {
            Employee existingEmployee = FindEmployeeById(employeeId);
            EmployeeSkill existingEmployeeSkill = null;

            if (existingEmployee != null) {
                existingEmployeeSkill = FindSkillBySkillId(existingEmployee.EmployeeSkills, skillId);
            }
            else {
                return false;
            }

            if (existingEmployeeSkill != null) {
                return true;
            }

            return false;
        }
    }
}