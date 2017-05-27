using System;
using System.Reactive.Disposables;
using System.Reactive.Subjects;
using Akka.IO;
using Common;

namespace v_0_1
{
    public class CtiTransformator : ISubject<ByteString, CtiEvent>
    {
        private string buffer = string.Empty;
        
        private readonly ICtiParser eventParser;
        private IObserver<CtiEvent> observer;

        public CtiTransformator(ICtiParser eventParser)
        {
            this.eventParser = eventParser;
        }

        public void OnNext(ByteString value)
        {
            buffer += value.DecodeString();

            while (true)
            {
                int lastIndex;
                if (TryGetLastIndexOfEvent(out lastIndex))
                {
                    string inputEvent = buffer.Substring(0, lastIndex);
                    CtiEvent outputEvent = eventParser.Parse(inputEvent);
                    observer.OnNext(outputEvent);
                    CleanUpBuffer(lastIndex);
                }
                else
                {
                    break;
                }
            }
        }

        public void OnError(Exception error)
        {
            CleanUpBuffer(buffer.Length);
            observer.OnError(error);
        }

        public void OnCompleted()
        {
            CleanUpBuffer(buffer.Length);
            observer.OnCompleted();
        }

        public IDisposable Subscribe(IObserver<CtiEvent> observer)
        {
            this.observer = observer;
            return Disposable.Empty;
        }

        private bool TryGetLastIndexOfEvent(out int endOfEventIndex)
        {
            endOfEventIndex = buffer.IndexOf(CtiProtocol.DELIMITER, StringComparison.Ordinal);
            if (endOfEventIndex == -1)
            {
                return false;
            }

            endOfEventIndex += CtiProtocol.DELIMITER.Length;
            return true;
        }

        private void CleanUpBuffer(int indexToCleanUp)
        {
            string cleanUpBuffer = buffer.Remove(0, indexToCleanUp);
            buffer = cleanUpBuffer;
        }
    }
}
