using System;
using System.Windows.Input;

namespace WpfApp
{
    public class ExecuteCommand : ICommand
    {
        //public MainWindow MainWindow { get; set; }

        public event EventHandler? CanExecuteChanged;

        public bool CanExecute(object? parameter) { return true; }

        public void Execute(object? parameter) => Action();

        // ReSharper disable once MemberCanBePrivate.Global
        public Action Action { get; set; }

    }
}