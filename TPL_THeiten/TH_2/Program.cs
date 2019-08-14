using System;
using System.Threading;

namespace TH_2
{
  class Program
  {
		///	run in Terminal by:	dotnet run TH_2.csproj

    static void Main(string[] args)
    {



 		  /////////////////////////  
 			/// Examples with section 3
		
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
  }
}
