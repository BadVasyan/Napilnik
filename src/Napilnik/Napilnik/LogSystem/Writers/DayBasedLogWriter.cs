using System;

namespace Napilnik.LogSystem.Writers
{
  public class DayBasedLogWriter : LogWriter
  {
    private readonly ILogWriter _logWriter;
    private readonly DayOfWeek _day;

    public DayBasedLogWriter(ILogWriter logWriter, DayOfWeek day)
    {
      _logWriter = logWriter ?? throw new ArgumentNullException(nameof(logWriter));
      _day = day;
    }

    protected override void WriteMessage(string message)
    {
      if (DateTime.Now.DayOfWeek.Equals(_day))
        _logWriter.Write(message);
    }
  }
}