using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;

namespace ExplorerGX.Desktop.Windows
{
    public abstract class BaseMultiValueConverter<TConverter> : MarkupExtension, IMultiValueConverter
        where TConverter : BaseMultiValueConverter<TConverter>, new()
    {
        private static TConverter _converter;

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return _converter ?? (_converter = new TConverter());
        }

        public abstract object Convert(object[] values, Type targetType, object parameter, CultureInfo culture);

        public virtual object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) => throw new NotImplementedException();
    }
}
