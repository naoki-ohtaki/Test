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
    public class MessageListView : ListView
    {
        public List<string> Items
        {
            get { return (List<string>)GetValue(ItemsProperty); }
            set { SetValue(ItemsProperty, value); }
        }

        // Using a DependencyProperty as the backing store for MyProperty.  This enables animation, styling, binding, etc...
        public static readonly DependencyProperty ItemsProperty =
            DependencyProperty.Register(
                "Items",
                typeof(List<string>),
                typeof(MessageListView),
                new FrameworkPropertyMetadata(null, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));
    }
}
