using DataGridBindingExampleCore.Models;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows;
using System.Windows.Data;

namespace DataGridBindingExampleCore.Converters
{
    public class ConvProvinceID : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            int i = 0;

            if (values[0] != DependencyProperty.UnsetValue)
            {
                i = (int)values[0];
            }

            IList<ProvincesModel> l = (IList<ProvincesModel>)values[1];
            return i > 0 && (l.Count > 0) ? l[i - 1].ProvinceName : string.Empty;
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

    }

}
