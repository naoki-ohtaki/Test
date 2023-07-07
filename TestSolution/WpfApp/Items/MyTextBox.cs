using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows;

namespace WpfApp.Items
{
    public class MyTextBox : TextBox
    {
        public string Value
        {
            get { return (string)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }
        
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register(
                "Items",
                typeof(string),
                typeof(MyTextBox),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
    }
}
