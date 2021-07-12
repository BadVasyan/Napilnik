using System;

namespace Napilnik.LogSystem.Writers
{
  public abstract class LogWriter : ILogWriter
  {
    public void Write(string message)
    {
      if (string.IsNullOrEmpty(message))
        throw new ArgumentException("Message can't be null or empty", nameof(message));

      WriteMessage(message);
    }

    protected abstract void WriteMessage(string message);
  }
}