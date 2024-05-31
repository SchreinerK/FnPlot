using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using FnPlot.Functions;
using KsWare.Presentation.ViewModelFramework;

namespace FnPlot {

	public class GraphVM : ObjectVM {

		public IList<Point> Points { get => Fields.GetValue<IList<Point>>(); set => Fields.SetValue(value); }

		public IList<Point> PreviewPoints { get => Fields.GetValue<IList<Point>>(); set => Fields.SetValue(value); }

		public string SelectedPointText { get => Fields.GetValue<string>(); set => Fields.SetValue(value); }

		public GraphVM() {
			RegisterChildren(()=>this);
		}

		private MainWindowVM MainWindow => (MainWindowVM) Parent;

		public void CursorMoved(double xPercent) {
			var xMin = MainWindow.Parameters["x-min"].Data.Value;
			var xMax = MainWindow.Parameters["x-max"].Data.Value;
			var x = (xMax - xMin) * xPercent + xMin;
			var y = MainWindow.Function.Calculate(FnPlot.Functions.Parameters.Single("x", x));
			SelectedPointText = $"x={RoundValue(x)};\ny={RoundValue(y)}";
		}


		private static double RoundValue(double value) {
			var significantDigits = 2;
			if (value > Math.Pow(10, significantDigits - 1)) return Math.Round(value, 0);
			var scale = Math.Pow(10, Math.Floor(Math.Log10(Math.Abs(value))) + 1 - significantDigits);
			return Math.Round(value / scale) * scale;
		}
	}
}
