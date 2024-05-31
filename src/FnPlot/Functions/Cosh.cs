using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FnPlot.Functions {

	internal class Cosh : Function {

		public Cosh() {
			Name = "Cosh";
			SampleXMin = 0;
			SampleXMax = 2 * Math.PI;
		}

		public override double Calculate(Parameters parameters) {
			return Math.Cosh(parameters[0].Value);
		}
	}

}
