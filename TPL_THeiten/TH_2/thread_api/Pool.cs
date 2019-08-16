using System;
using System.Threading;
using static System.Console;

namespace TH_2.thread_api
{
  internal class Pool
  {
    public static void Pooling1()
    {
      ThreadPool.QueueUserWorkItem(s =>
      {
        System.Console.WriteLine("run this as background thread");
      });
      Thread.Sleep(2000);
    }

    public static void Pooling2()
    {
      System.Console.WriteLine("from a task");
      Thread.Sleep(2000);
    }


  }
}