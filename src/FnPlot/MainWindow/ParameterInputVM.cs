using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FnPlot.Functions;
using KsWare.Presentation;
using KsWare.Presentation.Core.Providers;
using KsWare.Presentation.ViewModelFramework;

namespace FnPlot {

	public class ParameterInputVM : DataVM<Parameter> {

		public string Name => Data.Name;

		public string EditValue { get => Fields.GetValue<string>(); set => Fields.SetValue(value); }

		public bool IsValid { get => Fields.GetValue<bool>(); set => Fields.SetValue(value); }

		public ParameterInputVM() {
			RegisterChildren(()=>this);
			Fields[nameof(EditValue)].ValueChangedEvent.add=AtEditValueChanged;
		}

		protected override void OnDataChanged(DataChangedEventArgs e) {
			base.OnDataChanged(e);
			if (e.NewData is Parameter p) {
				EditValue = p.Value.ToString();
			}
		}

		private void AtEditValueChanged(object sender, ValueChangedEventArgs e) {
			if(double.TryParse((string)e.NewValue, out var v)) {
				IsValid = true;
				Data.Value = v;
			}
			else {
				IsValid = false;
			}
		}

	}
}
