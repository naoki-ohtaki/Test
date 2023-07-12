using System;
using System.Collections.ObjectModel;
using WpfApp.Items;
using WpfApp.ViewItem;

namespace WpfApp
{
    public class ViewModel
    {
        private string userName = "ユーザー01";
        public ExecuteCommand スレッドExecute { get; set; } = new();
        public ExecuteCommand メッセージ送信Execute { get; set; } = new ExecuteCommand();

        public ViewModel()
        {
            //初期値設定 //TODO テスト用のためSendMessage実装後に見直し必要
            初期値設定();

            メッセージ送信Execute.Action = メッセージ送信;

            スレッドExecute.Action = スレッド切り替え;
        }

        public MyTextBox メッセージ { get; } = new();

        public MyComboBox 表示件数ComboBox { get; } = new();

        public MyListView<MessageInfo> メッセージListView { get; } = new();

        public MyListView<ThreadInfo> スレッドListView { get; } = new();
        public ThreadInfo? Selectedスレッド { get; set; }

        private void 初期値設定()
        {
            メッセージ.Value = "初期値";

            表示件数ComboBox.Value = new ObservableCollection<string>
            {
                "a",
                "b"
            };

            スレッドListView.Value = new ObservableCollection<ThreadInfo>();
            スレッドListView.Value.Add(new ThreadInfo
            {
                Thread = "General",
                Id = スレッドListView.Value.Count + 1,
                MessageList = new ObservableCollection<MessageInfo>
                    {
                        CreateMessageInfo("Generalメッセージ1"),
                        CreateMessageInfo("Generalメッセージ2"),
                        CreateMessageInfo("Generalメッセージ3"),
                    }
            });
            スレッドListView.Value.Add(new ThreadInfo
            {
                Thread = "ニュース",
                Id = スレッドListView.Value.Count + 1,
                MessageList = new ObservableCollection<MessageInfo>
                {
                    CreateMessageInfo("ニュースメッセージ1"),
                    CreateMessageInfo("ニュースメッセージ2"),
                    CreateMessageInfo("ニュースメッセージ3"),
                }
            });
            スレッドListView.Value.Add(new ThreadInfo
            {
                Thread = "プロジェクト",
                Id = スレッドListView.Value.Count + 1,
                MessageList = new ObservableCollection<MessageInfo>
                {
                    CreateMessageInfo("プロジェクトメッセージ1"),
                    CreateMessageInfo("プロジェクトメッセージ2"),
                    CreateMessageInfo("プロジェクトメッセージ3"),
                }
            });

            if (スレッドListView.Value.Count < 0) return;
            Selectedスレッド = スレッドListView.Value[0];

            メッセージListView.Value = Selectedスレッド.MessageList;
        }

        private void メッセージ送信()
        {
            //TODO 本当はここでSendMessageする。今は画面系のテストコードになっている。
            メッセージ.Value += "A";
            メッセージListView.Value.Add(new MessageInfo { Message = メッセージ.Value, _Time = DateTime.Now });
            表示件数ComboBox.Value.Add(メッセージ.Value);
        }

        private void スレッド切り替え()
            => メッセージListView.Value = Selectedスレッド.MessageList;

        private MessageInfo CreateMessageInfo(string message)
            => new()
            {
                Message = message,
                _Time = DateTime.Now,
                UserName = userName,
            };
    }
}
