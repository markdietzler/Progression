using System;
using System.Net.Sockets;

namespace Progression_Library.Slots
{
    class SixSlot
    {
        private string label = "Default Chest";
        
        private string[] skills = new string[6];

        public SixSlot()
        {
            skills[0] = "___ 1 ___";
            skills[1] = "___ 2 ___";
            skills[2] = "___ 3 ___";
            skills[3] = "___ 4 ___";
            skills[4] = "___ 5 ___";
            skills[5] = "___ 6 ___";
        }

        public SixSlot(string equipmentType, string topLeft, string topRight, string middleRight, string middleLeft, string lowerLeft, string lowerRight)
        {
            if(CheckInput(topLeft) || CheckInput(topRight) || CheckInput(middleRight) || CheckInput(middleLeft) || CheckInput(lowerLeft) || CheckInput(lowerRight) )
            {
                label = equipmentType;
                skills[0] = topLeft;
                skills[1] = topRight;
                skills[2] = middleRight;
                skills[3] = middleLeft;
                skills[4] = lowerLeft;
                skills[5] = lowerRight;

            } else
            {
                throw new ArgumentException("One of the given chest skills was empty or null");
            }
            
        }

        public void SetSkill(int slot, string newSkill)
        {
            if (CheckSlot(slot))
            {
                if(CheckInput(newSkill))
                {
                    skills[slot] = newSkill;
                } else
                {
                    throw new ArgumentException("The new " + label + " skill for slot " + slot + " can't be enpty or null.");
                }                

            } else
            {
                throw new IndexOutOfRangeException("Slot " + slot + " is not in the allowed range (0-5)");
            }            
        }
        
        public string GetSkill(int slot)
        {
            if(CheckSlot(slot))
            {
                return skills[slot];

            } else
            {
                throw new ArgumentException("The given skill slot is not a valid slot number (0-5)");
            }
            
        }

        public void SetType(string newType)
        {
            if(CheckInput(newType))
            {
                label = newType;
            } else
            {
                throw new ArgumentException("Equipment type can't be empty or null.");
            }
        }

        public string GetGearType()
        {
            return label;
        }

        private bool CheckInput(string checkME)
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
