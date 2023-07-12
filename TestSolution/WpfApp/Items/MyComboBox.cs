using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Controls;

namespace WpfApp.Items
{
    public class MyComboBox : ComboBox
    {
        public new ObservableCollection<string> Value
        {
            get => (ObservableCollection<string>)GetValue(ValueProperty);
            set => SetValue(ValueProperty, value);
        }
        
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register(
                nameof(Value),
                typeof(ObservableCollection<string>),
                typeof(MyComboBox),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
    }
}
