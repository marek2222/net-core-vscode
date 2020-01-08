using System;
using System.Threading;

namespace TH_2.thread_api
{
  internal class APM
  {

    int GetResult(int input) => input *2;
    
    static int _current;

    #region Method Pair
    static IAsyncResult BeginAsync(int input, out int result, AsyncCallback callback, object state) 
    {
      result = input;
      _current = input *2;
      if (callback != null)
          callback.Invoke(new MyAsyncResult(state));
      return null;
    }

    static int EndAsync(out int result, IAsyncResult var) 
    {
      result = _current;
      return _current;
    }
    #endregion

    #region Callback and Completion
    public static void DemonstratePooling()
    {
      IAsyncResult iar = BeginAsync(42, out int result, null,null);
      var timer = new Timer((cb)=> 
      {
        System.Console.WriteLine("check timer...");
        if (iar.IsCompleted)
        {
          try
          {
              int output = EndAsync(out result, iar);
              System.Console.WriteLine(output);
          }
          catch (System.Exception)
          {
              throw;
          }
        }
      },
      new object(), TimeSpan.FromSeconds(1), TimeSpan.FromMilliseconds(5));
      System.Console.WriteLine("ran");
    }

    public void DemonstrateNotification()
      => BeginAsync(22, out int result, new AsyncCallback(Callback), "myState");
    

    private void Callback(IAsyncResult iar)
    {
      // do something here
      try
      {
          int result = EndAsync(out int output, iar);
          System.Console.WriteLine(result);
          System.Console.WriteLine(iar.AsyncState.ToString());
      }
      catch (System.Exception)
      {
      }
    }
    #endregion
  }

  public class MyAsyncResult : IAsyncResult
  {
    private readonly object _state;

    public MyAsyncResult(object state)
    {
      this._state = state;
    }

    public bool IsCompleted { get { return true; }} 
    public WaitHandle AsyncWaitHandle => throw new NotImplementedException();


    public object AsyncState => throw new NotImplementedException();

    public bool CompletedSynchronously => throw new NotImplementedException();
  }
}