using System;
using System.Threading;
using System.Collections.Generic;

namespace TH_2
{
  public class Ex_4
  {

    /////////////////////////  
    /// 4_1  
    public void Run_1(string[] args)
    {
      string key = string.Empty;
      try
      {
        key = args[1];
        s_runner[key].Invoke();
      }
      catch (System.Exception ex)
      {
        System.Console.WriteLine(ex.Message);
      }
      System.Console.WriteLine($"ran with key: {key}");
    }

    private Dictionary<string, Action> s_runner;

    public Ex_4()
    {
      s_runner = new Dictionary<string, Action>{
        ["start1"] = thread_api.Starting.Start1,
        ["start2"] = thread_api.Starting.Start2,
        ["start3"] = thread_api.Starting.Start3,
        ["start4"] = thread_api.Starting.Start4,
        ["stop1"]  = thread_api.Stopping.Stop1,
        ["stop2"]  = thread_api.Stopping.Stop2,
        ["stop3"]  = thread_api.Stopping.Stop3,
        ["stop4"]  = thread_api.Stopping.Stop4,
        ["join1"]  = thread_api.Joining.Join1,
        ["back1"]  = thread_api.background.Block1,
        ["back2"]  = thread_api.background.Block2,
        ["signal"] = thread_api.Signal.Run,
      };
    }

    public void ShowArgs()
    {
      System.Console.WriteLine("Write one of following parameter: ");
      foreach (var item in s_runner)
      {
          System.Console.WriteLine("  "+ item.Key);
          if (item.Key == "signal")
            System.Console.WriteLine(" Show big difference between AutoReset and ManualReset EventWaitHandle: ./Threading/EventWaitHandle1/EventWaitHandle1.csproj"); 
      }
    }
  }
}