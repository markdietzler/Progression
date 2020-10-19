using System;
using System.Reflection.Emit;

namespace Progression_Library.Slots
{
    class ThreeSlot
    {
        string equipmentType = "XYZ";

        string[] skills = new string[3];

        public ThreeSlot()
        {
            skills[0] = "___ 1 ___";
            skills[1] = "___ 2 ___";
            skills[2] = "___ 3 ___";
        }

        public ThreeSlot(string newEquipment, string topSkill, string middleSkill, string bottomSkill)
        {
            if (CheckInput(newEquipment) || CheckInput(topSkill) || CheckInput(middleSkill) || CheckInput(bottomSkill))
            {
                equipmentType = newEquipment;
                skills[0] = topSkill;
                skills[1] = middleSkill;
                skills[2] = bottomSkill;
            }
            else
            {
                throw new ArgumentException("One of the given one hand weapon skills was empty or null");
            }

        }

        public void SetSkill(int slot, string newSkill)
        {
            if (CheckSlot(slot))
            {
                if (CheckInput(newSkill))
                {
                    skills[slot] = newSkill;
                }
                else
                {
                    throw new ArgumentException("The new " + equipmentType + " skill for " + slot + " is empty or null.");
                }

            }
            else
            {
                throw new IndexOutOfRangeException("Slot " + slot + " is not in the allowed range (0-2)");
            }
        }

        private bool CheckInput(string checkME)
        {
            return string.IsNullOrEmpty(checkME);
        }

        private bool CheckSlot(int slotToCheck)
        {
            if (slotToCheck < 0 || slotToCheck > skills.Length - 1)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
