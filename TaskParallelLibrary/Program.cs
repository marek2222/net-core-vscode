using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace TaskParallelLibrary
{
  class Program
  {
    public static void linia(string value = "")    {      System.Console.WriteLine(value);    }

    static void Main(string[] args)
    {

      // Dataflow (Task Parallel Library)"
      // https://docs.microsoft.com/pl-pl/dotnet/standard/parallel-programming/dataflow-task-parallel-library#predefined-dataflow-block-types
      // _1_Dataflow();

      // How to: Implement a Producer-Consumer Dataflow Pattern
      // https://docs.microsoft.com/pl-pl/dotnet/standard/parallel-programming/how-to-implement-a-producer-consumer-dataflow-pattern
      _3_Producer_Consumer();

    }

    private static void _3_Producer_Consumer()
    {
      linia();
      linia();
      linia("How to: Implement a Producer-Consumer Dataflow Pattern");
      linia("https://docs.microsoft.com/pl-pl/dotnet/standard/parallel-programming/how-to-implement-a-producer-consumer-dataflow-pattern");
      linia();

      _3_1_Example _3_1 = new _3_1_Example();
      _3_1.Run();
      linia("-----------------------------------");

      _3_2_MyExample _3_2 = new _3_2_MyExample();
      _3_2.Run();
      linia("-----------------------------------");

    }



    private static void _1_Dataflow()
    {

      linia("Dataflow (Task Parallel Library)");
      linia("https://docs.microsoft.com/pl-pl/dotnet/standard/parallel-programming/dataflow-task-parallel-library#predefined-dataflow-block-types");
      linia();

      // Istnieją dwa sposoby ustalić, czy bloku przepływu danych zostało ukończone bez błędów, 
      // napotkała co najmniej jeden błąd lub zostało anulowane. Pierwszy sposób polega na wywołaniu metody Task.Wait  
      // na ukończenie zadania w try - catch bloku (Try - Catch w języku Visual Basic). 

      // Poniższy przykład tworzy ActionBlock<TInput> obiekt, który zgłasza ArgumentOutOfRangeException 
      // jeśli jego wartość wejściowa jest mniejsza niż zero. AggregateException jest zgłaszany, 
      // gdy ten przykład wywołuje Wait do ukończenia zadania. ArgumentOutOfRangeException Odbywa się 
      // za pośrednictwem InnerExceptions właściwość AggregateException obiektu.
      _1_1_ActionBlock a1 = new _1_1_ActionBlock();
      a1.Run();
      linia("-----------------------------------");

      //Drugim sposobem ustalenia stanu ukończenia bloku przepływu danych jest celu to kontynuacja ukończenia zadania 
      // lub używać asynchronicznych funkcji języka C# i Visual Basic asynchronicznego oczekiwania na ukończenie zadania.
      //  Delegat, który możesz udostępnić Task.ContinueWith metoda przyjmuje Task obiekt, który reprezentuje zadania 
      // poprzedzającego. W przypadku właściwości Completion właściwości delegata kontynuacji pobiera samo zadanie ukończenia. 
      // Poniższy przykład przypomina poprzedni, z tą różnicą, że użyto także ContinueWith metodę, aby utworzyć zadanie 
      // kontynuacji, który wyświetla stan ogólnej operacji przepływu danych.
      _1_2_ActionBlock a2 = new _1_2_ActionBlock();
      a2.Run();
      linia("-------------------------------------------");

      linia();
      linia("_1_3_BufferBlock");
      _1_3_BufferBlock a3 = new _1_3_BufferBlock();
      a3.Run();
      linia("-------------------------------------------");

      _1_4_BroadcastBlock a4 = new _1_4_BroadcastBlock();
      a4.Run();
      linia("-------------------------------------------");

      // Do zwracania jednego ostatecznego komunikatu
      _1_5_WriteOnceBlock a5 = new _1_5_WriteOnceBlock();
      a5.Run();
      linia("-------------------------------------------");


      // Execution Blocks
      // ----------------------------------------------

      // Execution blocks call a user-provided delegate for each piece of received data. 
      // The TPL Dataflow Library provides three execution block types: 
      // -- ActionBlock<TInput>, 
      // -- System.Threading.Tasks.Dataflow.TransformBlock<TInput,TOutput>
      // -- System.Threading.Tasks.Dataflow.TransformManyBlock<TInput,TOutput>


      // The following basic example posts multiple Int32 values to an ActionBlock<TInput> object. 
      // The ActionBlock<TInput> object prints those values to the console. This example then sets 
      // the block to the completed state and waits for all dataflow tasks to finish.
      linia("ActionBlock<TInput>");
      _1_6_ActionBlock a6 = new _1_6_ActionBlock();
      a6.Run();
      linia("-------------------------------------------");


      linia("System.Threading.Tasks.Dataflow.TransformBlock<TInput,TOutput>");
      _1_7_TransformBlock_TInput_TOutput a7 = new _1_7_TransformBlock_TInput_TOutput();
      a7.Run();
      linia("-------------------------------------------");


      linia("System.Threading.Tasks.Dataflow.TransformManyBlock<TInput,TOutput>");
      _1_8_TransformManyBlock_TInput_TOutput a8 = new _1_8_TransformManyBlock_TInput_TOutput();
      a8.Run();
      linia("-------------------------------------------");


      linia("-------------------------------------------");
      linia("-------------------------------------------");
      linia("Grouping Blocks");
      linia();

      // Grouping blocks combine data from one or more sources and under various constraints. 
      // The TPL Dataflow Library provides three join block types: 
      // -- BatchBlock<T>, 
      // -- JoinBlock<T1,T2> 
      // -- BatchedJoinBlock<T1,T2>

      linia("BatchBlock<T>");
      _1_9_BatchBlock_T a9 = new _1_9_BatchBlock_T();
      a9.Run();
      linia("-------------------------------------------");

      // -- JoinBlock<T1,T2> 
      linia("JoinBlock<T1,T2,...>");
      _1_10_JoinBlock_T1T2andMore a10 = new _1_10_JoinBlock_T1T2andMore();
      a10.Run();
      linia("-------------------------------------------");

      // -- BatchedJoinBlock<T1,T2,...>
      linia("BatchedJoinBlock<T1,T2,...>");
      _1_11_BatchedJoinBlock_T1T2andMore a11 = new _1_11_BatchedJoinBlock_T1T2andMore();
      a10.Run();
      linia("-------------------------------------------");
    }
  }
}
