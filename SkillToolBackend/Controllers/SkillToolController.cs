using Microsoft.AspNetCore.Mvc;
using SkillToolBackend.Models.SkillTool;
using SkillToolBackend.Services;

namespace SkillToolBackend.Controllers {
    [ApiController]
    [Route("[controller]")]
    public class SkillToolController : ControllerBase {
        // Todo Logger
        private ISkillToolService _employeeService;

        public SkillToolController(ISkillToolService employeeService) {
            // Dependency injection (Constructor Injection)
            _employeeService = employeeService;
        }

        [HttpPost("AddEmployee-{firstName}-{lastName}-{location}")]
        public Employee AddEmployee(string firstName, string lastName, string location) {
            return _employeeService.AddEmployee(firstName, lastName, location, out Employee employee) ? employee : null;
        }

        [HttpGet("GetEmployee-{employeeId}")]
        public Employee GetEmployee(int employeeId) {
            return _employeeService.GetEmployee(employeeId, out Employee employee) ? employee : null;
        }

        [HttpGet("GetEmployees")]
        public IEnumerable<Employee> GetEmployees() {
            return _employeeService.GetEmployees(out IEnumerable<Employee> employees) ? employees : null;
        }

        [HttpDelete("RemoveEmployee-{employeeId}")]
        public IEnumerable<Employee> RemoveEmployee(int employeeId) {
            return _employeeService.RemoveEmployee(employeeId, out IEnumerable<Employee> employees) ? employees : null;
        }

        [HttpPost("AddEmployeeSkill-{employeeId}-{skillId}-{rating}")]
        public Employee AddEmployeeSkill(int employeeId, int skillId, int rating) {
            return _employeeService.AddSkill(employeeId, skillId, rating, out Employee employee) ? employee : null;
        }

        [HttpGet("GetEmployeeSkill-{employeeId}-{skillId}")]
        public EmployeeSkill GetEmployeeSkill(int employeeId, int skillId) {
            return _employeeService.GetEmployeeSkill(employeeId, skillId, out EmployeeSkill employeeSkill) ? employeeSkill : null;
        }

        [HttpGet("GetEmployeeSkills-{employeeId}")]
        public IEnumerable<EmployeeSkill> GetEmployeeSkills(int employeeId) {
            return _employeeService.GetEmployeeSkills(employeeId, out IEnumerable<EmployeeSkill> employeeSkills) ? employeeSkills : null;
        }

        [HttpDelete("RemoveEmployeeSkill-{employeeId}-{skillId}")]
        public IEnumerable<EmployeeSkill> RemoveEmployeeSkill(int employeeId, int skillId) {
            return _employeeService.RemoveEmployeeSkill(employeeId, skillId, out IEnumerable<EmployeeSkill> employeeSkills) ? employeeSkills : null;
        }
    }
}