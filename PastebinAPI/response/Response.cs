
namespace PastebinAPI.response
{
    public interface Response<T>
    {
        T Get();

        bool HasError();

        string GetError();
    }
}
