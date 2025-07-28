using System.Globalization;
using Microsoft.Maui.Controls;
using Microsoft.Maui.Graphics;

namespace RecipeVault.Services
{
    public class DarkenColorConverter : IValueConverter
    {
        public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is Color color)
            {

                return color.WithLuminosity((float)(color.GetLuminosity() * 0.8));
            }

            return value;
        }

        public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            return ConvertBack(value, targetType, parameter, culture);
        }
    }
}
