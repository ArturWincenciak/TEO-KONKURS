using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace v_4_2
{
    public class CycleByteBuffer
    {
        private readonly byte[] buffer;

        private int head = 0;
        private int tail = 0;

        public CycleByteBuffer(int bufferSize)
        {
            head = 0;
            tail = 0;
            buffer = new byte[bufferSize];
        }

        public byte this[int index]
        {
            get
            {
                return buffer[(head + index) % buffer.Length];
            }
        }

        public int Length
        {
            get
            {
                if (tail > head)
                    return tail - head;

                if (tail < head)
                    return (buffer.Length - head) + tail;

                return 0;
            }
        }

        public void Append(byte[] data)
        {
            if (tail + data.Length >= buffer.Length)
            {
                int endLen = buffer.Length - tail;
                int remainingLen = data.Length - endLen;

                Array.Copy(data, 0, buffer, tail, endLen);
                Array.Copy(data, endLen, buffer, 0, remainingLen);

                tail = remainingLen;
            }
            else
            {
                Array.Copy(data, 0, buffer, tail, data.Length);
                tail += data.Length;
            }
        }

        public string ToString(int len)
        {
            if (head + len < buffer.Length)
            {
                return Encoding.ASCII.GetString(buffer, 0, len);
            }
            else
            {
                int endLen = buffer.Length - head;
                int remainingLen = len - endLen;

                return Encoding.ASCII.GetString(buffer, head, endLen) 
                    + Encoding.ASCII.GetString(buffer, 0, remainingLen);
            }
        }

        public string ToString(int start, int len)
        {
            if (head + len + start < buffer.Length)
            {
                if (head + start < buffer.Length)
                {
                    return Encoding.ASCII.GetString(buffer, head + start, len);
                }
                else
                {
                    int startIdx = (head + start) - buffer.Length;
                    return Encoding.ASCII.GetString(buffer, startIdx, len);
                }
            }
            else
            {
                if (head + start < buffer.Length)
                {
                    int endLen = buffer.Length - (head + start);
                    int remainingLen = len - endLen;

                    return Encoding.ASCII.GetString(buffer, head, endLen)
                        + Encoding.ASCII.GetString(buffer, 0, remainingLen);
                }
                else
                {
                    int startIdx = (head + start) - buffer.Length;
                    return Encoding.ASCII.GetString(buffer, startIdx, len);
                }
            }
        }

        public void Clear(int len)
        {
            if (head + len < buffer.Length)
            {
                head += len;
            }
            else
            {
                int endLen = buffer.Length - head;
                int remainingLen = len - endLen;
                head = remainingLen;
            }
        }

        public void Clear()
        {
            head = 0;
            tail = 0;
        }
    }
}
