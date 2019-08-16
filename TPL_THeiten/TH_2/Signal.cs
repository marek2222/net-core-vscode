using System;
using System.Threading;
using static System.Console;

namespace code
{
  internal class Signal
  {
    private static EventWaitHandle _turnstile = new AutoResetEvent(initialState: false);
    public static void Run()
    {
      new Thread(Waiter).Start();
      Thread.Sleep(3000);
      System.Console.WriteLine($"Open the gates!!!");

      _turnstile.Set();
    }

    private static void Waiter(object state)
    {
      System.Console.WriteLine("Waiting");
      _turnstile.WaitOne();
      System.Console.WriteLine("Doing process!!!");
      Thread.Sleep(3000);
      System.Console.WriteLine("Notified");
    }

  }
}