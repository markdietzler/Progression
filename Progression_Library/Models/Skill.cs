
namespace Progression_Library.Models
{
    public class Skill
    {
        public string SkillName { get; set; } = "";

        public Skill(string newSkillName)
        {
            SkillName = newSkillName;
        }
    }
}
