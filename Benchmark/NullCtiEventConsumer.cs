using System;
using Common;

namespace BenchmarkTeoVincent
{
    public class NullCtiEventConsumer : IObserver<CtiEvent>
    {
        public void OnCompleted()
        {

        }

        public void OnError(Exception error)
        {

        }

        public void OnNext(CtiEvent value)
        {

        }
    }
}
