using System;
using System.Threading;
using static System.Console;

namespace TH_2
{
  internal class Stopping
  {
    public static void Stop1()
    {
      var thread = new Thread(() => WriteLine("thread is stopped when this returns"));
      thread.Start();
      //Thread.Sleep(500);
      string threadState =
        thread.ThreadState == ThreadState.Stopped ? "stopped" : "running";
      System.Console.WriteLine($"we can tell by the thread state: {threadState}");
    }

    public static void Stop2()
    {
      var thread = new Thread(() => WriteLine("thread is stopped when this returns"));
      thread.Start();
      Thread.Sleep(500);
      string threadState =
        thread.ThreadState == ThreadState.Stopped ? "stopped" : "running";
      System.Console.WriteLine($"we can tell by the thread state: {threadState}");
    }

    public static bool ShouldStop = false;
    public static void StopByRequest()
    {
      System.Console.WriteLine("starting");
      new Thread(() =>
      {
        while (!ShouldStop)
        {
          System.Console.WriteLine("still not stopped yet");
          Thread.Sleep(200);
        }
      }).Start();
    }

    public static void Stop3()
    {
      StopByRequest();
      while (!ShouldStop)
      {
        Thread.Sleep(200);
        int rnd = new Random().Next(0, 10);
        if (rnd == 5)
          ShouldStop = true;
      }
			System.Console.WriteLine("stopped");
			return;
    }

  }
}