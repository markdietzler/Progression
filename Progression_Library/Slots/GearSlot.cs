
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
            if (gearSlots.Length < 9 || gearSlots.Length > 9)
            {
                throw new ArgumentException("Boolean array must be lengh nine.");
            }
            else
            {
                mGearSlots = gearSlots;
                GearInit(mGearSlots);
            }
        }

        public GearSlot()
        {

        }

        public void GearInit(bool[] key)
        {
            if (key[0])
            {
                Console.WriteLine("making helmet");
                helm = GearFactory.MakeFourSlot("Helmet");
            }
                
            if (key[1])
            {
                Console.WriteLine("making chest");
                chest = GearFactory.MakeSixSlot("Chest");
            }
                
            if (key[2])
            {
                Console.WriteLine("making gloves");
                gloves = GearFactory.MakeFourSlot("Gloves");
            }
                
            if (key[3])
            {
                Console.WriteLine("making boots");
                boots = GearFactory.MakeFourSlot("Boots");
            }
                
            if (key[4])
            {
                Console.WriteLine("making main hand");
                mainHand = GearFactory.MakeThreeSlot("Main Hand");
            }
                
            if (key[5])
            {
                Console.WriteLine("making off hand");
                offHand = GearFactory.MakeThreeSlot("Off Hand");
            }
                
            if (key[6])
            {
                Console.WriteLine("making ring one");
                rightRing = GearFactory.MakeOneSlot("Right Rihg");
            }
                
            if (key[7])
            {
                Console.WriteLine("making ring 2");
                leftRing = GearFactory.MakeOneSlot("Left Ring");
            }
                
            if (key[8])
            {
                Console.WriteLine("making two hand");
                two_hand = GearFactory.MakeSixSlot("Two Hand");
            }
                
        }

        public void ConfigureChest()
        {
            
        }

        public void ConfigureHelm()
        {

        }

        public void ConfigureGloves()
        {

        }

        public void ConfigureBoots()
        {

        }

        public void ConfigureTwoHand()
        {

        }

        public void ConfigureMainHand()
        {

        }

        public void ConfigureOffHand()
        {

        }

        public void ConfigureRingOne()
        {

        }

        public void ConfigureRingTwo()
        {

        }

        public void SetTrue(int slot)
        {
            if (SlotCheck(slot))
            {
                mGearSlots[slot] = true;
            }
            else
            {
                throw new IndexOutOfRangeException("Index " + slot + " is outside the allowed values (0-9)");
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
                throw new IndexOutOfRangeException("Index " + slot + " is outside the allowed values (0-9)");
            }
        }

        public override string ToString()
        {
            return "Gear: ";
        }

        private bool SlotCheck(int slot)
        {
            if (slot < 0 || slot > mGearSlots.Length - 1)
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
