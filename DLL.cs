namespace WindowPosition {
	using System;
	using System.Collections.Generic;
	using System.Runtime.InteropServices;
	using System.Text;
	public class WindowHandleInfo {
		private delegate bool EnumWindowProc(IntPtr hwnd, IntPtr lParam);
		[DllImport("user32")]
		[return: MarshalAs(UnmanagedType.Bool)]
		private static extern bool EnumChildWindows(IntPtr window, EnumWindowProc callback, IntPtr lParam);

		private IntPtr _MainHandle;
		public WindowHandleInfo(IntPtr handle) {
			this._MainHandle=handle;
		}
		public List<IntPtr> GetAllChildHandles() {
			List<IntPtr> childHandles = new();
			GCHandle gcChildhandlesList = GCHandle.Alloc(childHandles);
			IntPtr pointerChildHandlesList = GCHandle.ToIntPtr(gcChildhandlesList);
			try {
				EnumWindowProc childProc = new(EnumWindow);
				_=EnumChildWindows(this._MainHandle, childProc, pointerChildHandlesList);
			} finally {
				gcChildhandlesList.Free();
			}
			return childHandles;
		}
		private bool EnumWindow(IntPtr hWnd, IntPtr lParam) {
			GCHandle gcChildhandlesList = GCHandle.FromIntPtr(lParam);
			if(gcChildhandlesList.Target==null) {
				return false;
			}
			List<IntPtr> childHandles = gcChildhandlesList.Target as List<IntPtr>;
			childHandles.Add(hWnd);
			return true;
		}
	}
	public static class WindowTools {

		[DllImport("user32.dll", EntryPoint = "GetWindowTextA")]
		public static extern Int32 GetWindowTextA(IntPtr hWnd, StringBuilder text, Int32 count);

		[DllImport("user32.dll", SetLastError = true)]
		public static extern bool MoveWindow(IntPtr hWnd, Int32 X, Int32 Y, Int32 Width, int Height, Boolean Repaint);

		[DllImport("user32.dll")]
		public static extern bool ShowWindow(IntPtr hWnd, WindowShowStyle nCmdShow);

		public enum WindowShowStyle : UInt16 {
			/// <summary>Hides the window and activates another window.</summary>
			/// <remarks>See SW_HIDE</remarks>
			Hide = 0,
			/// <summary>Activates and displays a window. If the window is minimized 
			/// or maximized, the system restores it to its original size and 
			/// position. An application should specify this flag when displaying 
			/// the window for the first time.</summary>
			/// <remarks>See SW_SHOWNORMAL</remarks>
			ShowNormal = 1,
			/// <summary>Activates the window and displays it as a minimized window.</summary>
			/// <remarks>See SW_SHOWMINIMIZED</remarks>
			ShowMinimized = 2,
			/// <summary>Activates the window and displays it as a maximized window.</summary>
			/// <remarks>See SW_SHOWMAXIMIZED</remarks>
			ShowMaximized = 3,
			/// <summary>Maximizes the specified window.</summary>
			/// <remarks>See SW_MAXIMIZE</remarks>
			Maximize = 3,
			/// <summary>Displays a window in its most recent size and position. 
			/// This value is similar to "ShowNormal", except the window is not 
			/// actived.</summary>
			/// <remarks>See SW_SHOWNOACTIVATE</remarks>
			ShowNormalNoActivate = 4,
			/// <summary>Activates the window and displays it in its current size 
			/// and position.</summary>
			/// <remarks>See SW_SHOW</remarks>
			Show = 5,
			/// <summary>Minimizes the specified window and activates the next 
			/// top-level window in the Z order.</summary>
			/// <remarks>See SW_MINIMIZE</remarks>
			Minimize = 6,
			/// <summary>Displays the window as a minimized window. This value is 
			/// similar to "ShowMinimized", except the window is not activated.</summary>
			/// <remarks>See SW_SHOWMINNOACTIVE</remarks>
			ShowMinNoActivate = 7,
			/// <summary>Displays the window in its current size and position. This 
			/// value is similar to "Show", except the window is not activated.</summary>
			/// <remarks>See SW_SHOWNA</remarks>
			ShowNoActivate = 8,
			/// <summary>Activates and displays the window. If the window is 
			/// minimized or maximized, the system restores it to its original size 
			/// and position. An application should specify this flag when restoring 
			/// a minimized window.</summary>
			/// <remarks>See SW_RESTORE</remarks>
			Restore = 9,
			/// <summary>Sets the show state based on the SW_ value specified in the 
			/// STARTUPINFO structure passed to the CreateProcess function by the 
			/// program that started the application.</summary>
			/// <remarks>See SW_SHOWDEFAULT</remarks>
			ShowDefault = 10,
			/// <summary>Windows 2000/XP: Minimizes a window, even if the thread 
			/// that owns the window is hung. This flag should only be used when 
			/// minimizing windows from a different thread.</summary>
			/// <remarks>See SW_FORCEMINIMIZE</remarks>
			ForceMinimized = 11
		}
		public struct WindowPositionSetting {
			public String WindowTitle;
			public Int32 X;
			public Int32 Y;
			public Int32 Width;
			public Int32 Height;
			public String Path;
			public String Args;
		}
		public static WindowPositionSetting WindowPositionStruct(String[] _Input) =>
			new() {
				WindowTitle=_Input[0],
				X=Convert.ToInt32(_Input[1]),
				Y=Convert.ToInt32(_Input[2]),
				Width=Convert.ToInt32(_Input[3]),
				Height=Convert.ToInt32(_Input[4]),
				Path=_Input[5],
				Args=_Input[6]
			};
		public static WindowPositionSetting WindowPositionStruct(String _Input) {
			String[] _Split = _Input.Split("....");
			return new() {
				WindowTitle=_Split[0],
				X=Convert.ToInt32(_Split[1]),
				Y=Convert.ToInt32(_Split[2]),
				Width=Convert.ToInt32(_Split[3]),
				Height=Convert.ToInt32(_Split[4]),
				Path=_Split[5],
				Args=_Split[6]
			};
		}
	}

}
