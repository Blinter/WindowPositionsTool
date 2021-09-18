namespace WindowPosition {
	using System.Diagnostics;
	using System.Management;
	public static class CMDLINE {
		public static string GetCommandLine(Process _Process) {
			string cmdLine = null;
			using(var searcher = new ManagementObjectSearcher(
			  $"SELECT CommandLine FROM Win32_Process WHERE ProcessId = {_Process.Id}")) {
				using(var matchEnum = searcher.Get().GetEnumerator()) {
					if(matchEnum.MoveNext()){
						cmdLine=matchEnum.Current["CommandLine"]?.ToString();
					}
				}
			}
			if(cmdLine==null) {
				_= _Process.MainModule;
			}
			return cmdLine;
		}
	}
}
