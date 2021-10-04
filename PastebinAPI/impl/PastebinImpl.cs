using PastebinAPI.paste;
using PastebinAPI.response;
using PastebinAPI.paste.internal_paste;
using PastebinAPI.user;
using PastebinAPI.internal_utils.utils;
using System.Collections.Generic;

namespace PastebinAPI.impl
{
    public class PastebinImpl : Pastebin 
    {
        public const int DEFAULT_NUMBER_OF_PASTES = 50;
        private string _Developer_Key;

        public Response<bool> DeletePaste(string pasteKey, string userKey)
        {
            throw new System.NotImplementedException();
        }

        public Response<List<Paste>> GetPastesOf(string userKey)
        {
            throw new System.NotImplementedException();
        }

        public Response<List<Paste>> GetPastesOf(string userKey, int limit)
        {
            throw new System.NotImplementedException();
        }

        public Response<string> GetRawPaste(string pasteKey)
        {
            throw new System.NotImplementedException();
        }

        public Response<List<Paste>> GetTrendingPastes()
        {
            throw new System.NotImplementedException();
        }

        public Response<User> GetUser(string userKey)
        {
            throw new System.NotImplementedException();
        }

        public Response<string> Login(string userName, string password)
        {
            throw new System.NotImplementedException();
        }

        public Response<string> post(Paste paste)
        {
            throw new System.NotImplementedException();
        }

        public Response<string> post(Paste paste, string userKey)
        {
            throw new System.NotImplementedException();
        }
    }
}
