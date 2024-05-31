using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FnPlot.Functions {

	internal class Cos : Function {

		public Cos() {
			Name = "Cos";
			SampleXMin = 0;
			SampleXMax = 2 * Math.PI;
		}

		public override double Calculate(Parameters parameters) {
			return Math.Cos(parameters[0].Value);
		}
	}

}
