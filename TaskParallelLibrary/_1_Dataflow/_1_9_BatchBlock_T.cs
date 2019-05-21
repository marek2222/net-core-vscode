using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace TaskParallelLibrary._1_Dataflow
{
  public class _1_9_BatchBlock_T
  {
    public void Run()
    {
      // The following basic example posts several Int32 values 
      // to a BatchBlock<T> object that holds ten elements in a batch. 
      // To guarantee that all values propagate out of the BatchBlock<T>, 
      // this example calls the Complete method. The Complete method sets 
      // the BatchBlock<T> object to the completed state, and therefore, 
      // the BatchBlock<T> object propagates out any remaining elements
      // as a final batch.

      // Create a BatchBlock<int> object that holds ten
      // elements per batch.
      var batchBlock = new BatchBlock<int>(10);

      // Post several values to the block.
      for (int i = 0; i < 13; i++)
      {
        batchBlock.Post(i);
      }
      // Set the block to the completed state. This causes
      // the block to propagate out any any remaining
      // values as a final batch.
      batchBlock.Complete();

      // Print the sum of both batches.
      Console.WriteLine("The sum of the elements in batch 1 is {0}.",
         batchBlock.Receive().Sum());

      Console.WriteLine("The sum of the elements in batch 2 is {0}.",
         batchBlock.Receive().Sum());

      /* Output:
         Suma 1-9
         The sum of the elements in batch 1 is 45.
         
         Suma 10-12
         The sum of the elements in batch 2 is 33.
       */
    }
  }
}