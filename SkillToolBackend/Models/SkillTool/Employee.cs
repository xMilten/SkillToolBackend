namespace SkillToolBackend.Models.SkillTool {
    public class Employee {
        public int EmployeeId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Location { get; set; }

        public virtual List<EmployeeSkill> EmployeeSkills { get; set; } = new List<EmployeeSkill>();
    }
}