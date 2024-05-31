using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using KsWare.Presentation.Converters;

namespace FnPlot.Converters {

	public class SubtextConverter : ValueConverterBase {

		public override object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
			if (!(value is string s)) return value;
			var parts = s.Split('-');
			if (parts.Length < 2) return value;
        
			var textBlock = new TextBlock();
			var mainRun = new Run(parts[0]);
			textBlock.Inlines.Add(mainRun);

			var subscriptRun = new Run(" "+parts[1]) {
				BaselineAlignment = BaselineAlignment.Subscript
			};

			BindingOperations.SetBinding(subscriptRun, Run.FontSizeProperty,
				new Binding("FontSize") {
					Source = textBlock,
					Converter = SubscriptFontSizeConverter.Default,
					ConverterParameter = 0.8
				});

			textBlock.Inlines.Add(subscriptRun);
			return textBlock;
		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
			throw new NotImplementedException();
		}

	}

}
