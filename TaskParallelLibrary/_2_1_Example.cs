using System;
using System.Threading.Tasks.Dataflow;

namespace TaskParallelLibrary
{
  public class _2_1_Example
  {

    public void Run()
    {
      // Create a BufferBlock<int> object.
      var bufferBlock = new BufferBlock<int>();

      // Post several messages to the block.
      for (int i = 0; i < 3; i++)
      {
        bufferBlock.Post(i);
      }

      // Receive the messages back from the block.
      for (int i = 0; i < 3; i++)
      {
        Console.WriteLine(bufferBlock.Receive());
      }

      /* Output:
         0
         1
         2
       */
    }
  }
}