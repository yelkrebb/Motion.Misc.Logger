using System;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

namespace Motion.Misc.Logger
{
	public interface ILogger
	{
		Task Error(string msg,[CallerFilePath] string className="",[CallerLineNumber] int lineNumber=0, [CallerMemberName] string caller = "");
		Task Warn(string msg, [CallerFilePath] string className = "", [CallerLineNumber] int lineNumber = 0, [CallerMemberName] string caller = "");
		Task Info(string msg, [CallerFilePath] string className = "", [CallerLineNumber] int lineNumber = 0, [CallerMemberName] string caller = "");
		Task Debug(string msg,[CallerFilePath] string className = "", [CallerLineNumber] int lineNumber = 0, [CallerMemberName] string caller = "");
		Task Trace(string msg,[CallerFilePath] string className = "", [CallerLineNumber] int lineNumber = 0, [CallerMemberName] string caller = "");
	}
}

