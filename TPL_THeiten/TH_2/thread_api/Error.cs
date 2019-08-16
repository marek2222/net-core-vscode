using System;
using System.Threading;
using static System.Console;

namespace TH_2.thread_api
{
  internal class Error
  {
    public static void Handle()
    {
      var thread = new Thread(() => {
        try
        {
          throw new Exception($"this thread run havoc: {Thread.CurrentThread.Name}");
        }
        catch (System.Exception ex)
        {
          System.Console.WriteLine($"Gets called this time around {ex.Message}");
        }
      });
      thread.Name = "our named Thread";
      thread.Start();

    }

  }
}