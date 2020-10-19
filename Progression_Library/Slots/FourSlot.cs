using System;

namespace Progression_Library.Slots
{
    class FourSlot
    {
        string equipmentType = "XYZ";
        
        string[]? skills = new string[4];

        public FourSlot()
        {
            skills[0] = "___ 1 ___";
            skills[1] = "___ 2 ___";
            skills[2] = "___ 3 ___";
            skills[3] = "___ 4 ___";
        }

        public FourSlot(string newEquipment, string topLeft, string topRight, string lowerRight, string lowerLeft)
        {
            if(CheckInput(newEquipment) || CheckInput(topLeft) || CheckInput(topRight) || CheckInput(lowerLeft) || CheckInput(lowerRight))
            {
                equipmentType = newEquipment;
                skills[0] = topLeft;
                skills[1] = topRight;
                skills[2] = lowerRight;
                skills[3] = lowerLeft;
            } else
            {
                throw new ArgumentException("One of the given weapon swap 1 main hand skills was empty or null");
            }
            
        }

        public void SetSkill(int slot, string newSkill)
        {
            if(CheckSlot(slot))
            {
                if(CheckInput(newSkill))
                {
                    skills[slot] = newSkill;
                } else
                {
                    throw new ArgumentException("New " + equipmentType + " skill for slot " + slot + "  can't be null or empty.");
                }
            } else
            {
                throw new IndexOutOfRangeException("Slot " + slot + " is not in the allowable slot range (0-3)");
            }
        }

        private bool CheckInput(string checkME)
        {
            return string.IsNullOrEmpty(checkME);
        }

        private bool CheckSlot(int checkMe)
        {
            if(checkMe < 0 || checkMe > skills.Length -1)
            {
                return false;
            } else
            {
                return true;
            }
        }
    }
}
