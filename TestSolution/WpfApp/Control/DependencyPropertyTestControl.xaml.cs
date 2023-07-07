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

namespace WpfApp.Control
{
    // UserControlのコードビハインド
    public partial class DependencyPropertyTestControl : UserControl
    {
        // 1. 依存プロパティの作成
        public static readonly DependencyProperty TitleProperty =
            DependencyProperty.Register("Title",
                typeof(string),
                typeof(DependencyPropertyTestControl),
                new FrameworkPropertyMetadata("Title", new PropertyChangedCallback(OnTitleChanged)));

        // 2. CLI用プロパティを提供するラッパー
        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        // 3. 依存プロパティが変更されたとき呼ばれるコールバック関数の定義
        private static void OnTitleChanged(DependencyObject obj, DependencyPropertyChangedEventArgs e)
        {
            // オブジェクトを取得して処理する
            DependencyPropertyTestControl ctrl = obj as DependencyPropertyTestControl;
            if (ctrl != null)
            {
                ctrl.TitleTextBlock.Text = ctrl.Title;
            }
        }

        // コンストラクタ
        public DependencyPropertyTestControl()
        {
            InitializeComponent();
            Title = "Set Title Property";
        }
    }
}
