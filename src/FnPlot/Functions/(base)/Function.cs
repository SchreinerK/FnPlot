using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace FnPlot.Functions {

	public abstract class Function {

		public string Name { get; set; }

		public double SampleXMin { get; protected set; } = 0;
		public double SampleXMax { get; protected set; } = 1;

		public abstract double Calculate(Parameters parameters);

		public IList<Point> CalculateSeries(Parameters parameters) {
			var steps = 500; // TODO make dynamic or as parameter
			var xMin = parameters["x-min"].Value;
			var xMax = parameters["x-max"].Value;
			var results = new List<Point>();
			for (var i = 0; i <= steps; i++) {
				var x = (((xMax - xMin) / (steps)) * i) + xMin;
				var y = Calculate(Parameters.Single("x", x)); //TODO could be optimized (dismiss creating new Parameters list every time)
				results.Add(new Point(x, y));
			}
			return results;
		}

	}

}
