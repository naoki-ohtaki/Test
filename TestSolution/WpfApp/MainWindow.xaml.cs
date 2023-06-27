using System.Windows;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow
    {
        public readonly ViewModel ViewModel = new();

        public MainWindow()
        {
            InitializeComponent();
            //ViewModel.SendMessageButton.MainWindow = this;
            DataContext = ViewModel;
        }

        //private void btnSend_Click(object sender, RoutedEventArgs e)
        //{
        //    viewModel.メッセージAdd = new MessageInfo { Message = viewModel.SendMessage };
        //}

        private void ListViewItem_Click(object sender, RoutedEventArgs e)
        {
            MessageBox.Show("test");
        }
        
    }
}