using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowPosition {
	internal static class Hotpaths {
		internal static Int32 SavedTimerMilliseconds { get; set; }
		internal static Int32 StringBuffer => 2048;
		internal static Int32 WindowTextBuffer => Int16.MaxValue / 2;
		internal static String Separator => @"....";
		private static String ParenthesisClean => @"""";
		public static String CleanFileName(String _CommandLine, String _FileName) =>
			_CommandLine.Replace(_FileName, String.Empty)
				.Replace(ParenthesisClean, String.Empty)
				.Trim();
	}
}
