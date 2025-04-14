using System.Text.Json.Serialization;

namespace SkillToolBackend.Models.SkillTool {
    public class Skill {
        public int SkillId { get; set; }
        public string Name { get; set; }

        public virtual List<EmployeeSkill> EmployeeSkills { get; set; } = new List<EmployeeSkill>();
    }
}