using PastebinAPI.paste;
using PastebinAPI.response;
using PastebinAPI.user;
using System.Collections.Generic;

namespace PastebinAPI
{
    public interface Pastebin
    {
        /**
         * Should post the Paste passed as parameter in Pastebin.
         * @param paste The paste to share
         * @return The result of the request to post the paste. If everything is OK, it should return the paste url (or key)
         */

        Response<string> post(Paste paste);

        /**
         * Should post the Paste passed as parameter in Pastebin using the userKey passed
         * as parameter if not null.
         *
         * The user key should be used to assign the Paste to the user.
         *
         * @param paste The paste to share
         * @param userKey The userKey to use if not null.
         * @return The result of the request to post the paste. If everything is OK, it should return the paste url (or key)
         */

        Response<string> post(Paste paste, string userKey);

        /**
         * @return Should read and return pastebin trending pastes
         */

        Response<List<Paste>> GetTrendingPastes();

        /**
         * @param pasteKey The paste key
         * @return Should read the paste raw code and return it
         */

        Response<string> GetRawPaste(string pasteKey);

        /**
         * Should try to login the user using the credentials passed as argument.
         *
         * @param userName The username
         * @param password The password
         * @return The request to login the user. If everything is OK, it should contains the user_key
         */

        Response<string> Login(string userName, string password);

        /**
         * Should read the information of the user represented by the userKey passed as argument
         *
         * @param userKey User key
         * @return The request to get user information. If everything is OK, it should return an User
         * object contains the user informations.
         */

        Response<User> GetUser(string userKey);

        /**
         * Should read all the pastes of the user represented by the userKey passed as
         * argument.
         *
         * @param userKey The user key
         * @return The request to read user pastes. If everything is OK, it should return a List
         * contains all the user pastes. If the user doesn't have any paste, it should return
         * an empty list.
         */

        Response<List<Paste>> GetPastesOf(string userKey);

        /**
         * Should read all the pastes of the user represented by the userKey passed as
         * argument.
         *
         * @param userKey The user key
         * @param limit How many items it should return
         * @return The request to read user pastes. If everything is OK, it should return a List
         * contains all the user pastes. If the user doesn't have any paste, it should return
         * an empty list.
         */

        Response<List<Paste>> GetPastesOf(string userKey, int limit);

        /**
         * Should ask to Pastebin to delete the paste assigned to the pasteKey passed as argument.
         *
         * The userKey should be used to check if the user can delete the paste.
         *
         * @param pasteKey Paste key.
         * @param userKey User key.
         * @return The request to delete the paste. If everything is OK it will contains true.
         */
        Response<bool> DeletePaste(string pasteKey, string userKey);
    }
}
