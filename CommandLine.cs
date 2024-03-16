namespace WindowPosition {
	using System;
	using System.Diagnostics;
	using System.Management;
	internal static class CommandLine {
		internal static String GetCommandLine(Process _Process) {
			String _CommandLine = null;
			using (ManagementObjectSearcher _Searcher = new(
			  $"SELECT CommandLine FROM Win32_Process WHERE " +
				 $"ProcessId = {_Process.Id}")) {
				using ManagementObjectCollection.ManagementObjectEnumerator matchEnum =
					_Searcher.Get().GetEnumerator();
				if (matchEnum.MoveNext())
					_CommandLine = matchEnum.Current["CommandLine"]?.ToString();
			}
			if (_CommandLine is null)
				_ = _Process.MainModule;
			return _CommandLine;
		}
	}
}