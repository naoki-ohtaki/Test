using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Input;
using System.Windows.Threading;
using WpfApp.Items;
using WpfApp.ViewItem;
using static System.Net.Mime.MediaTypeNames;

namespace WpfApp
{
    public class ViewModel
    {
        private string userName = "ユーザー01";
        public ButtonCommand スレッドButton { get; set; } = new();
        public ButtonCommand メッセージ送信Button { get; set; } = new ButtonCommand();

        public ViewModel()
        {
            //初期値設定 //TODO テスト用のためSendMessage実装後に見直し必要
            初期値設定();

            メッセージ送信Button.Click = メッセージ送信;

            スレッドButton.Click = スレッド切り替え;
        }
        
        public MyTextBox メッセージ { get; } = new();

        public MyComboBox 表示件数ComboBox { get; } = new();

        public MyListView<MessageInfo> メッセージListView { get; } = new();

        public MyListView<ThreadInfo> スレッドListView { get; } = new();

        private void 初期値設定()
        {
            スレッドListView.Value = new ObservableCollection<ThreadInfo>();
            スレッドListView.Value.Add(new ThreadInfo { Thread = "General", Id = スレッドListView.Value.Count + 1 });
            スレッドListView.Value.Add(new ThreadInfo { Thread = "ニュース", Id = スレッドListView.Value.Count + 1 });
            スレッドListView.Value.Add(new ThreadInfo { Thread = "プロジェクト", Id = スレッドListView.Value.Count + 1 });

            メッセージListView.Value = new ObservableCollection<MessageInfo>();
            メッセージListView.Value.Add(new MessageInfo { Message = "テストメッセージ1", _Time = DateTime.Now });
            メッセージListView.Value.Add(new MessageInfo { Message = "テストメッセージ2", _Time = DateTime.Now });
            メッセージListView.Value.Add(new MessageInfo { Message = "テストメッセージ3", _Time = DateTime.Now });
            メッセージListView.Value.Add(new MessageInfo { Message = "テストメッセージ4", _Time = DateTime.Now });

            表示件数ComboBox.Value = new ObservableCollection<string>();
            表示件数ComboBox.Value.Add("a");
            表示件数ComboBox.Value.Add("b");

            メッセージ.Value = "初期値";
        }

        private void メッセージ送信()
        {
            //TODO 本当はここでSendMessageする。今は画面系のテストコードになっている。
            メッセージ.Value += "A";
            メッセージListView.Value.Add(new MessageInfo { Message = メッセージ.Value, _Time = DateTime.Now });
            表示件数ComboBox.Value.Add(メッセージ.Value);
        }

        private void スレッド切り替え()
        {
            //TODO 本当はListViewの選択変更時のイベントでやりたい
            //TODO メッセージListViewに、選択されたスレッドの内容を表示
            //var test = メッセージListView.SelectedIndex;
        }
        
    }
}
