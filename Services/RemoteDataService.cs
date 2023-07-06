
using System.Net.Http.Json;


namespace MyWeather.Services
{
    public class RemoteDataService
    {
        private HttpClient httpClient = new HttpClient() { Timeout = new TimeSpan(0, 0, 60) };

        private static RemoteDataService instance;

        public static RemoteDataService Instance => instance ??= new RemoteDataService();

        private RemoteDataService() { }

        ~RemoteDataService()
        {
            instance = null;
        }

        public static void DisposeObject()
        {
            instance = null;
        }
        public async Task<T> HttpGet<T>(string url)
        {
            T result = default(T);
            try
            {
                HttpResponseMessage reponse = await httpClient.GetAsync(url);
                if (reponse.IsSuccessStatusCode)
                {
                    result = await reponse.Content.ReadFromJsonAsync<T>();
                }
            }
            catch (Exception)
            {
                return result;
            }
            return result;
        }
    }
}
