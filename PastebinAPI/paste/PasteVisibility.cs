using System;

namespace PastebinAPI.paste
{
    public class PasteVisibility
    {

        const int Private = 2;
        const int Unlisted = 1;
        const int Public = 0;
        private int _Value;

        PasteVisibility(int new_value)
        {
            this._Value = new_value;
        }

        public int GetValue()
        {
            return _Value;
        }

        public static int FromValue(int value)
        {
            switch (value)
            {
                case 0: return Public;
                case 1: return Unlisted;
                case 2: return Private;
            }

            throw new NotSupportedException("Unsupported visibility level");
        }
        
    }
}
