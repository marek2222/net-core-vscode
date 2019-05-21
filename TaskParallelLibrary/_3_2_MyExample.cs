using System;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace TaskParallelLibrary
{
  public class _3_2_MyExample
  {
    // Demonstrates the production end of the producer and consumer pattern.
   static void Produce(ITargetBlock<int> target)
   {
      // In a loop, fill a buffer with random data and
      // post the buffer to the target block.
      for (int i = 0; i < 10; i++)
      {
         // Post the result to the message block.
         target.Post(i);
      }

      // Set the target to the completed state to signal to the consumer
      // that no more data will be available.
      target.Complete();
   }

   // Demonstrates the consumption end of the producer and consumer pattern.
   static async Task<int> ConsumeAsync(ISourceBlock<int> source)
   {
      // Initialize a counter to track the number of bytes that are processed.
      int intProcessed = 0;

      // Read from the source buffer until the source buffer has no 
      // available output data.
      while (await source.OutputAvailableAsync())
      {
         int data = source.Receive();

         // Increment the sum of int received.
         intProcessed += data;
      }
      return intProcessed;
   }

    public void Run()
    {
      // Create a BufferBlock<byte[]> object. This object serves as the 
      // target block for the producer and the source block for the consumer.
      var buffer = new BufferBlock<int>();

      // Start the consumer. The Consume method runs asynchronously. 
      var consumer = ConsumeAsync(buffer);

      // Post source data to the dataflow block.
      Produce(buffer);

      // Wait for the consumer to process all data.
      consumer.Wait();

      // Print the sum of int processed to the console.
      Console.WriteLine("Processed {0} int count.", consumer.Result);
    }
    /* Output:
      Processed 45 count.
    */

  }
}