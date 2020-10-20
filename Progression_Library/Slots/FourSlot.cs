using System;

namespace Progression_Library.Slots
{
    public class FourSlot
    {
        string label;

        string[] skills = new string[4];

        public FourSlot()
            : this ("Default 4 Socket Item",
                  "___ 1 ___",
                  "___ 2 ___",
                  "___ 3 ___",
                  "___ 4 ___")
        {
            
        }

        public FourSlot(string newLabel, string topLeft, string topRight, string lowerRight, string lowerLeft)
        {
            if (CheckInput(newLabel) || CheckInput(topLeft) || CheckInput(topRight) || CheckInput(lowerLeft) || CheckInput(lowerRight))
            {
                throw new ArgumentException("One of the given weapon swap 1 main hand skills was empty or null");
                
            } else
            {
                label = newLabel;
                skills[0] = topLeft;
                skills[1] = topRight;
                skills[2] = lowerRight;
                skills[3] = lowerLeft;
            }

        }

        public FourSlot(string topLeft, string topRight, string lowerRight, string lowerLeft)
        {
            if (CheckInput(topLeft) || CheckInput(topRight) || CheckInput(lowerLeft) || CheckInput(lowerRight))
            {
                throw new ArgumentException("One of the given weapon swap 1 main hand skills was empty or null");
                
            }
            else
            {
                label = "Default 4 Socket Item";
                skills[0] = topLeft;
                skills[1] = topRight;
                skills[2] = lowerRight;
                skills[3] = lowerLeft;
            }

        }

        public void SetSkill(int slot, string newSkill)
        {
            if (CheckSlot(slot))
            {
                if (CheckInput(newSkill))
                {
                    throw new ArgumentException("New " + label + " skill for slot " + slot + "  can't be null or empty.");
                } else
                {

                    skills[slot] = newSkill;
                }
            } else
            {
                throw new IndexOutOfRangeException("Slot " + slot + " is not in the allowable slot range (0-3)");
            }
        }

        public string GetSkill(int slot)
        {
            if(CheckSlot(slot))
            {
                return skills[slot];
            } else
            {
                throw new IndexOutOfRangeException("Slot " + slot + " is not in the allowable slot range (0-3)");
            }
        }

        public void SetLabel(string newLabel)
        {
            if(CheckInput(newLabel))
            {
                throw new ArgumentException("New " + newLabel + " can't be null or empty.");
            } else
            {
                label = newLabel;
            }            
        }

        public string GetLabel() => label;

        public int GetLength()
        {
            return skills.Length;
        }

        public override string ToString()
        {
            return "1: " + skills[0] + " 2: " + skills[1] + " 3: " + skills[2] + " 4: " + skills[3];
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
