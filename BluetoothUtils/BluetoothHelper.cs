using System;
using System.Windows.Forms;
using InTheHand.Net;
using InTheHand.Net.Bluetooth;
using InTheHand.Net.Sockets;

namespace BluetoothUtils
{
    public static class BluetoothHelper
    {
	    public static BluetoothDeviceInfo ConnectDevice()
	    {
		    var bluetoothDeviceDialog = new InTheHand.Windows.Forms.SelectBluetoothDeviceDialog { ShowUnknown = true };
		    var dialogResult = bluetoothDeviceDialog.ShowDialog();
		    if (dialogResult == DialogResult.OK)
		    {
			    BluetoothDeviceInfo deviceInfo = bluetoothDeviceDialog.SelectedDevice;
			    
			    if (deviceInfo.Authenticated || BluetoothSecurity.PairRequest(deviceInfo.DeviceAddress, "123456"))
			    {
			        if (!deviceInfo.Connected)
			        {
			            var endPoint = new BluetoothEndPoint(deviceInfo.DeviceAddress, BluetoothService.SerialPort, 1);
			            var bluetoothClient = new BluetoothClient();
			            try
			            {
                            bluetoothClient.Connect(endPoint);
			            }
			            catch (Exception)
			            {
			                return null;
			            }
			            
			        }
				    return deviceInfo;
			    }

			    return null;
		    }
		    return null;
	    }
    }
}
