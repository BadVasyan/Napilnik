using System.IO;

namespace Napilnik.LogSystem.Writers
{
  public class FileLogWriter : LogWriter
  {
    private const string LogFilePath = "log.txt";

    protected override void WriteMessage(string message) => 
      File.WriteAllText(LogFilePath, message);
  }
}