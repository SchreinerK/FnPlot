using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using ControlzEx.Theming;
using FnPlot.Extensions;
using FnPlot.Functions;
using JetBrains.Annotations;
using KsWare.Presentation;
using KsWare.Presentation.ViewModelFramework;

namespace FnPlot {

	public class MainWindowVM : WindowVM {

		public string SelectedFunctionName { get => Fields.GetValue<string>(); set => Fields.SetValue(value); }

		public ObservableCollection<string> FunctionNames { get; set; } = new ObservableCollection<string>();

		/// <summary>
		/// Gets the <see cref="ActionVM"/> to Calculate
		/// </summary>
		/// <seealso cref="DoCalculate"/>
		public ActionVM CalculateAction { get; [UsedImplicitly] private set; } = null;
		/// <summary>
		/// Gets the <see cref="ActionVM"/> to Undo
		/// </summary>
		/// <seealso cref="DoUndo"/>
		public ActionVM UndoAction { get; [UsedImplicitly] private set; } = null;
		/// <summary>
		/// Gets the <see cref="ActionVM"/> to Exit
		/// </summary>
		/// <seealso cref="DoExit"/>
		public ActionVM ExitAction { get; [UsedImplicitly] private set; } = null;

		/// <summary>
		/// Gets the <see cref="ActionVM"/> to Export
		/// </summary>
		/// <seealso cref="DoExport"/>
		public ActionVM ExportAction { get; [UsedImplicitly] private set; } = null;

		
		/// <summary>
		/// Gets the <see cref="ActionVM"/> to ToggleTheme
		/// </summary>
		/// <seealso cref="DoToggleTheme"/>
		public ActionVM ToggleThemeAction { get; [UsedImplicitly] private set; } = null;
		
		public InputParameters Parameters { get; } = new InputParameters();

		public GraphVM Graph { get; [UsedImplicitly] private set; }

		public Function Function { get => Fields.GetValue<Function>(); set => Fields.SetValue(value); }

		public MainWindowVM() {
			RegisterChildren(()=>this);
			Fields[nameof(SelectedFunctionName)].ValueChangedEvent.add=AtFunctionSelected;
			var tFunctions= Assembly.GetExecutingAssembly().GetTypes().Where(t => t.IsSubclassOf(typeof(Function))).Select(t=>t.Name);
			FunctionNames.AddRange(tFunctions);

			LoadFields();

			UIAccess.WindowChanged += (s, e) => {
				if (e.NewValue != null) {
					e.NewValue.Closing += (s2, e2) => SaveFields();
				}
			};
		}

		private void AtFunctionSelected(object sender, ValueChangedEventArgs e) {
			Parameters.Clear();
			var tFunction = Assembly.GetExecutingAssembly().GetTypes()
				.FirstOrDefault(t => t.Name == SelectedFunctionName && t.IsSubclassOf(typeof(Function)));
			if (tFunction == null) return;

			Function = (Function) Activator.CreateInstance(tFunction);
			Parameters.Add(new ParameterInputVM {Data = new Parameter {Name = "X-min", Value = 0}});
			Parameters.Add(new ParameterInputVM {Data = new Parameter {Name = "X-max", Value = 2 * Math.PI}});

			Parameters["x-min"].EditValue = Function.SampleXMin.ToString();
			Parameters["x-max"].EditValue = Function.SampleXMax.ToString();

			foreach (var p in Parameters) {
				p.Fields[nameof(ParameterInputVM.EditValue)].ValueChangedEvent.add = AtParameterChanged;
			}

			DoCalculate();
		}

		private void AtParameterChanged(object sender, ValueChangedEventArgs e) {
			CalculatePreview();
		}

		private void CalculatePreview() {
			if (Function == null) return;
			if (Parameters.Any(p => p.IsValid == false)) return;
			Graph.PreviewPoints = Function.CalculateSeries(new Parameters(Parameters.Select(p => p.Data)));
		}

		/// <summary>
		/// Method for <see cref="CalculateAction"/>
		/// </summary>
		[UsedImplicitly]
		private void DoCalculate() {
			if (Function == null) return;
			if (Parameters.Any(p => p.IsValid == false)) return;
			Graph.Points = Function.CalculateSeries(new Parameters(Parameters.Select(p => p.Data)));
			Graph.PreviewPoints = null;
			SaveFields();
		}

		/// <summary>
		/// Method for <see cref="UndoAction"/>
		/// </summary>
		[UsedImplicitly]
		private void DoUndo() {
			LoadFields();
		}

		/// <summary>
		/// Method for <see cref="ExitAction"/>
		/// </summary>
		[UsedImplicitly]
		private void DoExit() {
			UIAccess.Window.Close();
		}

		/// <summary>
		/// Method for <see cref="ToggleThemeAction"/>
		/// </summary>
		[UsedImplicitly]
		private void DoToggleTheme() {
			var currentTheme = ThemeManager.Current.DetectTheme(Application.Current);
			var newTheme = currentTheme?.BaseColorScheme == "Light" ? "Dark.Blue" : "Light.Blue";
			ThemeManager.Current.ChangeTheme(Application.Current, newTheme);
		}

		/// <summary>
		/// Method for <see cref="ExportAction"/>
		/// </summary>
		[UsedImplicitly]
		private void DoExport() {
			MessageBox.Show("Sorry, not yet implemented.");
			//TODO Export plot.
		}

		private void SaveFields() {
			var mem = new PersistentStorage();
			mem.Function = SelectedFunctionName;
			foreach (var p in Parameters) {
				mem.Parameters.Add(p.EditValue);
			}
			mem.Theme = ThemeManager.Current.DetectTheme(Application.Current).Name;
			PersistentStorage.Save(mem);
		}

		private void LoadFields() {
			var mem = PersistentStorage.Load();

			ThemeManager.Current.ChangeTheme(Application.Current, mem.Theme);

			SelectedFunctionName = mem.Function;
			for (var i = 0; i < Parameters.Count; i++) {
				Parameters[i].EditValue = mem.Parameters[i];
			}
			DoCalculate();
		}
	}

}
