using Microsoft.EntityFrameworkCore;
using System.Text.Json.Serialization;

namespace SkillToolBackend.Models.SkillTool {
    public class EmployeeSkill {
        public int Rating { get; set; }

        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }

        public int SkillId { get; set; }
        public virtual Skill Skill { get; set; }
    }
}