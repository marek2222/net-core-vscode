using System;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace TaskParallelLibrary._2_WriteRead
{
  public class _2_5_Asynch
  {
    // Demonstrates asynchronous dataflow operations.
    public async Task AsyncSendReceive(BufferBlock<int> bufferBlock)
    {
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
    }
    public void Run()
    {
      // Create a BufferBlock<int> object.
      var bufferBlock = new BufferBlock<int>();

      // Demonstrate asynchronous dataflow operations.
      AsyncSendReceive(bufferBlock).Wait();

      /* Output:
         0
         1
         2
       */
    }
  }
}