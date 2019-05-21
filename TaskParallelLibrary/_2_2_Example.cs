using System;
using System.Threading.Tasks.Dataflow;

namespace TaskParallelLibrary
{
  public class _2_2_Example
  {
    public void Run()
    {
      var bufferBlock = new BufferBlock<int>();
      // Post more messages to the block.
      for (int i = 0; i < 3; i++)
      {
        bufferBlock.Post(i);
      }

      // Receive the messages back from the block.
      int value;
      while (bufferBlock.TryReceive(out value))
      {
        Console.WriteLine(value);
      }

      /* Output:
         0
         1
         2
       */
    }
  }
}