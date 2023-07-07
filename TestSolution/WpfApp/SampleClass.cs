using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace WpfApp
{
    public class SampleClass : DependencyObject
    {
        // 依存関係プロパティのラッパープロパティ
        public string MyName
        {
            get { return (string)GetValue(MyNameProperty); }
            set { SetValue(MyNameProperty, value); }
        }

        public static readonly DependencyProperty MyNameProperty =
            DependencyProperty.Register("MyName",
                typeof(string),
                typeof(SampleClass),
                new PropertyMetadata(null));

        public override string ToString()
        {
            return MyName;
        }
    }

    public class SourceObject
    {
        public string Name { get; set; }
    }
}
