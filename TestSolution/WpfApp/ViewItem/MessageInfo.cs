using System;

namespace WpfApp.ViewItem
{
    public class MessageInfo
    {
        public DateTime _Time { get; set; }
        public string Time => (_Time.Date == DateTime.Today) ? _Time.ToShortTimeString() : $"{_Time.ToShortDateString()} {_Time.ToShortTimeString()}";

        public string Message { get; set; }

        public string UserName { get; set; }

        public bool _Read { get; set; } = true;
        public string Read => _Read ? "✓" : "";
    }
}
