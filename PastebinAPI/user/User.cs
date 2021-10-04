using PastebinAPI.paste;

namespace PastebinAPI.user
{
    public interface  User
    {
        string GetUserName();

        string getAvatarUrl();

        /**
         * @return The user website
         */
        string getWebsite();

        /**
         * @return The user email
         */
        string getEmail();

        /**
         * @return The user location
         */
        string getLocation();

        /**
         * @return The account type
         */
        AccountType getAccountType();

        /**
         * @return The default paste language used by the user
         */
        string getDefaultPasteLanguage();

        /**
         * @return The default paste expiration used by the user
         */
        PasteExpire getDefaultPasteExpiration();

        /**
         * @return The default paste visibility used by the user
         */
        PasteVisibility getDefaultPasteVisibility();
    }
}
