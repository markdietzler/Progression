
using System;

namespace Progression_Library.Slots
{
    public class GearSlot
    {
        //helm
        private FourSlot? helm;

        //chest
        private SixSlot? chest;

        //main hand
        private ThreeSlot? mainHand;

        //off hand
        private ThreeSlot? offHand;

        //2 hand
        private SixSlot? two_hand;

        //gloves
        private FourSlot? gloves;

        //boots
        private FourSlot? boots;

        //ring1
        private OneSlot? leftRing;

        //ring2
        private OneSlot? rightRing;

        // 1    2     3      4     5  6  7     8     9   10
        //helm chest gloves boots mh oh ring1 ring2 2h? 

        private bool[] mGearSlots = new bool[9];

        public GearSlot(bool[] gearSlots)
        {
            mGearSlots = gearSlots;
        }

        public void SetTrue(int slot)
        {
            if(SlotCheck(slot))
            {
                mGearSlots[slot] = true;
            } else
            {
                throw new IndexOutOfRangeException("");
            }
        }

        public void Setfalse(int slot)
        {
            if (SlotCheck(slot))
            {
                mGearSlots[slot] = false;
            }
            else
            {
                throw new IndexOutOfRangeException("");
            }
        }

        private bool SlotCheck(int slot)
        {
            if(slot < 0 || slot > mGearSlots.Length -1)
            {
                return false;
            } else
            {
                return true;
            }
        }
    }
}
