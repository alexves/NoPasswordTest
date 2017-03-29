using System.Windows;
using NoPasswordTest.ViewModels;

namespace NoPasswordTest.Windows
{
	public partial class MainWindow : Window
	{
		public MainViewModel ViewModel
		{
			get { return DataContext as MainViewModel; }
			set
			{
                value.ConnectionLost += ViewModelOnConnectionLost; 
                DataContext = value;
			}
		}

		public MainWindow()
		{
			InitializeComponent();
		}

	    private void ViewModelOnConnectionLost(object sender, System.EventArgs e)
	    {
	        Dispatcher.Invoke(() =>
	            {
	                var loginViewModel = new LoginViewModel();
	                var loginWindow = new LoginWindow {ViewModel = loginViewModel};
	                Close();
	                loginWindow.Show();
	            });
	    }
	}
}
