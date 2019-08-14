using System;
using System.Threading;
using System.Collections.Generic;

namespace TH_2
{
  public class Ex_5
  {

    /////////////////////////  
    /// 5_1  
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

    public Ex_5()
    {
      s_runner = new Dictionary<string, Action>{
        ["stop1"]  = Stopping.Stop1,
        ["stop2"]  = Stopping.Stop2,
        ["stop3"]  = Stopping.Stop3,
      };
    }

  }
}