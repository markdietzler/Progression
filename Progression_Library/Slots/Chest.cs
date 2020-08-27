using System;

namespace Progression_Library.Slots
{
    class Chest
    {
        private string[] skills = new string[6];

        public Chest()
        {
            skills[0] = "ws1mhTOP";
            skills[1] = "ws1mhMIDDLE";
            skills[2] = "ws1mhBOTTOM";
        }

        public Chest(string topSkill, string middleSkill, string bottomSkill)
        {
            if(CheckInpout(topSkill) || CheckInpout(middleSkill) || CheckInpout(bottomSkill))
            {
                skills[0] = topSkill;
                skills[1] = middleSkill;
                skills[2] = bottomSkill;
            } else
            {
                throw new ArgumentException("One of the given weapon swap 1 main hand skills was empty or null");
            }
            
        }

        public void setTop(int slot, string newSkill)
        {
            if (CheckInpout(newSkill) || CheckSlot(slot))
            {
                skills[slot] = newSkill;
            } else
            {
                throw new ArgumentException("The new two hand skill was empty or null");
            }            
        }        

        private bool CheckInpout(string checkME)
        {
            return string.IsNullOrEmpty(checkME);
        }

        private bool CheckSlot(int slot)
        {
            if(slot < 0 || slot > skills.Length)
            {
                return false;
            } else
            {
                return true;
            }
        }
    }
}
