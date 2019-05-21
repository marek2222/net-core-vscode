using System;
using System.Threading.Tasks.Dataflow;

namespace TaskParallelLibrary._1_Dataflow
{
  public class _1_4_BroadcastBlock
  {
    public void Run()
    {
      // Create a BroadcastBlock<double> object.
      var broadcastBlock = new BroadcastBlock<double>(null);

      // Post a message to the block.
      broadcastBlock.Post(Math.PI);

      // Receive the messages back from the block several times.
      for (int i = 0; i < 3; i++)
      {
        Console.WriteLine(broadcastBlock.Receive());
      }

      /* Output:
         3.14159265358979
         3.14159265358979
         3.14159265358979
       */
    }
  }
}