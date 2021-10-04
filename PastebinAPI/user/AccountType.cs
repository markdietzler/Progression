using System;

namespace PastebinAPI.user
{
    public class AccountType
    {
        const string _Normal = "Normal";
        const string _Pro = "pro";
        private int _Account_value;

        AccountType(int new_value)
        {
            this._Account_value = new_value;
        }

        public int GetValue()
        {
            return _Account_value;
        }

        public static string FromValue(int value)
        {
            switch (value)
            {
                case 0: return _Normal;
                case 1: return _Pro;
            }
            throw new NotSupportedException("Account type with value " + value + " is not supported.");
        }
    }
}
