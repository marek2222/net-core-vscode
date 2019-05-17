using System;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace TaskParallelLibrary
{
  public class _1_6_ActionBlock
  {
    
    public void Run()
    {
      // The following basic example posts multiple Int32 values 
      // to an ActionBlock<TInput> object. The ActionBlock<TInput> object 
      // prints those values to the console. This example then sets 
      // the block to the completed state and waits for all dataflow 
      // tasks to finish.

      // Create an ActionBlock<int> object that prints values
      // to the console.
      var actionBlock = new ActionBlock<int>(n => Console.WriteLine(n));

      // Post several messages to the block.
      for (int i = 0; i < 3; i++)
      {
        actionBlock.Post(i * 10);
        //Thread.Sleep(1000);
        //Task.Delay(1000);
      }

      // Set the block to the completed state and wait for all  tasks to finish.
      actionBlock.Complete();
      actionBlock.Completion.Wait();

      /* Output:
         0
         10
         20
       */
    }
  }


}