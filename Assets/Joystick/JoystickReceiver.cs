using System.IO.Ports;
using System.Threading;
using UnityEngine;
using System;

public class JoystickReceiver : MonoBehaviour
{
	public static JoystickReceiver instance;

	public class Button
	{
		private int _index;
		private KeyCode _keyCode;

		private bool _currentValue = false;
		private bool _previousValue = false;

		public Button(int index, KeyCode keyCode)
		{
			_index = index;
			_keyCode = keyCode;
		}

		internal void Update(byte buttons)
		{
			_previousValue = _currentValue;
			_currentValue = (buttons & (1 << _index)) != 0;
		}

		public bool IsPressed
		{
			get
			{
				return _currentValue || Input.GetKey(_keyCode);
			}
		}

		public bool WasPressed
		{
			get
			{
				return (_currentValue && !_previousValue) || Input.GetKeyDown(_keyCode);
			}
		}

		public bool WasReleased
		{
			get
			{
				return (!_currentValue && _previousValue) || Input.GetKeyUp(_keyCode);
			}
		}
	}

	public Button up { get; private set; }
	public Button right { get; private set; }
	public Button down { get; private set; }
	public Button left { get; private set; }

	static private Thread _thread;
	static private volatile bool _isRunning = false;

	public static void Spawn(GameObject container)
	{
		if (instance == null)
		{
			container.AddComponent<JoystickReceiver>();
		}
	}

	private void OnEnable()
	{
		instance = this;

		up = new Button(0, KeyCode.UpArrow);
		right = new Button(1, KeyCode.RightArrow);
		down = new Button(2, KeyCode.DownArrow);
		left = new Button(3, KeyCode.LeftArrow);

		StartThread();
	}

	private void OnDisable()
	{
		TerminateThread();
	}

	private void StartThread()
	{
		if (!_isRunning)
		{
			_isRunning = true;

			_thread = new Thread(new ThreadStart(ThreadRun));
			_thread.Start();
		}
	}

	private void TerminateThread()
	{
		if (_isRunning)
		{
			_isRunning = false;
			_thread.Join();
		}
	}

	private void ThreadRun()
	{
		const int comSpeed = 115200;


		var comPorts = SerialPort.GetPortNames();
		if (comPorts.Length == 0)
		{
			Debug.LogError("No COM ports are available.");
			_isRunning = false;
			return;
		}

		var comPort = comPorts[0];
		SerialPort serial = new SerialPort(comPort, comSpeed);
		serial.Open();

		if (serial.IsOpen)
		{
			Debug.LogFormat("COM port {0} is open.", comPort);
			serial.ReadTimeout = 1; // RMSHR : added 08-12-2017 prevents Unity Crash on my PC
		}
		else
		{
			Debug.LogErrorFormat("Unable to open COM port {0}.", comPort);
			_isRunning = false;
			return;
		}

		while (_isRunning)
		{
			try
			{
				int readByte = serial.ReadByte();
				byte buttons = Convert.ToByte(readByte);
				if ((buttons & 0x80) != 0)
				{
					up.Update(buttons);
					right.Update(buttons);
					down.Update(buttons);
					left.Update(buttons);
				}
			}
			catch (InvalidOperationException)
			{
				Debug.LogError("COM port was closed.");
				_isRunning = false;
				return;
			}
			catch (Exception)
			{ }
		}

		serial.Close();
		Debug.Log("COM port is closed.");
	}
}
