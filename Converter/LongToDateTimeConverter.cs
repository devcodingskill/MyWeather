using System.Globalization;

namespace MyWeather.Converter
{
    public class LongToDateTimeConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is int ticks)
            {
                return new DateTime(ticks);
            }
            if (value is long tick)
            {
               return new DateTime(tick);
            }
            // Fallback value, could also be something else
            return DateTime.MinValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return Binding.DoNothing;
        }
    }
}
