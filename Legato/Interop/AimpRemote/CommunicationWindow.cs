using System;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Legato.Interop.AimpRemote.Entities;
using Legato.Interop.AimpRemote.Enum;
using Legato.Interop.Win32.Enum;
using static Legato.Interop.Win32.API;

namespace Legato.Interop.AimpRemote
{
	/// <summary>
	/// AIMP と通信するためのメッセージ専用ウィンドウ
	/// </summary>
	public class CommunicationWindow : Form
	{
		// MessageReceived events
		public event Action<WindowMessage, IntPtr, IntPtr> MessageReceived;
		public event Action<CopyDataStruct> CopyDataMessageReceived;
		public event Action<NotifyType, IntPtr> NotifyMessageReceived;

		// Changed events
		public event Action<PlayerProperty> PropertyChanged;
		public event Action<TrackInfo> CurrentTrackChanged;

		// PropertyChanged events
		public event Action<TimeSpan> DurationPropertyChanged;
		public event Action<bool> IsMutePropertyChanged;
		public event Action<bool> IsRepeatPropertyChanged;
		public event Action<bool> IsShufflePropertyChanged;
		public event Action<int> PositionPropertyChanged;
		public event Action<PlayerState> StatePropertyChanged;
		public event Action<int> VolumePropertyChanged;

		public TimeSpan CurrentTrackChangedDelayTime { get; set; } = TimeSpan.FromMilliseconds(20);

		public void OnPositionPropertyChanged(int position)
		{
			PositionPropertyChanged?.Invoke(position);
		}

		public CommunicationWindow()
		{
			// メッセージ専用ウインドウに変更
			Win32.Helper.ChangeMessageOnlyWindow(this);

			MessageReceived += (message, wParam, lParam) =>
			{
				// CopyDataMessageReceived を発行
				if (message == WindowMessage.COPYDATA)
				{
					var cds = Marshal.PtrToStructure<CopyDataStruct>(lParam);
					CopyDataMessageReceived?.Invoke(cds);
				}

				// NotifyMessageReceived を発行
				else if (message == (WindowMessage)AimpWindowMessage.Notify)
					NotifyMessageReceived?.Invoke((NotifyType)wParam, lParam);
			};

			NotifyMessageReceived += /*async*/ (type, lParam) =>
			{
				// PropertyChanged を発行
				if (type == NotifyType.Property)
					PropertyChanged?.Invoke((PlayerProperty)lParam);

				// CurrentTrackChanged を発行
				else if (type == NotifyType.TrackStart)
				{
					// await Task.Delay(CurrentTrackChangedDelayTime);
					CurrentTrackChanged?.Invoke(Helper.CurrentTrack);
				}

				else if (type == NotifyType.TrackInfo) { }

				else
					throw new ApplicationException($"NotifyType '{type}' is undefined value");
			};

			PropertyChanged += (type) =>
			{
				var propertyValue = Helper.SendPropertyMessage(type, PropertyAccessMode.Get).ToInt32();

				// DurationPropertyChanged を発行
				if (type == PlayerProperty.Duration)
					DurationPropertyChanged?.Invoke(TimeSpan.FromMilliseconds(propertyValue));

				// IsMutePropertyChanged を発行
				else if (type == PlayerProperty.IsMute)
					IsMutePropertyChanged?.Invoke(propertyValue != 0);

				// IsRepeatPropertyChanged を発行
				else if (type == PlayerProperty.IsRepeat)
					IsRepeatPropertyChanged?.Invoke(propertyValue != 0);

				// IsShufflePropertyChanged を発行
				else if (type == PlayerProperty.IsShuffle)
					IsShufflePropertyChanged?.Invoke(propertyValue != 0);

				// PositionPropertyChanged を発行
				else if (type == PlayerProperty.Position)
					OnPositionPropertyChanged(propertyValue);

				// StatePropertyChanged を発行
				else if (type == PlayerProperty.State)
					StatePropertyChanged?.Invoke((PlayerState)propertyValue);

				// VolumePropertyChanged を発行
				else if (type == PlayerProperty.Volume)
					VolumePropertyChanged?.Invoke(propertyValue);

				else
					throw new ApplicationException($"PropertyType '{type}' is undefined value");
			};
		}

		protected override void WndProc(ref Message message)
		{
			// MessageReceived を発行
			MessageReceived?.Invoke((WindowMessage)message.Msg, message.WParam, message.LParam);

			base.WndProc(ref message);
		}
	}
}
