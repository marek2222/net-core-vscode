using System;
using System.Threading;
using static System.Console;

namespace TH_2
{
  internal class Starting
  {
		public static void Start1(){
			var thread = new Thread(RunAThread);
			thread.Start();
		}

		private static void RunAThread() => WriteLine("from our thread");

		public static void Start2(){
			var lambda = new Thread(() => WriteLine("from the lambda"));
			lambda.Start();
		}

		public static void Start3(){
			ParameterizedThreadStart _doWork = (param) => WriteLine(param);
			var thread_2 = new Thread(_doWork);
			thread_2.Start("from my argument"); 
		}

		public static void Start4(){
			ParameterizedThreadStart _doWork = (param) => WriteLine(param);
			var thread_2 = new Thread(_doWork);
			thread_2.Start(42); 
		}
	  
  }
}