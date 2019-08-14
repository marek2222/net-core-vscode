using System;
using System.Threading;

namespace TH_2
{
  public class Ex_3
  {

    /////////////////////////  
    /// 3_3  
    // [ThreadStatic]
		// private static int x3 = 42;

    public void RunStatic_3()
    {
			for (int i = 0; i < 5; i++)
			{
				new Thread(() => {
					System.Console.WriteLine(x3);
				}).Start();
			}
    }

		ThreadLocal<int> x3 = new ThreadLocal<int>(() => 42);


    /////////////////////////  
    /// 3_2 - dla wersji statycznej
    
		// [ThreadStatic]
		// private static int x2 = 42;

    // private static void RunStatic_2()
    // {
		// 	for (int i = 0; i < 5; i++)
		// 	{
		// 		new Thread(() => {
		// 			System.Console.WriteLine(x2);
		// 		}).Start();
		// 	}
    // }


    /////////////////////////  
    /// 3_2
		private int x2 = 42;

    public void RunStatic_2()
    {
			for (int i = 0; i < 5; i++)
			{
				new Thread(() => {
					System.Console.WriteLine(x2);
				}).Start();
			}
    }


    /////////////////////////  
    /// 3_1
		private int x1;

    public void RunStatic_1()
    {
			for (int i = 0; i < 5; i++)
			{
				int index = i;
				new Thread(() => {
					x1 = index;
					System.Console.WriteLine(x1);
				}).Start();
			}
    }

  }
}