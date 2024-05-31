using System;
using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;

namespace FnPlot.Functions {

	public class Parameters : List<Parameter> {

		public Parameters([NotNull] IEnumerable<Parameter> collection) : base(collection) { }

		public Parameter this[string name] {
			get {
				return this.First(p => string.Equals(p.Name, name, StringComparison.OrdinalIgnoreCase));
			}
		}

		public static Parameters Single(string name, double value) {
			return new Parameters(new[] {new Parameter(name, value)});
		}
	}

	public class Parameter {

		public Parameter() { }

		public Parameter(string name, double value) {
			Name = name;
			Value = value;
		}

		public string Name { get; set; }

		public double Value { get; set; }
	}

}