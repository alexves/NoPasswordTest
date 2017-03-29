using System.Windows;
using NoPasswordTest.ViewModels;

namespace NoPasswordTest.Windows
{
	public partial class LoginWindow : Window
	{
		public LoginViewModel ViewModel
		{
			get { return DataContext as LoginViewModel; }
			set { DataContext = value; }
		}

		public LoginWindow()
		{
			InitializeComponent();
			ViewModel = new LoginViewModel();
		}
	}
}
