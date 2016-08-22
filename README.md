# Motion.Misc.Logger


Usage:
  Logger log = Logger.GetInstanche();
  log.ConfigureLogger(DateTime.Now.ToString("yyyy-MM-dd ") + "Test App", "Trio Logs", LogLevel.INFO);
  
  await log.Info("Test Message from Test App");
  await log.Error("Something went wrong...");
  await log.Warn("Bluetooth is busy...");
  await log.Trace("Trace logging...");
