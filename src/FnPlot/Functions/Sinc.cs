using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FnPlot.Functions {

	internal class Sinc : Function {

		public Sinc() {
			Name = "Sinc";
			SampleXMin = -10;
			SampleXMax = 10;
		}

		public override double Calculate(Parameters parameters) {
			return NormSinc(parameters[0].Value);
		}

		// Normierte Sinc-Funktion
		public static double NormSinc(double x) {
			if (x == 0) return 1;
			return Math.Sin(Math.PI * x) / (Math.PI * x);
		}

		// Nicht-normierte Sinc-Funktion
		public static double UnnormalizedSinc(double x) {
			if (x == 0) return 1;
			return Math.Sin(x) / x;
		}

	}

}
