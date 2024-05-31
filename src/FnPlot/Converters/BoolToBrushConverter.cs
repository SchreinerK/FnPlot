using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media;
using JetBrains.Annotations;
using KsWare.Presentation.Converters;

namespace FnPlot.Converters {

	internal class BoolToBrushConverter : ValueConverterBase {

		[CanBeNull] 
		public Brush True { get; }
		[CanBeNull]
		public Brush False { get; }

		public BoolToBrushConverter([CanBeNull] Brush trueValue, [CanBeNull] Brush falseValue) {
			True = trueValue;
			False = falseValue;
		}

		public override object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
			if (value is bool b) return b ? True : False;
			return False;
		}

	}

}
