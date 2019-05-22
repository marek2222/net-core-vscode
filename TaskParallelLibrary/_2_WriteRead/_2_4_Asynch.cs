using System;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace TaskParallelLibrary._2_WriteRead
{
  public class _2_4_Asynch
  {
    public async Task RunAsync()
    {
      // Create a BufferBlock<int> object.
      var bufferBlock = new BufferBlock<int>();

      // Post more messages to the block asynchronously.
      for (int i = 0; i < 3; i++)
      {
        await bufferBlock.SendAsync(i);
      }

      // Asynchronously receive the messages back from the block.
      for (int i = 0; i < 3; i++)
      {
        Console.WriteLine(await bufferBlock.ReceiveAsync());
      }

      /* Output:
         0
         1
         2
       */
    }
  }
}