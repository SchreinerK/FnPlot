using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using ControlzEx.Theming;
using KsWare.Presentation.ViewFramework;

namespace FnPlot {

	/// <summary>
	/// Interaction logic for App.xaml
	/// </summary>
	public partial class App : ViewModelApplication<AppVM> {

		public App() {
			CatchUnhandledExceptions = !Debugger.IsAttached;
		}

		protected override void OnStartup(StartupEventArgs e) {
			ThemeManager.Current.ThemeChanged += AtThemeChanged;
			base.OnStartup(e);
		}

		private void AtThemeChanged(object sender, ThemeChangedEventArgs e) {
			var customThemeDictionary = new ResourceDictionary();
			customThemeDictionary.Source = new Uri(e.NewTheme.BaseColorScheme == "Dark" 
					? "Resources/DarkTheme/@.xaml"
					: "Resources/LightTheme/@.xaml"
					, UriKind.Relative);

			var mergedDictionaries = Application.Current.Resources.MergedDictionaries;
			var existingCustomTheme = mergedDictionaries.FirstOrDefault(d => d.Source != null && d.Source.ToString().Contains("Theme/@.xaml"));
			if (existingCustomTheme != null) mergedDictionaries.Remove(existingCustomTheme);
			mergedDictionaries.Add(customThemeDictionary);
		}

	}

}
