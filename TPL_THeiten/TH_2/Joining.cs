using System;
using System.Threading;
using static System.Console;

namespace TH_2
{
  internal class Joining
  {
    public static void Join1()
    {
      ParameterizedThreadStart _do = (param) => {
        Thread.Sleep(250);
      };
      var thread = new Thread(_do);

      thread.Start();
      System.Console.WriteLine($"starting to join");

      thread.Join();
      System.Console.WriteLine($"done joining");
    }

  }
}