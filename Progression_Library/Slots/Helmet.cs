using System;

namespace Progression_Library.Slots
{
    class Helmet
    {
        string[]? skills = new string[3];

        public Helmet()
        {
            skills[0] = "ws1mhTOP";
            skills[1] = "ws1mhMIDDLE";
            skills[2] = "ws1mhBOTTOM";
        }

        public Helmet(string topSkill, string middleSkill, string bottomSkill)
        {
            if(checkInpout(topSkill) || checkInpout(middleSkill) || checkInpout(bottomSkill))
            {
                skills[0] = topSkill;
                skills[1] = middleSkill;
                skills[2] = bottomSkill;
            } else
            {
                throw new ArgumentException("One of the given weapon swap 1 main hand skills was empty or null");
            }
            
        }

        public void setTop(string newSkill)
        {
            if (checkInpout(newSkill))
            {
                skills[0] = newSkill;
            } else
            {
                throw new ArgumentException("The new weapon swap 1 main hand skills top skill was empty or null");
            }            
        }

        public void setMiddle(string newSkill)
        {
            if (checkInpout(newSkill))
            {
                skills[1] = newSkill;
            }
            else
            {
                throw new ArgumentException("The new weapon swap 1 main hand skills middle skill was empty or null");
            }
        }

        public void setBottom(string newSkill)
        {
            if (checkInpout(newSkill))
            {
                skills[2] = newSkill;
            }
            else
            {
                throw new ArgumentException("The new weapon swap 1 main hand skills bottom skill was empty or null");
            }
        }

        private bool checkInpout(string checkME)
        {
            return string.IsNullOrEmpty(checkME);
        }
    }
}
