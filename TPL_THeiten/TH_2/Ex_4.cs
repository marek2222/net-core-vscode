using System;
using System.Threading;

namespace TH_2
{
  public class Ex_4
  {

    /////////////////////////  
    /// 3_3  
		private int x3 = 42;

    public void RunStatic_3()
    {
			for (int i = 0; i < 5; i++)
			{
				new Thread(() => {
					System.Console.WriteLine(x3);
				}).Start();
			}
    }

  }
}