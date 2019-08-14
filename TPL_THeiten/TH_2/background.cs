using System;
using System.Threading;
using static System.Console;

namespace TH_2
{
  internal class background
  {
    public static void Block1()
    {
      var thread = new Thread(() =>
      {
        Thread.Sleep(2000);
        System.Console.WriteLine("Finally");
      });
      thread.Start();
    }

    public static void Block2()
    {
      var thread = new Thread(() =>
      {
        Thread.Sleep(2000);
        System.Console.WriteLine("Finally");
      });
      thread.IsBackground = true;
      thread.Start();
    }

  }
}