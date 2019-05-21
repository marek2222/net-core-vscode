using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace TaskParallelLibrary._1_Dataflow
{
  public class _1_10_JoinBlock_T1T2andMore
  {
    public void Run()
    {
      // The following basic example demonstrates a case in which 
      // a JoinBlock<T1,T2,T3> object requires multiple data to compute 
      // a value. This example creates a JoinBlock<T1,T2,T3> object 
      // that requires two Int32 values and a Char value to perform 
      // an arithmetic operation.

      // Create a JoinBlock<int, int, char> object that requires
      // two numbers and an operator.
      var joinBlock = new JoinBlock<int, int, char>();

      // Post two values to each target of the join.

      joinBlock.Target1.Post(3);
      joinBlock.Target1.Post(6);

      joinBlock.Target2.Post(5);
      joinBlock.Target2.Post(4);

      joinBlock.Target3.Post('+');
      joinBlock.Target3.Post('-');

      // Receive each group of values and apply the operator part
      // to the number parts.

      for (int i = 0; i < 2; i++)
      {
        var data = joinBlock.Receive();
        switch (data.Item3)
        {
          case '+':
            Console.WriteLine("{0} + {1} = {2}",
               data.Item1, data.Item2, data.Item1 + data.Item2);
            break;
          case '-':
            Console.WriteLine("{0} - {1} = {2}",
               data.Item1, data.Item2, data.Item1 - data.Item2);
            break;
          default:
            Console.WriteLine("Unknown operator '{0}'.", data.Item3);
            break;
        }
      }

      /* Output:
         3 + 5 = 8
         6 - 4 = 2
       */
    }
  }
}