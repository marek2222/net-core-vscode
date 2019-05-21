using System;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace TaskParallelLibrary
{
  public class _2_3_Example
  {
    public void Run()
    {
      // Create a BufferBlock<int> object.
      var bufferBlock = new BufferBlock<int>();

      // Write to and read from the message block concurrently.
      var post01 = Task.Run(() =>
         {
           bufferBlock.Post(0);
           bufferBlock.Post(1);
         });
      var receive = Task.Run(() =>
         {
           for (int i = 0; i < 3; i++)
           {
             Console.WriteLine(bufferBlock.Receive());
           }
         });
      var post2 = Task.Run(() =>
         {
           bufferBlock.Post(2);
         });
      Task.WaitAll(post01, receive, post2);

      /* Sample output:
         2
         0
         1
       */
    }
  }
}