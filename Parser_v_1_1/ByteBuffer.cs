using System;
using System.Reactive.Disposables;
using System.Reactive.Subjects;
using Akka.IO;
using v_1_1.Protocol;

namespace v_1_1
{
    public class ByteBuffer : ISubject<ByteString, string>
    {
        private IObserver<string> observer;
        private string buffer;

        public void OnNext(ByteString value)
        {
            buffer += value.DecodeString();

            int delimiterIndex;
            while (true)
            {
                delimiterIndex = FindDelimiter();
                if (delimiterIndex != -1)
                {
                    observer.OnNext(buffer);
                    DropBuffer(delimiterIndex + 4);
                }
                else
                {
                    break;
                }
            }
        }

        public void OnCompleted()
        {
            DropBuffer(buffer.Length);
            observer.OnCompleted();
        }

        public void OnError(Exception error)
        {
            DropBuffer(buffer.Length);
            observer.OnError(error);
        }

        public IDisposable Subscribe(IObserver<string> observer)
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
                    case Asci.CR:
                    {
                        if (buffer[i + 2] == Asci.CR && bufferLength > i + 3)
                        {
                            return i;
                        }
                        if (buffer[i - 2] == Asci.CR && bufferLength > i + 1)
                        {
                            return i - 2;
                        }
                        break;
                    }
                    case Asci.LF:
                    {
                        if (buffer[i + 2] == Asci.LF)
                        {
                            return i - 1;
                        }
                        if (buffer[i - 2] == Asci.LF)
                        {
                            return i - 3;
                        }
                        break;
                    }
                }
            }

            return -1;
        }

        private void DropBuffer(int count)
        {
            string cleanUpBuffer = buffer.Remove(0, count);
            buffer = cleanUpBuffer;
        }
    }
}
