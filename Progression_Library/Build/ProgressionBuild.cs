using Progression_Library.Slots;
using System;
using System.Collections.Generic;
using System.Text;

namespace Progression_Library.Classes
{
    public class ProgressionBuild
    {
        #region variables

        //gear design selector:
        //0 = main hand/off hand with gloves and boots
        //1 = two hand/bow with gloves and boots
        //2 = facebreaker (empty hands)
        //3 = main hand/off hand with gloves and Kaom's Roots
        //4 = two hand with gloves and Kaom's Roots
        //5 = main hand/off hand with gloves and Kaom's Heart
        //6 = two hand with gloves and Kaom's Roots
        //7 
        //8 

        private int type = 0;

        //empty gear slot variables

        private FourSlot helm;
        private FourSlot gloves;
        private FourSlot? boots;
        private ThreeSlot? mainHand;
        private ThreeSlot? offHand;
        private SixSlot? twoHand;
        private SixSlot? chest;
        private OneSlot? leftRing;
        private OneSlot? rightRing;

        #endregion

        //standard constructor for the two known gear types and the selector

        public ProgressionBuild(int givenType, FourSlot helmet, FourSlot givenGloves)
        {
            type = givenType;
            helm = helmet;
            gloves = givenGloves;
        }

        //TODO constructors for various gear configurations

    }
}
