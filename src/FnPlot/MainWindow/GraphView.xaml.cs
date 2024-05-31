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

namespace FnPlot {

	/// <summary>
	/// Interaction logic for GraphView.xaml
	/// </summary>
	public partial class GraphView : UserControl {

		public GraphView() {
			InitializeComponent();
		}

		private GraphVM ViewModel => ((GraphVM) DataContext);

		private void MyCanvas_MouseMove(object sender, MouseEventArgs e) {
			var position = e.GetPosition((IInputElement) sender);
			Canvas.SetLeft(Cursor, position.X);
			Canvas.SetTop(Cursor, position.Y);
			ViewModel.CursorMoved(position.X / ((FrameworkElement) sender).ActualWidth);
		}
	}
}
