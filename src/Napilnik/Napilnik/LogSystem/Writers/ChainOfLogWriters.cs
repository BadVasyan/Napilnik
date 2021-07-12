using System;
using System.Collections.Generic;
using System.Linq;

namespace Napilnik.LogSystem.Writers
{
  public class ChainOfLogWriters : LogWriter
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

    public static ILogWriter Create(params ILogWriter[] writers) =>
      new ChainOfLogWriters(writers);

    protected override void WriteMessage(string message)
    {
      foreach (ILogWriter writer in _logWriters)
        writer.Write(message);
    }

    private static bool ContainsNullWriter(IEnumerable<ILogWriter> logWriters) =>
      logWriters.Any(writer => writer == null);
  }
}