using System;
using System.IO;
using PCLStorage;

using Motion.Mobile.Utilities;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;

namespace Motion.Misc.Logger
{
	public class Logger : ILogger
	{
		private static readonly object _syncLock = new object();
		private static Logger _logger;

		private static LogLevel _level;

		private static string _filename;
		private static string _foldername;

		private Logger()
		{
		}

		private async Task writeToFile(string contents, string className, int lineNumber, LogLevel level)
		{
			IFolder rootFolder = FileSystem.Current.LocalStorage;
			IFolder folder = await rootFolder.CreateFolderAsync(_foldername,
				CreationCollisionOption.OpenIfExists);

			IFile file = await folder.CreateFileAsync(_filename,
			                                          CreationCollisionOption.OpenIfExists);
			string newContents;
			//using (StreamReader stream = new StreamReader(await file.OpenAsync(FileAccess.Read)))
			//{
			//string currentContents = stream.ReadToEnd();

			string currentContents = await file.ReadAllTextAsync();
			newContents = currentContents + DateTime.Now.ToString("\nyyyy-MM-dd HH:mm:ss:fff \t") + level.ToString() + "\t" + className + "\tLine:"+ lineNumber.ToString("00000") + "\t" + contents;

			//}
			System.Diagnostics.Debug.WriteLine(newContents);
			await file.WriteAllTextAsync(newContents);
		}

		public static Logger GetInstance()
		{
			if (_logger == null)
			{
				lock (_syncLock)
				{
					if (_logger == null)
					{
						_logger = new Logger();
					}
				}
			}
			return _logger;
		}

		public void ConfigureLogger(string filename, string folderName, LogLevel level)
		{
			_level = level;
			_filename = filename;
			_foldername = folderName;
		}

		public async Task Error(string msg, string className, int lineNumber, [CallerMemberName] string caller = "")
		{
			if (_level >= LogLevel.ERROR)
			{
				await writeToFile(msg, className+"-"+caller, lineNumber, LogLevel.ERROR);
			}
			return;
		}

		public async Task Warn(string msg, string className, int lineNumber, [CallerMemberName] string caller = "")
		{
			if (_level >= LogLevel.WARN)
			{
				await writeToFile(msg, className + "-" + caller, lineNumber, LogLevel.WARN);
			}
		}

		public async Task Info(string msg, string className, int lineNumber, [CallerMemberName] string caller = "")
		{
			if (_level >= LogLevel.INFO)
			{
				await writeToFile(msg, className + "-" + caller, lineNumber, LogLevel.INFO);
			}
		}

		public async Task Debug(string msg, string className, int lineNumber, [CallerMemberName] string caller = "")
		{
			if (_level >= LogLevel.DEBUG)
			{
				await writeToFile(msg, className + "-" + caller, lineNumber, LogLevel.DEBUG);
			}
		}

		public async Task Trace(string msg, string className, int lineNumber, [CallerMemberName] string caller = "")
		{
			if (_level >= LogLevel.TRACE)
			{
				await writeToFile(msg, className + "-" + caller, lineNumber, LogLevel.TRACE);
			}
		}
	}
}

