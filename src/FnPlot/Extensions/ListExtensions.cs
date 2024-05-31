using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FnPlot.Extensions {

	public static class ObservableCollectionExtensions {

		public static void AddRange<T>(this ObservableCollection<T> @col, IEnumerable<T> values) {
			foreach (var value in values) @col.Add(value);
		}
	}
}
