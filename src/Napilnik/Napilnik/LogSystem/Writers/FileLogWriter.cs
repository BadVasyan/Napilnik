using System;
using System.IO;

namespace Napilnik.LogSystem.Writers
{
  public class FileLogWriter : ILogWriter
  {
    private const string LogFilePath = "log.txt";

    public void Write(string message)
    {
      if (string.IsNullOrEmpty(message))
        throw new ArgumentException("Message can't be null or empty", nameof(message));
      
      File.WriteAllText(LogFilePath, message);
    }
  }
}