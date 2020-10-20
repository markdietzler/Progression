using System;

namespace Progression_Library.Slots
{
    public class OneSlot
    {
        string label;

        string skill;

        public OneSlot()
            : this("Default 1 Socket Item", "___ 1 ___")
        {

        }


        public OneSlot(string newLabel, string newSkill)
        {
            if (CheckInput(newLabel) || CheckInput(newSkill))
            {

                throw new ArgumentException("The skill for this ring was empty or null.");
            }
            else
            {
                
                label = newLabel;
                skill = newSkill;
            }

        }

        public void SetSkill(string newSkill)
        {
            if (CheckInput(newSkill))
            {
                throw new ArgumentException("The new skill for this ring was empty or null.");
            }
            else
            {
                skill = newSkill;
            }
        }

        public string GetSkill()
        {
            return skill;
        }

        public void SetLabel(string newLabel)
        {
            if (CheckInput(newLabel))
            {
                throw new ArgumentException("New gear label " + newLabel + " cannot be empty or null.");
            } else
            {
                label = newLabel;
            }
        }

        public string GetLabel()
        {
            return label;
        }

        public override string ToString()
        {
            return "1: " + skill;
        }

        private bool CheckInput(string checkME)
        {
            return string.IsNullOrEmpty(checkME);
        }
    }
}
