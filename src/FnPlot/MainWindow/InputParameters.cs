using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FnPlot {

	public class InputParameters : ObservableCollection<ParameterInputVM> {

		public ParameterInputVM this[string name] {
			get {
				return this.First(p => string.Equals(p.Name, name, StringComparison.OrdinalIgnoreCase));
			}
		}
	}
}
