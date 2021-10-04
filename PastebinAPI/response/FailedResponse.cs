using System;

namespace PastebinAPI.response
{
    public class FailedResponse<T> : Response<T>
    {
        private string reason;

        public FailedResponse(string new_reason)
        {
            this.reason = new_reason;
        }
                
        public T Get()
        {
            // TODO replace with specific exception
            throw new Exception();
        }

        public bool HasError()
        {
            return true;
        }

        public string GetError()
        {
            return reason;
        }
    }
}
