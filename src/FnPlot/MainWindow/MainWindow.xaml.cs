using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MahApps.Metro.Controls;

namespace FnPlot {
	/// <summary>
	/// Interaction logic for MainWindow.xaml
	/// </summary>
	public partial class MainWindow : MetroWindow {

		public MainWindow() {
			InitializeComponent();
			SizeChanged += AtSizeChanged; // Ereignisbehandlung für Größenänderung hinzufügen
			InitializeLayout(); // Initialisierung des Standard-Layouts
		}

		private void InitializeLayout() {

			if (ActualWidth > 530) {
				InputPanel.ContentTemplate = (DataTemplate)FindResource("TwoColumnInput");
			}
			else {
				InputPanel.ContentTemplate = (DataTemplate)FindResource("OneColumnInput");
			}
		}

		private void AtSizeChanged(object sender, SizeChangedEventArgs e) {
			InitializeLayout();
		}
    }
}
