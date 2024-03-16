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
	using System.Collections;

	public partial class WindowPositions : Form {

		[LibraryImport("user32.dll")]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static partial Boolean GetWindowRect(IntPtr hWnd, out RECT lpRect);

		[StructLayout(LayoutKind.Sequential)]
		private struct RECT {
			internal Int32 Left;        // x position of upper-left corner
			internal Int32 Top;         // y position of upper-left corner
			internal Int32 Right;       // x position of lower-right corner
			internal Int32 Bottom;      // y position of lower-right corner
		}
		//Definition for Window Placement Structure
		[StructLayout(LayoutKind.Sequential)]
		private struct WINDOWPLACEMENT {
			internal Int32 length;
			internal Int32 flags;
			internal Int32 showCmd;
			internal System.Drawing.Point ptMinPosition;
			internal System.Drawing.Point ptMaxPosition;
			internal System.Drawing.Rectangle rcNormalPosition;
		}

		public WindowPositions() {
			InitializeComponent();
			ResX.Text = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width.ToString();
			ResY.Text = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height.ToString();
			_ = Task.Run(() => UpdateMousePos());
		}
		private void UpdateMousePos() {
			while (true) {
				MouseX.Text = System.Windows.Forms.Cursor.Position.X.ToString();
				MouseY.Text = System.Windows.Forms.Cursor.Position.Y.ToString();
				MouseX.Update();
				MouseY.Update();
				//Tweaked to be more responsive
				//(1 second down to 1/4 second)
				System.Threading.Thread.Sleep(250);
			}
		}

		private void LoadFileButton_Click(object sender, EventArgs e) {
			ToggleButtons();
			String _File = openFileDialog1.ShowDialog() == DialogResult.OK ?
				openFileDialog1.FileName : "ERROR";
			if (_File != "ERROR" && File.Exists(_File)) {
				ParameterList.Clear();
				ParameterList.Text = File.ReadAllText(_File);
				ParameterList.Update();
				StatusLabel.Text = "Loaded from " + _File;
				StatusLabel.Update();
			}
			ToggleButtons();
		}

		private void SaveButton_Click(object sender, EventArgs e) {
			ToggleButtons();
			String _File = saveFileDialog1.ShowDialog() == DialogResult.OK ?
				saveFileDialog1.FileName : "ERROR";
			if (_File != "ERROR" && File.Exists(_File)) {
				File.Delete(_File);
			}
			File.WriteAllText(_File, ParameterList.Text);
			StatusLabel.Text = String.Concat("Saved to ", _File, " successfully");
			StatusLabel.Update();
			ToggleButtons();
		}
		private void ToggleButtons() {
			LoadWindowsButton.Enabled = !LoadWindowsButton.Enabled;
			SaveFileButton.Enabled = !SaveFileButton.Enabled;
			LoadFileButton.Enabled = !LoadFileButton.Enabled;
			ApplyButton.Enabled = !ApplyButton.Enabled;
			ClearTextboxButton.Enabled = !ClearTextboxButton.Enabled;
			TimeBetweenLaunchesms_Text.Enabled = !TimeBetweenLaunchesms_Text.Enabled;

			LoadWindowsButton.Update();
			SaveFileButton.Update();
			LoadFileButton.Update();
			ApplyButton.Update();
			ClearTextboxButton.Update();
			TimeBetweenLaunchesms_Text.Update();
		}

		private void ApplyButton_Click(object sender, EventArgs e) {
			if (!CheckTimerTextBox())
				return;
			if (ParameterList.Text.Length <= 21) {
				_ = MessageBox.Show("Configuration empty or incomplete");
				return;
			}
			String[] _Config = ParameterList.Lines;
			Process[] AllProcesses = Process.GetProcesses();
			BitArray _Found = new(_Config.Length, false);
			ToggleButtons();
			StatusLabel.Text = "Applying";
			StatusLabel.Update();
			if (AllProcesses is not null &&
				!AllProcesses.Length.Equals(0)) {
				Process[] _ProcessList = Process.GetProcesses();
				//TODO: ASYNC
				for (Int32 i = 0; !i.Equals(_ProcessList.Length); i++) {
					StatusLabel.Text = String.Concat(
						"Checking process ",
						i.ToString(),
						@" out of ",
						_ProcessList.Length.ToString());
					StatusLabel.Update();

					if (_ProcessList[i].ProcessName == String.Empty &&
						_ProcessList[i].MainWindowTitle == String.Empty)
						continue;

					StringBuilder _String = new(Hotpaths.StringBuffer);
					if (WindowTools.GetWindowText(
						_ProcessList[i].MainWindowHandle,
						_String,
						Hotpaths.StringBuffer) <= 0)
						continue;
					if (!GetWindowRect(_ProcessList[i].MainWindowHandle,
						out RECT _Rectangle)) {
						_ = MessageBox.Show("ERROR: " +
							"GetWindowRect failed to retrieve dimensions");
						return;
					}
					Rectangle myRect = new() {
						X = _Rectangle.Left,
						Y = _Rectangle.Top,
						Width = _Rectangle.Right - _Rectangle.Left,
						Height = _Rectangle.Bottom - _Rectangle.Top
					};
					WINDOWPLACEMENT param = new() {
						length = Marshal.SizeOf(typeof(WINDOWPLACEMENT))
					};
					if (!param.showCmd.Equals((Int32)WindowTools.WindowShowStyle.Show)) {
						//_WindowPlacementValues.showCmd=WindowTools.SW_RESTORE; 
						//Restore from minimized
						_ = WindowTools.ShowWindow(
							_ProcessList[i].MainWindowHandle,
							WindowTools.WindowShowStyle.Show);
						if (!GetWindowRect(
							_ProcessList[i].MainWindowHandle,
							out _Rectangle)) {
							_ = MessageBox.Show("ERROR: " +
								"GetWindowRect failed to restore window.");
							return;
						}
						myRect = new() {
							X = _Rectangle.Left,
							Y = _Rectangle.Top,
							Width = _Rectangle.Right - _Rectangle.Left,
							Height = _Rectangle.Bottom - _Rectangle.Top
						};
					}
					param.rcNormalPosition = myRect;
					for (Int32 ii = 0; !ii.Equals(_Config.Length); ii++) {
						if (_Found[ii] ||
							_Config[ii] == String.Empty &&
							_Config[ii].Length < 21)
							continue;
						WindowTools.WindowPositionSetting _Setting =
							WindowTools.WindowPositionStruct(_Config[ii]);
						if (
							//Cancel Window Title Checks (for if Found)
							(_String.ToString() == _Setting.WindowTitle ||
								(!_ProcessList[i].MainWindowHandle.Equals(
									Process.GetCurrentProcess().MainWindowHandle) ?
									Hotpaths.CleanFileName(
										CommandLine.GetCommandLine(_ProcessList[i]),
										_ProcessList[i].MainModule.FileName)
									== _Setting.Args :
									Hotpaths.CleanFileName(
										CommandLine.GetCommandLine(Process.GetCurrentProcess()),
										Environment.ProcessPath)
									== _Setting.Args)
							)
							&&
							(!_ProcessList[i].MainWindowHandle
								.Equals(Process.GetCurrentProcess().MainWindowHandle) ?
								_ProcessList[i].MainModule.FileName == _Setting.Path :
								Environment.ProcessPath == _Setting.Path)
							) {
							//Apply Settings
							if (!myRect.X.Equals(_Setting.X) ||
								!myRect.Y.Equals(_Setting.Y) ||
								!myRect.Width.Equals(_Setting.Width) ||
								!myRect.Height.Equals(_Setting.Height)) {
								param.length = Marshal.SizeOf(typeof(WINDOWPLACEMENT));
								param.rcNormalPosition = new() {
									X = _Setting.X,
									Y = _Setting.Y,
									Width = _Setting.Width,
									Height = _Setting.Height
								};
								_ = WindowTools.MoveWindow(
									_ProcessList[i].MainWindowHandle,
									_Setting.X,
									_Setting.Y,
									_Setting.Width,
									_Setting.Height,
									true);
							}

							//Force Show Window here anyway (Fix)
							_ = WindowTools.ShowWindow(
								_ProcessList[i].MainWindowHandle,
								WindowTools.WindowShowStyle.Show);

							_Found[ii] = true;
						}
					}
				}
			}
			StatusLabel.Text = "Launching processes not found";
			StatusLabel.Update();

			//TODO: ASYNC
			for (Int32 i = 0; !i.Equals(_Found.Length); i++) {
				StatusLabel.Text = "Launching process " +
					i.ToString() + @"/" +
					_Found.Length.ToString();
				StatusLabel.Update();
				if (_Found[i] || 
					_Config[i] == String.Empty || 
					_Config[i].Length < 21)
					continue;
				WindowTools.WindowPositionSetting _Setting = 
					WindowTools.WindowPositionStruct(_Config[i]);
				Process _NewProcess = Process.Start(_Setting.Path, _Setting.Args);
				//Sleep here to ALLOW PROCESS TO START
				System.Threading.Thread.Sleep(Hotpaths.SavedTimerMilliseconds);
				StringBuilder _String = new(Hotpaths.StringBuffer);
				if (WindowTools.GetWindowText(
					_NewProcess.MainWindowHandle,
					_String,
					Hotpaths.StringBuffer) <= 0)
					continue;
				if (!GetWindowRect(_NewProcess.MainWindowHandle, out RECT rct)) {
					_ = MessageBox.Show("ERROR: " +
						"Failed GetWindowRect at Process Launch. Continuing");
					return;
				}
				Rectangle myRect = new() {
					X = rct.Left,
					Y = rct.Top,
					Width = rct.Right - rct.Left,
					Height = rct.Bottom - rct.Top
				};
				WINDOWPLACEMENT param = new() {
					length = Marshal.SizeOf(typeof(WINDOWPLACEMENT))
				};
				if (!param.showCmd.Equals((Int32)WindowTools.WindowShowStyle.Show)) {
					_ = WindowTools.ShowWindow(
						_NewProcess.MainWindowHandle,
						WindowTools.WindowShowStyle.Show);
					if (!GetWindowRect(_NewProcess.MainWindowHandle, out rct)) {
						_ = MessageBox.Show("ERROR: " +
							"Failed GetWindowRect at Process Launch. Continuing.");
						return;
					}
					myRect = new() {
						X = rct.Left,
						Y = rct.Top,
						Width = rct.Right - rct.Left,
						Height = rct.Bottom - rct.Top
					};
				}
				param.rcNormalPosition = myRect;
				_ = WindowTools.MoveWindow(_NewProcess.MainWindowHandle,
					_Setting.X, _Setting.Y, _Setting.Width, _Setting.Height, true);
				_Found[i] = true; //Applied successfully (use later)
			}
			StatusLabel.Text = "Applied!";
			StatusLabel.Update();
			ToggleButtons();
		}

		private void ClearTextboxButton_Click(object sender, EventArgs e) {
			ParameterList.Text = String.Empty;
			ParameterList.Update();
		}

		private void LoadWindowsButton_Click(object sender, EventArgs e) {
			StatusLabel.Text = "Loading window positions - please wait...";
			ToggleButtons();
			StatusLabel.Update();
			ParameterList.Text = String.Empty;
			ParameterList.Update();
			StringBuilder _StringBuilder = new();
			Process[] _AllProcesses = Process.GetProcesses();
			if (_AllProcesses is null || _AllProcesses.Length.Equals(0))
				return;
			foreach (Process _Process in _AllProcesses) {
				StringBuilder _StringBuilder2 = new(Hotpaths.WindowTextBuffer);
				if (_Process.ProcessName == String.Empty ||
					_Process.MainWindowTitle == String.Empty ||
					WindowTools.GetWindowText(
						_Process.MainWindowHandle, 
						_StringBuilder2, 
						Hotpaths.WindowTextBuffer
						) <= 0)
					continue;
				if (!GetWindowRect(_Process.MainWindowHandle, out RECT rct)) {
					_ = MessageBox.Show("ERROR: Could not load window dimensions (GetWindowText)");
					return;
				}
				Rectangle _Rectangle = new() {
					X = rct.Left,
					Y = rct.Top,
					Width = rct.Right - rct.Left,
					Height = rct.Bottom - rct.Top
				};

				WINDOWPLACEMENT _WindowPlacementValues = new() {
					length = Marshal.SizeOf(typeof(WINDOWPLACEMENT))
				};
				if (!_WindowPlacementValues.showCmd.Equals((Int32)WindowTools.WindowShowStyle.Show)) {
					//_WindowPlacementValues.showCmd=WindowTools.SW_RESTORE; //SW_SHOWNORMAL
					_ = WindowTools.ShowWindow(
						_Process.MainWindowHandle,
						WindowTools.WindowShowStyle.Show);
				}
				_WindowPlacementValues.rcNormalPosition = _Rectangle;

				if (!GetWindowRect(_Process.MainWindowHandle, out RECT rct2)) {
					_ = MessageBox.Show("ERROR: Could not get window dimensions (GetWindowText)");
					return;
				}
				_Rectangle = new() {
					X = rct2.Left,
					Y = rct2.Top,
					Width = rct2.Right - rct2.Left,
					Height = rct2.Bottom - rct2.Top
				};

				try {
					_ = _StringBuilder.Append(
						String.Concat(
							_StringBuilder2.ToString(),
							Hotpaths.Separator +
							_Rectangle.X.ToString(),
							Hotpaths.Separator +
							_Rectangle.Y.ToString(),
							Hotpaths.Separator +
							_Rectangle.Width.ToString(),
							Hotpaths.Separator +
							_Rectangle.Height.ToString(),
							Hotpaths.Separator +
							_Process.MainModule.FileName,
							Hotpaths.Separator,
							_Process.MainWindowHandle.Equals(
								Process.GetCurrentProcess().MainWindowHandle) ?
									Hotpaths.CleanFileName(
										CommandLine.GetCommandLine(Process.GetCurrentProcess()),
										Environment.ProcessPath)
								:
								Hotpaths.CleanFileName(
									CommandLine.GetCommandLine(_Process),
									_Process.MainModule.FileName)
							,
							Environment.NewLine));
				} catch (Win32Exception ex) when (ex.HResult.Equals(-2147467259)) {
					//
				} catch (InvalidOperationException ex) when (ex.HResult.Equals(-2146233079)) {
					//
				}
				_ = _StringBuilder2.Clear();
			}
			ParameterList.Text = _StringBuilder.ToString();
			ParameterList.Update();
			StatusLabel.Text = "Loaded window positions";
			ToggleButtons();
			StatusLabel.Update();

		}
		private Boolean CheckTimerTextBox() {
			try {
				if (Convert.ToInt32(TimeBetweenLaunchesms_Text.Text) >= 0) {
					Hotpaths.SavedTimerMilliseconds = Convert.ToInt32(TimeBetweenLaunchesms_Text.Text);
					return true;
				}
			} catch {
				MessageBox.Show(String.Concat(
					"Time between launch parse failed: ",
					TimeBetweenLaunchesms_Text.Text));
			}
			return false;
		}

		private void WindowPositions_ResizeEnd(object sender, EventArgs e) {
			ParameterList.Width = this.Width - 41;
			ParameterList.Height = this.Height - 123;
			ParameterList.Update();
		}
	}
}
