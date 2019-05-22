using System;
using System.Threading.Tasks;
using System.Threading.Tasks.Dataflow;

namespace TaskParallelLibrary._3_ProdCustPattern
{
  public class _3_3_MoreCustomers
  {

    // Napisz program, w którym dwa procesy–producenci produkują asynchronicznie 
    //  dwie zmienne co w przybliżeniu taki sam okres. Proces konsument ma przeczytać
    //  obie zmienne po tym jak obie się zmienią.
    // Proces producent nie może wytworzyć nowej zmiennej dopóki konsument jej nie przeczyta.

    public void Producent(ITargetBlock<int> target)
    {
      for (int i = 0; i < 10; i++)
      {
        target.Post(i);
      }
      target.Complete();
    }

    public async Task<int> KonsumpcjaAsynchronicznie(IReceivableSourceBlock<int> zrodlo)
    {
      int przetworzoneBloki = 0;

      // Czytaj z bufora źródłowego, aż bufor źródłowy nie będzie miał dostępnych danych wyjściowych
      while (await zrodlo.OutputAvailableAsync())
      {
        int dane;
        while (zrodlo.TryReceive(out dane))
        {
          przetworzoneBloki += dane;    // Przetwórz bloki.
        }
      }
      return przetworzoneBloki;
    }

    public void Run()
    {
      // Utwórz obiekt BufferBlock <int> jako blok docelowy dla producenta i blok źródłowy dla konsumenta.
      var buffer = new BufferBlock<int>();
      var konsument = KonsumpcjaAsynchronicznie(buffer);

      Producent(buffer);

      konsument.Wait();

      // Print the sum of int processed to the console.
      Console.WriteLine("Dla wielu konsumentów po przetworzeniu otrzymano liczbę: {0}.", konsument.Result);
    }
    /* Output:
      Otrzymano po przetworzeniu liczbę: 45.
    */

  }
}