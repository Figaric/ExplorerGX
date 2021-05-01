using System;
using System.Globalization;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Windows.Markup;

namespace ExplorerGX.Desktop.Windows
{
    public class MultiplyConverter : MarkupExtension, IMultiValueConverter
    {
        private static MultiplyConverter _converter;

        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            double result = 1;

            values
                .ToList()
                .ForEach(v => result *= (double)v);

            return result;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return _converter ?? (_converter = new MultiplyConverter());
        }
    }
}
