using PastebinAPI.response;
using PastebinAPI.paste;


namespace PastebinAPI.paste
{
    public interface Paste
    {
        /**
   * Should return the key of the paste.
   *
   * @return The paste key
   */
        string GetKey();

        /**
         * @return The paste title
         */
        string getTitle();

        /**
         * @return The paste size (in bytes)
         */
        long getSize();

        /**
         * @return The language of the paste (in a user-friendly format)
         */
        string getUserFriendlyLanguage();

        /**
         * @return The language of the paste (in a machine-friendly format)
         */
        string getMachineFriendlyLanguage();

        /**
         * @return The number of views of the paste
         */
        int getHits();

        /**
         * @return The visibility of the paste
         */
        PasteVisibility GetVisiblity();

        /**
         * @return The expire duration of the paste
         */
        PasteExpire getExpire();

        /**
         * @return Returns when the paste has been published
         */
        long getPublishDate();

        /**
         * @return Returns how much time left before the paste expires
         */
        long getRemainingTime();

        /**
         * @return Request the paste raw
         */
        Response<string> GetRaw();
    }
}
