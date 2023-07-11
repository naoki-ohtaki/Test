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
    public class MyListView<T> : ListView
    {
        public new ObservableCollection<T> Value
        {
            get { return (ObservableCollection<T>)GetValue(ValueProperty); }
            set { SetValue(ValueProperty, value); }
        }
        
        public static readonly DependencyProperty ValueProperty =
            DependencyProperty.Register(
                nameof(Value),
                typeof(ObservableCollection<T>),
                typeof(MyListView<T>),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
    }
}
