using System;
using System.Reactive.Disposables;
using System.Reactive.Subjects;
using Akka.IO;
using Common;

namespace v_1_2
{
    public class CtiTransformator : ISubject<ByteString, CtiEvent>
    {
        private ISubject<ByteString, string> byteBuffer;
        private ISubject<string, CtiEvent> parser;

        public CtiTransformator(ISubject<ByteString, string> byteBuffer, ISubject<string, CtiEvent> parser)
        {
            this.byteBuffer = byteBuffer;
            this.parser = parser;

            byteBuffer.Subscribe(parser);
        }

        public void OnNext(ByteString value)
        {
            byteBuffer.OnNext(value);
        }

        public void OnCompleted()
        {
            byteBuffer.OnCompleted();
        }

        public void OnError(Exception error)
        {
            byteBuffer.OnError(error);
        }

        public IDisposable Subscribe(IObserver<CtiEvent> observer)
        {
            parser.Subscribe(observer);
            return Disposable.Empty;
        }
    }
}
