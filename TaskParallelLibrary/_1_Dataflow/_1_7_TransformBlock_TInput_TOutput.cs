using System;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace TaskParallelLibrary._1_Dataflow
{
  public class _1_7_TransformBlock_TInput_TOutput
  {

    public void Run()
    {
      // Create a TransformBlock<int, double> object that 
      // computes the square root of its input.
      var transformBlock = new TransformBlock<int, double>(n => Math.Sqrt(n));

      // Post several messages to the block.
      transformBlock.Post(10);
      transformBlock.Post(20);
      transformBlock.Post(30);

      // Read the output messages from the block.
      for (int i = 0; i < 3; i++)
      {
        Console.WriteLine(transformBlock.Receive());
      }

      /* Output:
         3.16227766016838
         4.47213595499958
         5.47722557505166
       */
    }
  }


}