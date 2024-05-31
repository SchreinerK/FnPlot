using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FnPlot.Functions {

	internal class Tan : Function {

		public Tan() {
			Name = "Tan";
			SampleXMin = -2;
			SampleXMax = 2;
		}

		public override double Calculate(Parameters parameters) {
			return Math.Tan(parameters[0].Value);
		}
	}

}
