using System;
using System.IO;
using System.IO.Ports;


namespace FFXIVHP
{
	public class Serial
	{
		private string portName;
		private int portSpeed;
		public bool _initiated;
		private SerialPort serial;

		public Serial(string portName, int portSpeed)
		{
			this.portName = portName;
			this.portSpeed = portSpeed;
			this._initiated = InitSerial(this.portName, this.portSpeed);
		}

		private bool InitSerial(string portName, int portSpeed)
		{
			_initiated = false;

			try
			{
				serial = new SerialPort(portName, portSpeed);
				serial.Parity = Parity.None;
				serial.DataBits = 8;
				serial.DtrEnable = true;
				serial.StopBits = StopBits.One;
				serial.Open();
				serial.NewLine = "\n";
				return _initiated = true;
			} catch (IOException ex)
			{
				Console.WriteLine("IO Exception: " + ex);
				return _initiated;
			}
		}

		public void SendMessage(int message)
		{
			try
			{
				var msgString = message.ToString();
				var msgTrimmed = msgString.Trim();
				serial.WriteLine(msgTrimmed);
				Console.WriteLine("Sent Serial Message: " + msgTrimmed);
			} catch (IOException ex)
			{
				Console.WriteLine("IO Exception: " + ex);
			}
		}

		public void CloseSerial(SerialPort serial)
		{
			serial.Close();
		}
	}
}