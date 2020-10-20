using Progression_Library.Defaults;
using System;
using System.Reflection.Emit;

namespace Progression_Library.Slots
{
    public class ThreeSlot
    {
        string label;

        string[] skills = new string[3];

        public ThreeSlot()
            : this("Default 3 Socket Item", "___ 1 ___", "___ 2 ___", "___ 3 ___")
        {
            
        }

        public ThreeSlot(string newEquipment, string topSkill, string middleSkill, string bottomSkill)
        {
            if (CheckInput(newEquipment) || CheckInput(topSkill) || CheckInput(middleSkill) || CheckInput(bottomSkill))
            {
                throw new ArgumentException("One of the given one hand weapon skills was empty or null");
                
            }
            else
            {
                label = newEquipment;
                skills[0] = topSkill;
                skills[1] = middleSkill;
                skills[2] = bottomSkill;
            }

        }

        public ThreeSlot(string topSkill, string middleSkill, string bottomSkill)
        {
            if (CheckInput(topSkill) || CheckInput(middleSkill) || CheckInput(bottomSkill))
            {
                throw new ArgumentException("One of the given one hand weapon skills was empty or null");
                
            }
            else
            {
                label = "Default 3 Socket Item";
                skills[0] = topSkill;
                skills[1] = middleSkill;
                skills[2] = bottomSkill;
            }

        }

        public void SetSkill(int slot, string newSkill)
        {
            if (CheckSlot(slot))
            {
                if (CheckInput(newSkill))
                {
                    throw new ArgumentException("The new " + label + " skill for " + slot + " is empty or null.");
                    
                }
                else
                {
                    skills[slot] = newSkill;
                }

            }
            else
            {
                throw new IndexOutOfRangeException("Slot " + slot + " is not in the allowed range (0-2)");
            }
        }

        public string GetSkill(int slot)
        {
            if(CheckSlot(slot))
            {
                return skills[slot];
            } else
            {
                throw new IndexOutOfRangeException("Slot " + slot + " is not in the allowed range (0-2)");
            }
        }

        public void SetLabel(string newLabel)
        {
            if(CheckInput(newLabel))
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

        public int GetLength()
        {
            return skills.Length;
        }

        public override string ToString()
        {
            return "1: " + skills[0] + " 2: " + skills[1] + " 3: " + skills[2];
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
