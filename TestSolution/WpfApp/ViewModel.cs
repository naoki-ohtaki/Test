using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Threading;
using static System.Net.Mime.MediaTypeNames;

namespace WpfApp
{
    public class ViewModel : INotifyPropertyChanged
    {
        private string userName = "ユーザー01";
        public ButtonCommand SendMessageButton { get; set; }= new ButtonCommand();

        public ViewModel()
        {
            SendMessage = "初期値";

            スレッドAdd = new ThreadInfo { Thread = "General" };
            スレッドAdd = new ThreadInfo { Thread = "ニュース" };
            スレッドAdd = new ThreadInfo { Thread = "プロジェクト" };

            メッセージAdd = new MessageInfo { Message = "asdfasdfasdf" };
            メッセージAdd = new MessageInfo { Message = "asdfasdfasdf" };
            メッセージAdd = new MessageInfo { Message = "asdfasdfasdf" };
            メッセージAdd = new MessageInfo { Message = "asdfasdfasdf" };

            表示件数Add = 10;
            表示件数Add = 20;
            表示件数Add = 50;
            表示件数Add = 100;

            SendMessageButton.Click = メッセージ送信;
            
        }

        private void メッセージ送信()
        {
            メッセージAdd = new MessageInfo { Message = SendMessage };
        }
        
        // INotifyPropertyChangedインターフェースの実装
        public event PropertyChangedEventHandler PropertyChanged;

        // 変更通知
        public void RaisePropertyChanged([CallerMemberName] string propertyName = null)
            => PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));

        // テキストボックスの入力プロパティ
        private string sendMessage;
        public string SendMessage
        {
            get { return sendMessage; }
            set { if (sendMessage != value) { sendMessage = value; RaisePropertyChanged(); } }
        }

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        private readonly ObservableCollection<ThreadInfo> _スレッドList = new();
        public ObservableCollection<ThreadInfo> スレッドList => _スレッドList;
        private ThreadInfo スレッドAdd
        {
            set
            {
                var data = value;
                data.Id = _スレッドList.Count + 1;
                _スレッドList.Add(data);
                NotifyPropertyChanged();
            }
        }

        private readonly ObservableCollection<MessageInfo> _メッセージList = new();
        public ObservableCollection<MessageInfo> メッセージList => _メッセージList;
        //public ObservableCollection<MessageInfo> メッセージList = new();

        public MessageInfo メッセージAdd
        {
            set
            {
                var data = value;
                data._Time = DateTime.Now;
                data.UserName = userName;
                _メッセージList.Add(data);
                NotifyPropertyChanged();
            }
        }

        private readonly List<int> _表示件数List = new();
        public List<string> 表示件数List => _表示件数List.Select(e=>$"最新{e}件表示").ToList();
        private int 表示件数Add
        {
            set
            {
                var data = value;
                _表示件数List.Add(data);
                NotifyPropertyChanged();
            }
        }
    }

    public class ThreadInfo
    {
        public int Id { get; set; }
        public string Thread { get; set; }
    }

    public class MessageInfo
    {
        public DateTime _Time { get; set; }
        public string Time => (_Time.Date == DateTime.Today)? _Time.ToShortTimeString(): $"{_Time.ToShortDateString()} {_Time.ToShortTimeString()}" ;
        public string Message { get; set; }
        public string UserName { get; set; }
        public string Read => _Read ? "✓" : "";
        public bool _Read { get; set; } = true;
    }
}
