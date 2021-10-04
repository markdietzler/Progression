
namespace PastebinAPI.response
{
    public class SuccessResponse<T> : Response<T>
    {
        private T result;

        public SuccessResponse(T result)
        {
            this.result = result;
        }

        public T Get()
        {
            return result;
        }

        public string GetError()
        {
            return null;
        }

        public bool HasError()
        {
            return false;
        }
    }
}
