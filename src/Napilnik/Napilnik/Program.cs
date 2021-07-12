using Napilnik.LogSystem;

namespace Napilnik
{
  internal static class Program
  {
    public static void Main(string[] args)
    {
      UseCase();
    }

    private static void UseCase()
    {
      var logWriterFactory = new LogWriterFactory();

      var consoleLogs = new Pathfinder(logWriterFactory.CreateConsoleWriter());
      var fileLogs = new Pathfinder(logWriterFactory.CreateFileWriter());
      var fridayConsoleLogs = new Pathfinder(logWriterFactory.CreateFridayConsoleWriter());
      var fridayFileLogs = new Pathfinder(logWriterFactory.CreateFridayFileWriter());
      var consoleAndFridayFileLogs = new Pathfinder(logWriterFactory.CreateConsoleAndFridayFileWriter());

      consoleLogs.Find();
    }
  }
}