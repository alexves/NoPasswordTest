using System;
using System.Windows.Input;
using BluetoothUtils;
using NoPasswordTest.GuiUtils;
using NoPasswordTest.ViewModels.Base;
using NoPasswordTest.Windows;


namespace NoPasswordTest.ViewModels
{
	public class MainViewModel : BaseViewModel
	{
		private Connection _connection;
		private string _pairedDeviceName;

		public MainViewModel()
		{
			PairCommand = new ActionCommand(PairDevice);
		}

		public ICommand PairCommand { get; set; }
        
        public event EventHandler ConnectionLost; 

		public string PairedDeviceName
		{
			get { return _pairedDeviceName; }
			set
			{
				_pairedDeviceName = value;
				OnPropertyChanged();
			}
		}

		private void PairDevice(object obj)
		{
			if (_connection != null)
			{
				_connection.Dispose();
			}

			var bluetoothDeviceInfo = BluetoothHelper.ConnectDevice();
			if (bluetoothDeviceInfo == null || !bluetoothDeviceInfo.Connected)
			{
				return;
			}
			_connection = new Connection(bluetoothDeviceInfo);
			_connection.ConnectionLost += OnConnectionLost;
			_connection.StartTracking();

			PairedDeviceName = bluetoothDeviceInfo.DeviceName;
		}

		private void OnConnectionLost(object sender, EventArgs e)
		{
            _connection.Dispose();
            _connection = null;

			//InvokeOnDispatcher(() => PairedDeviceName = null);

		    if (ConnectionLost != null)
            {
                ConnectionLost(this, EventArgs.Empty);
            }



		}
	}
}
