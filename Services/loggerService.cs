using Newtonsoft.Json;
using System.Diagnostics;
using System.Runtime.CompilerServices;

namespace MyWeather.Services
{
    public class loggerService
    {
        public static loggerService Instance { get; private set; } = new loggerService();
        public loggerService() { }
        //  [CallerFilePath]  need to add value to it otherwise show error because value can be null
        // need to add int?  to make it null able
        public static void TrackError(Exception exception, IDictionary<string, string> property = null, [CallerFilePath] string callerFilePath = null, [CallerMemberName] string callerMemberName = null, [CallerLineNumber] int? callerLineNumber = null)
        {
            var detail = JsonConvert.SerializeObject(property);
            Debug.Write($"{nameof(TrackError)} {exception} {nameof(property)}: {detail}", "[Debug]");
        }
    }
}
