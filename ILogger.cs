using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Motion.Misc.Logger
{
	public interface ILogger
	{
		Task Error(string msg, string className, int lineNumber, [CallerMemberName] string caller = "");
		Task Warn(string msg, string className, int lineNumber, [CallerMemberName] string caller = "");
		Task Info(string msg, string className, int lineNumber, [CallerMemberName] string caller = "");
		Task Debug(string msg, string className, int lineNumber, [CallerMemberName] string caller = "");
		Task Trace(string msg, string className, int lineNumber, [CallerMemberName] string caller = "");
	}
}

