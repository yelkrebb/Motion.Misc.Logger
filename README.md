# Motion.Misc.Logger


#Usage:
  #Logger log = Logger.GetInstance();
  
  #log.ConfigureLogger("string_Filename", "string_Foldername", "LogLevel");
  
  #await log.Info("Test Message from Test App");
  
  #await log.Error("Something went wrong...");
  
  #await log.Warn("Bluetooth is busy...");
  
  #await log.Trace("Trace logging...");
