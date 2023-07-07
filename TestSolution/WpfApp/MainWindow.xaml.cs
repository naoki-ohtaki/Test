using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();
            DataContext = new ViewModel();
        }

        private void ListViewItem_Click(object sender, RoutedEventArgs e)
        {
        }
        
    }
}