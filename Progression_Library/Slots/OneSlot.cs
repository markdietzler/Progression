using System;

namespace Progression_Library.Slots
{
    class OneSlot
    {
        string? skill = "___ 1 ___";


        public OneSlot(string newSkill)
        {
            if (checkInpout(newSkill))
            {
                skill = newSkill;

            }
            else
            {
                throw new ArgumentException("The skill for this ring was empty or null.");
            }

        }

        public void SetSkill(string newSkill)
        {
            if (checkInpout(newSkill))
            {
                skill = newSkill;
            }
            else
            {
                throw new ArgumentException("The new skill for this ring was empty or null.");
            }
        }

        public string GetSkill()
        {
            return skill;
        }

        private bool checkInpout(string checkME)
        {
            return string.IsNullOrEmpty(checkME);
        }
    }
}
