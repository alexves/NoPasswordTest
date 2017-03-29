using System.Windows;
using System.Windows.Input;
using NoPasswordTest.GuiUtils;
using NoPasswordTest.Windows;
using NpDal;
using Utils;

namespace NoPasswordTest.ViewModels
{
	public class LoginViewModel
	{
		public string UserName { get; set; }
		public string Password { get; set; }
		public ICommand LoginCommand { get; set; }

		public LoginViewModel()
		{
			LoginCommand = new ActionCommand(Login, o => !string.IsNullOrWhiteSpace(UserName) && !string.IsNullOrWhiteSpace(Password));
		}

		private void Login(object obj)
		{
			Login();
		}

		public void Login()
		{
			using (var userRepo = new UserRepo())
			{
				var user = new User { Username = UserName };

				Encryption.EncryptPassword(Password, user);

				userRepo.AddOrUpdateUser(user);
			}

			var mainViewModel = new MainViewModel();
			var mainWindow = new MainWindow { ViewModel = mainViewModel };
			Application.Current.MainWindow.Close();
			mainWindow.Show();
		}
	}
}
