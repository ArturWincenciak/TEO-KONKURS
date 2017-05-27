using System;
using System.Reactive.Disposables;
using System.Reactive.Subjects;
using Akka.IO;
using Common;

namespace v_0_12
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
                    CtiEvent outputEvent = eventParser.Parse(buffer);
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
            int bufferLength = buffer.Length;
            for (int i = 0; i < bufferLength - 2; i += 4)
            {
                switch ((byte)buffer[i])
                {
                    case CtiProtocol.CARRIAGE_RETURN:
                        {
                            if (buffer[i + CtiProtocol.SHIFT_FOR_DELIMITER] == CtiProtocol.CARRIAGE_RETURN && bufferLength > i + 3)
                            {
                                return i;
                            }
                            if (buffer[i - CtiProtocol.SHIFT_FOR_DELIMITER] == CtiProtocol.CARRIAGE_RETURN && bufferLength > i + 3)
                            {
                                return i - 2;
                            }
                            break;
                        }
                    case CtiProtocol.LINE_FEED:
                        {
                            if (buffer[i + CtiProtocol.SHIFT_FOR_DELIMITER] == CtiProtocol.LINE_FEED)
                            {
                                return i - 1;
                            }
                            if (buffer[i - CtiProtocol.SHIFT_FOR_DELIMITER] == CtiProtocol.LINE_FEED)
                            {
                                return i - 3;
                            }
                            break;
                        }
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
