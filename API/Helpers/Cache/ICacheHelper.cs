namespace API.Helpers.Cache
{
    public interface ICacheHelper
    {
        public T? Get<T>(string key);
        public void Set<T>(string key, T value);
    }
}
