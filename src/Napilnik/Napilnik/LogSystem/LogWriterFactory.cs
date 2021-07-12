using System;
using Napilnik.LogSystem.Writers;

namespace Napilnik.LogSystem
{
  public class LogWriterFactory
  {
    public ILogWriter CreateFileWriter() =>
      new FileLogWriter();

    public ILogWriter CreateConsoleWriter() => 
      new ConsoleLogWriter();

    public ILogWriter CreateFridayFileWriter() =>
      new DayBasedLogWriter(new FileLogWriter(), DayOfWeek.Friday);
    
    public ILogWriter CreateFridayConsoleWriter() =>
      new DayBasedLogWriter(new ConsoleLogWriter(), DayOfWeek.Friday);

    public ILogWriter CreateConsoleAndFridayFileWriter() => 
      ChainOfLogWriters.Create(CreateConsoleWriter(), CreateFridayFileWriter());
  }
}