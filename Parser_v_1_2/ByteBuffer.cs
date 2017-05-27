using System;
using System.Reactive.Disposables;
using System.Reactive.Subjects;
using Akka.IO;
using v_1_2.Protocol;

namespace v_1_2
{
    public class ByteBuffer : ISubject<ByteString, string>
    {
        private IObserver<string> observer;
        private string buffer;

        public void OnNext(ByteString value)
        {
            try
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
            catch (Exception error)
            {
                observer.OnError(error);
                ResetBuffer();
            }
        }

        public void OnCompleted()
        {
            observer.OnCompleted();
            ResetBuffer();
        }

        public void OnError(Exception error)
        {
            observer.OnError(error);
        }

        public IDisposable Subscribe(IObserver<string> observer)
        {
            this.observer = observer;
            return Disposable.Empty;
        }

        private int FindDelimiter()
        {
            try
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
            catch (Exception error)
            {
                observer.OnError(error);
                ResetBuffer();
                return -1;
            }
        }

        private void DropBuffer(int count)
        {
            try
            {
                string cleanUpBuffer = buffer.Remove(0, count);
                buffer = cleanUpBuffer;
            }
            catch (Exception error)
            {
                observer.OnError(error);
                ResetBuffer();
            }
        }

        private void ResetBuffer()
        {
            buffer = string.Empty;
        }
    }
}
