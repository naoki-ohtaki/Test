using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;
using System.Collections;
using System.Collections.ObjectModel;
using System.Xml.Linq;

namespace WpfApp.Items
{
    public class MyComboBox : ComboBox
    {
        public new ObservableCollection<string> Value
        {
            get { return (ObservableCollection<string>)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }
        
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register(
                nameof(Value),
                typeof(ObservableCollection<string>),
                typeof(MyComboBox),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
    }
}
