using System;
using System.Reactive.Disposables;
using System.Reactive.Subjects;
using Akka.IO;
using Common;
using System.Text;

namespace v_3_0
{
    public class CtiTransformator : ISubject<ByteString, CtiEvent>
    {
        private ISubject<ByteString, StringBuilder> byteBuffer;
        private ISubject<StringBuilder, CtiEvent> parser;

        public CtiTransformator(ISubject<ByteString, StringBuilder> byteBuffer, ISubject<StringBuilder, CtiEvent> parser)
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
