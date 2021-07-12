using System;

namespace Napilnik.LogSystem.Writers
{
  public class ConsoleLogWriter : ILogWriter
  {
    public void Write(string message)
    {
      if (string.IsNullOrEmpty(message))
        throw new ArgumentException("Message can't be null or empty", nameof(message));

      Console.WriteLine(message);
    }
  }
}