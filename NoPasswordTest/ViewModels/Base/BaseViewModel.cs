using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;

namespace NoPasswordTest.ViewModels.Base
{
	public class BaseViewModel : INotifyPropertyChanged
	{
		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			var handler = PropertyChanged;
			if (handler != null)
			{
				handler(this, new PropertyChangedEventArgs(propertyName));
			}
		}

		protected void InvokeOnDispatcher(Action action)
		{
			Application.Current.Dispatcher.Invoke(action);
		}
	}
}
