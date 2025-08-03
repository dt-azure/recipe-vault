using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using System.Globalization;

namespace RecipeVault.Services
{
    public class ItemToIndexConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null || values.Length < 2)
            {
                return 0;
            }

            var collection = values[0] as IList;
            var item = values[1];

            if (collection == null || item == null)
            {
                return 0;
            }

            var index = collection.IndexOf(item);
            return index + 1;

        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
