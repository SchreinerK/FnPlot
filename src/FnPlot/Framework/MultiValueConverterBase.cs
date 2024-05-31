using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using KsWare.Presentation.Converters;

namespace FnPlot.Framework {

	public abstract class MultiValueConverterBase : ValueConverterBase, IMultiValueConverter {


		public abstract object Convert(object[] values, Type targetType, object parameter, CultureInfo culture);
		public abstract object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture);

	}
}
