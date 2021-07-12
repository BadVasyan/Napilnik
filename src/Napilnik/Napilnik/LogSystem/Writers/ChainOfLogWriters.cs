using System;
using System.Collections.Generic;
using System.Linq;

namespace Napilnik.LogSystem.Writers
{
  public class ChainOfLogWriters : ILogWriter
  {
    private readonly IEnumerable<ILogWriter> _logWriters;

    public ChainOfLogWriters(IEnumerable<ILogWriter> logWriters)
    {
      if (logWriters == null)
        throw new ArgumentNullException(nameof(logWriters));

      if (ContainsNullWriter(logWriters))
        throw new NullReferenceException();

      _logWriters = logWriters;
    }

    public void Write(string message)
    {
      if (string.IsNullOrEmpty(message))
        throw new ArgumentException("Message can't be null or empty", nameof(message));

      foreach (ILogWriter writer in _logWriters)
        writer.Write(message);
    }

    public static ILogWriter Create(params ILogWriter[] writers) =>
      new ChainOfLogWriters(writers);

    private static bool ContainsNullWriter(IEnumerable<ILogWriter> logWriters) =>
      logWriters.Any(writer => writer == null);
  }
}