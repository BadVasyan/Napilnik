using System;

namespace Napilnik.LogSystem.Writers
{
  public class ConsoleLogWriter : LogWriter
  {
    protected override void WriteMessage(string message) => 
      Console.WriteLine(message);
  }
}