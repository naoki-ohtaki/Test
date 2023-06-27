using System;
using System.Windows.Input;

namespace WpfApp
{
    public class ButtonCommand : ICommand
    {
        //public MainWindow MainWindow { get; set; }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter) { return true; }

        public void Execute(object? parameter)
        => Click();
        //{
        //    MainWindow.ViewModel.SendMessage += "A";
        //}

        public Action Click { get; set; }

    }
}