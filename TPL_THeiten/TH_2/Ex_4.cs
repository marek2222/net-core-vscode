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
        ["start1"] = Starting.Start1,
        ["start2"] = Starting.Start2,
        ["start3"] = Starting.Start3,
        ["start4"] = Starting.Start4,
        ["stop1"]  = Stopping.Stop1,
        ["stop2"]  = Stopping.Stop2,
        ["stop3"]  = Stopping.Stop3,
      };
    }

  }
}