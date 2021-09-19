namespace WindowPosition {
	using System;
	using System.Windows.Forms;
	using System.IO;
	using System.Threading.Tasks;
	using System.Runtime.InteropServices;
	using System.Diagnostics;
	using System.Text;
	using System.Drawing;
	using System.ComponentModel;

	public partial class WindowPositions : Form {
		[DllImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern Boolean GetWindowRect(IntPtr hWnd, out RECT lpRect);

		[DllImport("user32.dll")]
		private static extern bool GetWindowPlacement(IntPtr hWnd, out WINDOWPLACEMENT nCmdShow);

		[StructLayout(LayoutKind.Sequential)]
		private struct RECT {
			public Int32 Left;        // x position of upper-left corner
			public Int32 Top;         // y position of upper-left corner
			public Int32 Right;       // x position of lower-right corner
			public Int32 Bottom;      // y position of lower-right corner
		}
		//Definition for Window Placement Structure
		[StructLayout(LayoutKind.Sequential)]
		private struct WINDOWPLACEMENT {
			public Int32 length;
			public Int32 flags;
			public Int32 showCmd;
			public System.Drawing.Point ptMinPosition;
			public System.Drawing.Point ptMaxPosition;
			public System.Drawing.Rectangle rcNormalPosition;
		}

		public WindowPositions() {
			InitializeComponent();
			ResX.Text=System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width.ToString();
			ResY.Text=System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height.ToString();
#pragma warning disable PH_S007 // Thread Start in Constructor Mouse updates
			_=Task.Run(() => UpdateMousePos());
#pragma warning restore PH_S007 // Thread Start in Constructor
		}
		private void UpdateMousePos() {
			while(true) {
				MouseX.Text=System.Windows.Forms.Cursor.Position.X.ToString();
				MouseY.Text=System.Windows.Forms.Cursor.Position.Y.ToString();
				MouseX.Update();
				MouseY.Update();
				System.Threading.Thread.Sleep(1000);
			}
		}

		private void LoadFileButton_Click(object sender, EventArgs e) {
			ToggleButtons();
			String _File = openFileDialog1.ShowDialog().Equals(DialogResult.OK) ? openFileDialog1.FileName : "ERROR";
			if(!_File.Equals("ERROR")&&File.Exists(_File)) {
				richTextBox1.Clear();
				richTextBox1.Text=File.ReadAllText(_File);
				richTextBox1.Update();
				StatusLabel.Text="Loaded from "+_File;
				StatusLabel.Update();
			}
			ToggleButtons();
		}

		private void SaveButton_Click(object sender, EventArgs e) {
			ToggleButtons();
			String _File = saveFileDialog1.ShowDialog().Equals(DialogResult.OK)?saveFileDialog1.FileName:"ERROR";
			if(!_File.Equals("ERROR")&&File.Exists(_File)) {
				File.Delete(_File);
			}
			File.WriteAllText(_File,richTextBox1.Text);
			StatusLabel.Text="Saved to "+_File;
			StatusLabel.Update();
			ToggleButtons();
		}
		private void ToggleButtons() {
			loadWindowsButton.Enabled=!loadWindowsButton.Enabled;
			SaveFileButton.Enabled=!SaveFileButton.Enabled;
			LoadFileButton.Enabled=!LoadFileButton.Enabled;
			ApplyButton.Enabled=!ApplyButton.Enabled;
			ClearTextboxButton.Enabled=!ClearTextboxButton.Enabled;
			loadWindowsButton.Update();
			SaveFileButton.Update();
			LoadFileButton.Update();
			ApplyButton.Update();
			ClearTextboxButton.Update();
		}

		private void ApplyButton_Click(object sender, EventArgs e) {
			if(richTextBox1.Text.Length<=21) {
				_=MessageBox.Show("Configuration empty!");
				return;
			}
			String[] _Config = richTextBox1.Lines;
			Process[] AllProcesses = Process.GetProcesses();
			Int32 _StringBuffer = 2048;
			Boolean[] _Found = new Boolean[_Config.Length];
			for(Int32 i = 0;!i.Equals(_Found.Length);i++) {
				_Found[i]=false;
			}
			ToggleButtons();
			StatusLabel.Text="Applying...";
			StatusLabel.Update();
			if(!(AllProcesses is null)&&
				!AllProcesses.Length.Equals(0)&&
				!(AllProcesses[0] is null)) {
				Process[] processList = Process.GetProcesses();
				//Mark Settings for re-init
				for(Int32 i = 0;!i.Equals(processList.Length);i++) {
					StatusLabel.Text="Checking Process " + i.ToString() + @"/" + processList.Length.ToString();
					StatusLabel.Update();
					if(!processList[i].ProcessName.Equals(String.Empty)&&
						!processList[i].MainWindowTitle.Equals(String.Empty)) {
						StringBuilder _String = new(_StringBuffer);
						if(WindowTools.GetWindowTextA(processList[i].MainWindowHandle, _String, _StringBuffer)>0) {
							if(!GetWindowRect(processList[i].MainWindowHandle, out RECT rct)) {
								_=MessageBox.Show("ERROR");
								return;
							}
							Rectangle myRect = new() { X=rct.Left, Y=rct.Top, Width=rct.Right-rct.Left, Height=rct.Bottom-rct.Top };
							WINDOWPLACEMENT param = new();
							param.length=Marshal.SizeOf(typeof(WINDOWPLACEMENT));
							//Get Window Status
							_=GetWindowPlacement(processList[i].MainWindowHandle, out param);
							if(!param.showCmd.Equals((Int32)WindowTools.WindowShowStyle.Show)&&!param.showCmd.Equals((Int32)WindowTools.WindowShowStyle.ShowMaximized)) {
								param.showCmd=(Int32)WindowTools.WindowShowStyle.ShowNormalNoActivate; //Restore from minimized
								_=WindowTools.ShowWindow(processList[i].MainWindowHandle, WindowTools.WindowShowStyle.ShowNormalNoActivate);
								if(!GetWindowRect(processList[i].MainWindowHandle, out rct)) {
									_=MessageBox.Show("ERROR");
									return;
								}
								myRect=new() { X=rct.Left, Y=rct.Top, Width=rct.Right-rct.Left, Height=rct.Bottom-rct.Top };
							}
							param.rcNormalPosition=myRect;
							for(Int32 ii = 0;!ii.Equals(_Config.Length);ii++) {
								if(!_Found[ii]&&!_Config[ii].Equals(String.Empty)&&_Config[ii].Length>=21) {
									WindowTools.WindowPositionSetting _Setting = WindowTools.WindowPositionStruct(_Config[ii]);
									if(//Cancel Window Title Checks (for Found)
										(_String.ToString().Equals(_Setting.WindowTitle)||
											(!processList[i].MainWindowHandle.Equals(Process.GetCurrentProcess().MainWindowHandle) ?
												CMDLINE.GetCommandLine(processList[i]).Replace(processList[i].MainModule.FileName, String.Empty).Replace(@"""", String.Empty).Trim().Equals(_Setting.Args) :
												CMDLINE.GetCommandLine(Process.GetCurrentProcess()).Replace(Process.GetCurrentProcess().MainModule.FileName, String.Empty).Replace(@"""", String.Empty).Trim().Equals(_Setting.Args)))
												&&
											(!processList[i].MainWindowHandle.Equals(Process.GetCurrentProcess().MainWindowHandle)?
												processList[i].MainModule.FileName.Equals(_Setting.Path):
												Process.GetCurrentProcess().MainModule.FileName.Equals(_Setting.Path))
										) {
										if(!myRect.X.Equals(_Setting.X)||!myRect.Y.Equals(_Setting.Y)||
											!myRect.Width.Equals(_Setting.Width)||!myRect.Height.Equals(_Setting.Height)) {
											param.length=Marshal.SizeOf(typeof(WINDOWPLACEMENT));
											//Get Window Status
											_=GetWindowPlacement(processList[i].MainWindowHandle, out param);
											param.rcNormalPosition=new() { X=_Setting.X, Y=_Setting.Y, Width=_Setting.Width, Height=_Setting.Height };
											_=WindowTools.MoveWindow(processList[i].MainWindowHandle, _Setting.X, _Setting.Y, _Setting.Width, _Setting.Height, true);
										}
										_Found[ii]=true;
									}
								}
							}
						}
					}
				}
			}
			StatusLabel.Text="Launching processes not found...";
			StatusLabel.Update();
			for(Int32 i=0;!i.Equals(_Found.Length);i++) {
				StatusLabel.Text="Launching process " + i.ToString() +@"/"+_Found.Length.ToString();
				StatusLabel.Update();
				if(!_Found[i]&&!_Config[i].Equals(String.Empty)&&_Config[i].Length>=21) {
					WindowTools.WindowPositionSetting _Setting = WindowTools.WindowPositionStruct(_Config[i]);
					Process _NewProcess = Process.Start(_Setting.Path, _Setting.Args);

					//Sleep here ALLOW PROCESS TO START
					System.Threading.Thread.Sleep(1500);

					StringBuilder _String = new(_StringBuffer);
					if(WindowTools.GetWindowTextA(_NewProcess.MainWindowHandle, _String, _StringBuffer)>0) {
						if(!GetWindowRect(_NewProcess.MainWindowHandle, out RECT rct)) {
							_=MessageBox.Show("ERROR");
							return;
						}
						Rectangle myRect = new() { X=rct.Left, Y=rct.Top, Width=rct.Right-rct.Left, Height=rct.Bottom-rct.Top };
						WINDOWPLACEMENT param = new();
						param.length=Marshal.SizeOf(typeof(WINDOWPLACEMENT));
						//Get Window Status
						_=GetWindowPlacement(_NewProcess.MainWindowHandle, out param);
						if(!param.showCmd.Equals((Int32)WindowTools.WindowShowStyle.Show)&&!param.showCmd.Equals((Int32)WindowTools.WindowShowStyle.ShowMaximized)) {
							_=WindowTools.ShowWindow(_NewProcess.MainWindowHandle, WindowTools.WindowShowStyle.ShowNormalNoActivate);
							if(!GetWindowRect(_NewProcess.MainWindowHandle, out rct)) {
								_=MessageBox.Show("ERROR");
								return;
							}
							myRect=new() { X=rct.Left, Y=rct.Top, Width=rct.Right-rct.Left, Height=rct.Bottom-rct.Top };
						}
						param.rcNormalPosition=myRect;
						_=WindowTools.MoveWindow(_NewProcess.MainWindowHandle, _Setting.X, _Setting.Y, _Setting.Width, _Setting.Height, true);
						_Found[i]=true;
					}
				}
			}
			StatusLabel.Text="Applied!";
			StatusLabel.Update();
			ToggleButtons();

		}

		private void ClearTextboxButton_Click(object sender, EventArgs e) {
			richTextBox1.Text=String.Empty;
			richTextBox1.Update();
		}

		private void LoadWindowsButton_Click_1(object sender, EventArgs e) {
			StatusLabel.Text="Loading Window Positions";
			ToggleButtons();
			StatusLabel.Update();
			richTextBox1.Text=String.Empty;
			richTextBox1.Update();
			Int32 _StringBuffer = 2048;
			StringBuilder _Test2 = new();
			Process[] AllProcesses = Process.GetProcesses();
			if(AllProcesses.Length.Equals(0))
				return;
			if(!(AllProcesses[0] is null)) {
				Process[] processList = Process.GetProcesses();
				StringBuilder _WindowTitle = new(_StringBuffer);
				foreach (Process _Process in processList) {
					_=_WindowTitle.Clear();
					if(//!_Process.MainWindowHandle.Equals(Process.GetCurrentProcess().MainWindowHandle)&&
						!_Process.ProcessName.Equals(String.Empty)&&
						!_Process.MainWindowTitle.Equals(String.Empty)&&
						WindowTools.GetWindowTextA(_Process.MainWindowHandle, _WindowTitle, _StringBuffer)>0) {
						if(!GetWindowRect(_Process.MainWindowHandle, out RECT rct)) {
							_=MessageBox.Show("ERROR");
							return;
						}
						Rectangle _Rectangle = new() { X=rct.Left, Y=rct.Top, Width=rct.Right-rct.Left, Height=rct.Bottom-rct.Top };

						WINDOWPLACEMENT param = new();
						param.length=Marshal.SizeOf(typeof(WINDOWPLACEMENT));
						//Get Window Status
						_=GetWindowPlacement(_Process.MainWindowHandle, out param);
						if(!param.showCmd.Equals((Int32)WindowTools.WindowShowStyle.Show)&&!param.showCmd.Equals((Int32)WindowTools.WindowShowStyle.ShowMaximized)) {
							param.showCmd=(Int32)WindowTools.WindowShowStyle.ShowNormalNoActivate; //Restore from minimized
							_=WindowTools.ShowWindow(_Process.MainWindowHandle, WindowTools.WindowShowStyle.ShowNormalNoActivate);
							param.rcNormalPosition=_Rectangle;
						} else {
							param.rcNormalPosition=_Rectangle;
						}

						if(!GetWindowRect(_Process.MainWindowHandle, out RECT rct2)) {
							_=MessageBox.Show("ERROR");
							return;
						}
						_Rectangle=new() { X=rct2.Left, Y=rct2.Top, Width=rct2.Right-rct2.Left, Height=rct2.Bottom-rct2.Top };

						try {
							_=_Test2.Append(
								_WindowTitle.ToString()+"...."+
								_Rectangle.X.ToString()+"...."+
								_Rectangle.Y.ToString()+"...."+
								_Rectangle.Width.ToString()+"...."+
								_Rectangle.Height.ToString()+"...."+
								_Process.MainModule.FileName+"...."+
								(!_Process.MainWindowHandle.Equals(Process.GetCurrentProcess().MainWindowHandle)?
									CMDLINE.GetCommandLine(_Process).Replace(_Process.MainModule.FileName,String.Empty).Replace(@"""",String.Empty).Trim():
									CMDLINE.GetCommandLine(Process.GetCurrentProcess()).Replace(Process.GetCurrentProcess().MainModule.FileName, String.Empty).Replace(@"""", String.Empty).Trim())+
								Environment.NewLine);
						}catch(Win32Exception ex) when(ex.HResult.Equals(-2147467259)) { 
						}catch(InvalidOperationException ex) when(ex.HResult.Equals(-2146233079)) { }
					}
				}
				richTextBox1.Text=_Test2.ToString();
				richTextBox1.Update();
			}
			StatusLabel.Text="Loaded Window Positions!";
			ToggleButtons();
			StatusLabel.Update();

		}

		private void WindowPositions_ResizeEnd(object sender, EventArgs e) {
			richTextBox1.Width=this.Width-41;
			richTextBox1.Height=this.Height-123;
			richTextBox1.Update();
		}
	}
}
