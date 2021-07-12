using System;

namespace Napilnik.LogSystem.Writers
{
  public class DayBasedLogWriter : ILogWriter
  {
    private readonly ILogWriter _logWriter;
    private readonly DayOfWeek _day;

    public DayBasedLogWriter(ILogWriter logWriter, DayOfWeek day)
    {
      _logWriter = logWriter ?? throw new ArgumentNullException(nameof(logWriter));
      _day = day;
    }

    public void Write(string message)
    {
      if (string.IsNullOrEmpty(message))
        throw new ArgumentException("Message can't be null or empty", nameof(message));
      
      if (DateTime.Now.DayOfWeek.Equals(_day))
        _logWriter.Write(message);
    }
  }
}