using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FnPlot.Functions {

	internal class Sin : Function {

		public Sin() {
			Name = "Sin";
			SampleXMin = 0;
			SampleXMax = 2 * Math.PI;
		}

		public override double Calculate(Parameters parameters) {
			return Math.Sin(parameters[0].Value);
		}
	}

}
