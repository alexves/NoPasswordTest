using System;
using System.Windows.Input;

namespace NoPasswordTest.GuiUtils
{
	public class ActionCommand : ICommand
	{
		private readonly Action<object> _executeHandler;
		private readonly Func<object, bool> _canExecuteHandler;

		public ActionCommand(Action<object> executeMethod)
			: this(executeMethod, null)
		{

		}

		public ActionCommand(Action<object> executeMethod, Func<object, bool> canExecuteFunction)
		{
			_executeHandler = executeMethod;
			_canExecuteHandler = canExecuteFunction;

			if (_executeHandler == null)
			{
				throw new ArgumentException("ExecuteMethod can not be null!!!");
			}
		}

		public bool CanExecute(object parameter)
		{
			if (_canExecuteHandler == null)
			{
				return true;
			}

			return _canExecuteHandler(parameter);
		}

		public event EventHandler CanExecuteChanged
		{
			add { CommandManager.RequerySuggested += value; }
			remove { CommandManager.RequerySuggested -= value; }
		}

		public void Execute(object parameter)
		{
			_executeHandler(parameter);
		}
	}
}
