using System.Collections.ObjectModel;

namespace WpfApp.ViewItem
{
    public class ThreadInfo
    {
        public int Id { get; set; }
        public string Thread { get; set; } = string.Empty;

        public ObservableCollection<MessageInfo> MessageList { get; set; } = new();
    }
}
