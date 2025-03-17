using System;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BankApp.Client.Commands
{
    public class RelayCommand : ICommand
    {
        private readonly Action _execute;
        private readonly Func<bool>? _canExecute;
        public RelayCommand(Action execute, Func<bool>? canExecute = null)
        {
            // TODO: implement relay command logic
            ;
        }

        public event EventHandler? CanExecuteChanged;
        public bool CanExecute(object? parameter)
        {
            // TODO: implement can execute logic
            return default !;
        }

        public void Execute(object? parameter)
        {
            // TODO: implement execute logic
            ;
        }

        public void RaiseCanExecuteChanged()
        {
            // TODO: implement raise can execute logic
            ;
        }
    }

    public class AsyncRelayCommand : ICommand
    {
        private readonly Func<Task> _execute;
        private readonly Func<bool>? _canExecute;
        private bool _isRunning;
        public AsyncRelayCommand(Func<Task> execute, Func<bool>? canExecute = null)
        {
            // TODO: implement async relay command logic
            ;
        }

        public event EventHandler? CanExecuteChanged;
        public bool CanExecute(object? parameter)
        {
            // TODO: implement can execute logic
            return default !;
        }

        public async void Execute(object? parameter)
        {
            // TODO: implement execute logic
            ;
        }

        public void RaiseCanExecuteChanged()
        {
            // TODO: implement raise can execute logic
            ;
        }
    }
}