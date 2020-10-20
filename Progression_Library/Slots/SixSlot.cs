using System;
using System.Net.Sockets;

namespace Progression_Library.Slots
{
    public class SixSlot
    {
        private string label;
        
        private string[] skills = new string[6];

        public SixSlot()
            : this ("Default Six Socket Item",
                  "___ 1 ___",
                  "___ 2 ___",
                  "___ 3 ___",
                  "___ 4 ___",
                  "___ 5 ___",
                  "___ 6 ___")
        {
            
        }

        public SixSlot(string equipmentType, string topLeft, string topRight, string middleRight, string middleLeft, string lowerLeft, string lowerRight)
        {
            if(CheckInput(topLeft) || CheckInput(topRight) || CheckInput(middleRight) || CheckInput(middleLeft) || CheckInput(lowerLeft) || CheckInput(lowerRight) )
            {
                throw new ArgumentException("One of the given chest skills was empty or null");

            } else
            {
                
                label = equipmentType;
                skills[0] = topLeft;
                skills[1] = topRight;
                skills[2] = middleRight;
                skills[3] = middleLeft;
                skills[4] = lowerLeft;
                skills[5] = lowerRight;
            }            
        }

        public SixSlot(string topLeft, string topRight, string middleRight, string middleLeft, string lowerLeft, string lowerRight)
        {
            if (CheckInput(topLeft) || CheckInput(topRight) || CheckInput(middleRight) || CheckInput(middleLeft) || CheckInput(lowerLeft) || CheckInput(lowerRight))
            {

                label = "Default 6 Socket Item";
                skills[0] = topLeft;
                skills[1] = topRight;
                skills[2] = middleRight;
                skills[3] = middleLeft;
                skills[4] = lowerLeft;
                skills[5] = lowerRight;

            }
            else
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
                    throw new ArgumentException("The new " + label + " skill for slot " + slot + " can't be enpty or null.");
                } else
                {
                    
                    skills[slot] = newSkill;
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
                throw new ArgumentException("Equipment type can't be empty or null.");
            } else
            {
                label = newType;
            }
        }

        public string GetGearType()
        {
            return label;
        }

        public int GetLength()
        {
            return skills.Length;
        }

        public override string ToString()
        {
            return "1: " + skills[0] + " 2: " + skills[1] + " 3: " + skills[2] + " 4: " + skills[3] + " 5: " + skills[4] + " 6: " + skills[5];
        }

        private bool CheckInput(string checkME)
        {
            return string.IsNullOrEmpty(checkME);
        }

        private bool CheckSlot(int slot)
        {
            if(slot < 0 || slot > skills.Length - 1)
            {
                return false;

            } else
            {
                return true;
            }
        }
    }
}
