using System;
using System.Reactive.Linq;
using InTheHand.Net.Sockets;

namespace BluetoothUtils
{
    public class Connection:IDisposable
    {
        private readonly BluetoothDeviceInfo _deviceInfo;
	    private IDisposable _subscribe;

        public Connection(BluetoothDeviceInfo deviceInfo)
        {
            _deviceInfo = deviceInfo;
        }

	    public event EventHandler ConnectionLost; 

	    public bool StartTracking()
	    {
		    if (!_deviceInfo.Connected)
		    {
			    return false;
		    }

		    _subscribe = Observable.Interval(TimeSpan.FromSeconds(10)).Subscribe(p =>
		    {
			    _deviceInfo.Refresh();
				if (!_deviceInfo.Connected)
				{
					if (ConnectionLost != null)
					{
						ConnectionLost(this, EventArgs.Empty);
					}
				}
		    });

			return true;
	    }

	    public void Dispose()
	    {
		    if (_subscribe != null)
		    {
			    _subscribe.Dispose();
		    }
	    }
    }
}
