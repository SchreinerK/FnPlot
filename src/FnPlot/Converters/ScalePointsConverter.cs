using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Data;
using System.Windows.Media;
using FnPlot.Framework;
using KsWare.Presentation.Converters;

namespace FnPlot.Converters {

	public class ScalePointsConverter : MultiValueConverterBase {

		public override object Convert(object value, Type targetType, object parameter, CultureInfo culture) {
			if (!(value is IEnumerable<Point> points) || !(parameter is Size size)) return null;
			var minX = points.Min(p => p.X);
			var maxX = points.Max(p => p.X);
			var minY = points.Min(p => p.Y);
			var maxY = points.Max(p => p.Y);

			var scaleX = size.Width / (maxX - minX);
			var scaleY = size.Height / (maxY - minY);

			var scaledPoints = points
				.Select(p => new Point((p.X - minX) * scaleX, size.Height - (p.Y - minY) * scaleY)).ToList();
			return new PointCollection(scaledPoints);

		}

		public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture) {
			throw new NotImplementedException();
		}

		public override object Convert(object[] values, Type targetType, object parameter, CultureInfo culture) {
			if (!(values[0] is IEnumerable<Point> points) || !(values[1] is double width) ||
			    !(values[2] is double height)) return null;
			var minX = points.Min(p => p.X);
			var maxX = points.Max(p => p.X);
			var minY = points.Min(p => p.Y);
			var maxY = points.Max(p => p.Y);

			var scaleX = width / (maxX - minX);
			var scaleY = height / (maxY - minY);

			var scaledPoints = points.Select(p => new Point((p.X - minX) * scaleX, height - (p.Y - minY) * scaleY))
				.ToList();
			return new PointCollection(scaledPoints);

		}

		public override object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) {
			throw new NotImplementedException();
		}

	}

}
