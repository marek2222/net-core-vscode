using System;
using System.Threading;
using System.Collections.Generic;

namespace TH_2
{
  class Program
  {
		///	run in Terminal by:	dotnet run TH_2.csproj

    static void Main(string[] args)
    {
      //Example for section 4,5
      CallExample4(args);
      //CallExample3();
    }

    private static void CallExample4(string[] args)
    {
      System.Console.WriteLine("You can use it args from: 'start1' to 'start4', 'stop1' to 'stop3'.");
      new Ex_4().Run_1(args);
    }

    private static void CallExample3()
    {
      //Ex_3 example3 = new Ex_3();
      //example3.RunStatic_1();
      new Ex_3().RunStatic_1();
      NewLine();
      new Ex_3().RunStatic_2();
      NewLine();
      new Ex_3().RunStatic_3();
      NewLine();
      //Console.ReadKey();
    }

    private static void NewLine()
    {
      System.Console.WriteLine();
    }

    // static  Program()
    // {
    //   s_runner = new Dictionary<string, Action>
    //   {
    //     ["start"] = Starting.Start
    //   };
    // }

    // private static Dictionary<string, Action> s_runner;
  }
}
