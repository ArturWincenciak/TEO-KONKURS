using System;
using System.Reactive.Disposables;
using System.Reactive.Subjects;
using Akka.IO;
using Common;

namespace v_0_6
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
                int delimiterIdx = FindDelimiter();
                if (delimiterIdx != -1)
                {
                    string inputEvent = buffer.Substring(0, delimiterIdx + 2);
                    CtiEvent outputEvent = eventParser.Parse(inputEvent);
                    observer.OnNext(outputEvent);
                    CleanUpBuffer(delimiterIdx + 4);
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

        private int FindDelimiter()
        {
            for (int i = 0; i < buffer.Length - 3; i++)
            {
                if (buffer[i] == CtiProtocol.CARRIAGE_RETURN &&
                    buffer[i + 1] == CtiProtocol.LINE_FEED &&
                    buffer[i + 2] == CtiProtocol.CARRIAGE_RETURN &&
                    buffer[i + 3] == CtiProtocol.LINE_FEED)
                {
                    return i;
                }
            }

            return -1;
        }

        private void CleanUpBuffer(int indexToCleanUp)
        {
            string cleanUpBuffer = buffer.Remove(0, indexToCleanUp);
            buffer = cleanUpBuffer;
        }
    }
}
