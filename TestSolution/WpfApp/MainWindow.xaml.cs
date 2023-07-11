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

        public void メッセージListView_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }
    }
}