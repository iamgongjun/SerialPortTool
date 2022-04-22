using System;
using System.Globalization;
using System.Windows.Data;

namespace LongerPumpDemo.Converter
{
    public class OpenSerialPortConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            if (values == null) throw new ArgumentNullException("参数为NULL");
            foreach (var item in values) 
            {
                if (item==null||item.ToString()=="") return false;
            }
            return true;
        }

        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
