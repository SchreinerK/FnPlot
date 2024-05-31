using System;
using System.Globalization;
using System.Windows;
using JetBrains.Annotations;
using KsWare.Presentation.Converters;

namespace FnPlot.Converters {

	internal class BoolToThicknessConverter : ValueConverterBase {

		[CanBeNull] 
		public Thickness True { get; }
		[CanBeNull]
		public Thickness False { get; }

		public BoolToThicknessConverter([CanBeNull] Thickness trueValue, [CanBeNull] Thickness falseValue) {
			True = trueValue;
			False = falseValue;
		}
		public BoolToThicknessConverter([CanBeNull] double trueValue, [CanBeNull] double falseValue) {
			True = new Thickness(trueValue);
			False = new Thickness(falseValue);;
		}

		public override object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
			if (value is bool b) return b ? True : False;
			return False;
		}

	}

}