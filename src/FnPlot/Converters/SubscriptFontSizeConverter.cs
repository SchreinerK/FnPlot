using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KsWare.Presentation.Converters;

namespace FnPlot.Converters {

	internal class SubscriptFontSizeConverter : ValueConverterBase {

		public static readonly SubscriptFontSizeConverter Default = new SubscriptFontSizeConverter();

		public override object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
			if (value is double fontSize) {
				return fontSize * 0.8; // Adjust the subscript font size relative to the parent TextBlock's font size
			}
			return value;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
			throw new NotImplementedException();
		}
	}
}
