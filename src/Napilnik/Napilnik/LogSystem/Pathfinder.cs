using System;
using Napilnik.LogSystem.Writers;

namespace Napilnik.LogSystem
{
  public class Pathfinder
  {
    private readonly ILogWriter _logWriter;

    public Pathfinder(ILogWriter logWriter)
    {
      _logWriter = logWriter ?? throw new ArgumentNullException(nameof(logWriter));
    }

    public void Find()
    {
      _logWriter.Write("Some message");
    }
  }
}