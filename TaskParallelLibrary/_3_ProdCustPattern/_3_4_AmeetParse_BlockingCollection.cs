using System;
using System.Collections.Concurrent;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace TaskParallelLibrary._3_ProdCustPattern
{
  // /// <summary>
  // /// Produces and Enqueues the Tasks
  // /// </summary>
  // public class TaskProducer
  // {
  //   private TaskQueue _taskQueue;

  //   public TaskProducer(TaskQueue taskQueue) { _taskQueue = taskQueue; }

  //   /// <summary>
  //   /// Produces the tasks.
  //   /// </summary>
  //   public void ProduceTasks()
  //   {
  //     Random random = new Random();
  //     for (int i = 1; i <= 5; i++)
  //     {
  //       // Prepare Queue Object (Hold the Test Data)
  //       var queue = new QueuedObject
  //       {
  //         QueueID = i,
  //         ProducerThreadID = Thread.CurrentThread.ManagedThreadId,
  //         EnqueueDateTime = DateTime.Now,
  //         // Used to Generate Random String
  //         RandomString = new string(Enumerable.Repeat("ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789", 5).Select(s => s[random.Next(s.Length)]).ToArray())
  //       };

  //       // Add Task to Queue with Action
  //       _taskQueue.EnqueueTask(() => { ReverseString(queue); });
  //       Console.WriteLine
  //           (
  //           "Enqueued: " + queue.QueueID +
  //           "\t" + "Producer ThreadID :" + queue.ProducerThreadID +
  //           "\t" + queue.EnqueueDateTime.ToLongTimeString() +
  //           "\t" + "RandomString   :" + queue.RandomString
  //           );
  //     }
  //   }

  //   /// <summary>
  //   /// Reverses the string. (This is an Associated Action with Task)
  //   /// </summary>
  //   /// <param name="queue">The queue.</param>
  //   public static void ReverseString(QueuedObject queue)
  //   {
  //     string reversedString = new string(Enumerable.Range(1, queue.RandomString.Length).Select(i => queue.RandomString[queue.RandomString.Length - i]).ToArray());
  //     Console.WriteLine
  //         (
  //         "Dequeued: " + queue.QueueID +
  //         "\t" + "Consumer ThreadID :" + Thread.CurrentThread.ManagedThreadId +
  //         "\t" + DateTime.Now.ToLongTimeString() +
  //         "\t" + "ReversedString :" + reversedString
  //         );

  //   }
  // }

  // public class TaskQueue
  // {
  //   private BlockingCollection<Task> _workTaskQueue;

  //   public delegate void TaskEventsHandler(TaskProcessingArguments e);

  //   public event TaskEventsHandler TaskStatus;

  //   public TaskQueue(IProducerConsumerCollection<Task> workTaskCollection, int QueueSize, int timeout)
  //   {
  //     _workTaskQueue = new BlockingCollection<Task>(workTaskCollection);
  //   }

  //   /// <summary>
  //   /// Enqueues the task.
  //   /// </summary>
  //   /// <param name="action">The action.</param>
  //   /// <param name="cancelToken">The cancel token.</param>
  //   public void EnqueueTask(Action action, CancellationToken cancelToken = default(CancellationToken))
  //   {
  //     var task = new Task(action, cancelToken);
  //     if (_workTaskQueue.TryAdd(task))
  //     {
  //       TaskStatus?.Invoke
  //           (new TaskProcessingArguments
  //           {
  //             ISTaskAdded = true,
  //             Message = "Task Added to Queue",
  //             PendingTaskCount = _workTaskQueue.Count,
  //           });
  //     }
  //     else
  //     {
  //       TaskStatus?.Invoke
  //           (new TaskProcessingArguments
  //           {
  //             ISTaskAdded = false,
  //             Message = "Timedout while adding Task to Queue",
  //             PendingTaskCount = _workTaskQueue.Count,
  //           });
  //     }
  //   }

  //   /// <summary>
  //   /// Dequeues the task.
  //   /// </summary>
  //   public void DequeueTask()
  //   {
  //     foreach (var task in _workTaskQueue.GetConsumingEnumerable())
  //       try
  //       {
  //         if (!task.IsCanceled) task.RunSynchronously();
  //         // if (!task.IsCanceled) task.Start();
  //       }
  //       catch (Exception ex)
  //       {

  //       }
  //   }

  //   /// <summary>
  //   /// CompleteAdding : Will notify Consumer / Queue - Task Addition from Producer is Completed
  //   /// </summary>
  //   public void Close()
  //   {
  //     _workTaskQueue.CompleteAdding();
  //   }
  // }

  // public class _3_4_AmeetParse_BlockingCollection
  // {

  //   public void Run()
  //   {
  //     // Initialize Task Queue and Specify Capacity and timeout
  //     TaskQueue taskQueue = new TaskQueue(new ConcurrentQueue<Task>(), 1000, 10);

  //     // Subscrive to Queue Processing Events
  //     taskQueue.TaskStatus += WorkQueue_TaskStatus;

  //     //Setup Producers - To Produce Tasks and Associated Action
  //     TaskProducer producerOne = new TaskProducer(taskQueue);
  //     TaskProducer producerTwo = new TaskProducer(taskQueue);

  //     //Start Producing Tasks (Here we have 2 Producers)
  //     Task producerTaskOne = Task.Run(() => producerOne.ProduceTasks());
  //     Task producerTaskTwo = Task.Run(() => producerTwo.ProduceTasks());

  //     //Start Consumers
  //     Task consumerTaskOne = Task.Run(() => taskQueue.DequeueTask());
  //     Task consumerTaskTwo = Task.Run(() => taskQueue.DequeueTask());

  //     //Wait for all Producers to Complete Producing Tasks
  //     Task.WaitAll(producerTaskOne, producerTaskTwo);

  //     //Call Queue Close Method (Indicate Producers have stopped producing tasks)
  //     taskQueue.Close();

  //     //Wait for Consumer to Process Tasks
  //     Task.WaitAll(consumerTaskOne, consumerTaskTwo);
  //     Console.WriteLine("Tasks Processed");
  //     Console.ReadLine();
  //   }

  //   // /// <summary>
  //   // /// Trigged when attempt is made to Add Task to Queue (Either Success or Timeout)
  //   // /// See TaskProcessingArguments
  //   // /// </summary>
  //   // /// <param name="e">The e.</param>
  //   public void WorkQueue_TaskStatus(TaskProcessingArguments e)
  //   {
  //     Console.WriteLine(e.ISTaskAdded);
  //   }

  // }
}


