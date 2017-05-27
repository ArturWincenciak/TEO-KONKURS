using System;

namespace v_4_0
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

        public byte[] Get(int len)
        {
            byte[] result = new byte[len];
            if (head + len < buffer.Length)
            {
                Array.Copy(buffer, head, result, 0, len);
            }
            else
            {
                int endLen = buffer.Length - head;
                int remainingLen = len - endLen;

                Array.Copy(buffer, head, result, 0, endLen);
                Array.Copy(buffer, 0, result, endLen, remainingLen);
            }

            return result;
        }

        public byte[] Get(int start, int len)
        {
            byte[] result = new byte[len];
            if (head + len + start < buffer.Length)
            {
                if (head + start < buffer.Length)
                {
                    Array.Copy(buffer, head + start, result, 0, len);
                }
                else
                {
                    int startIdx = (head + start) - buffer.Length;
                    Array.Copy(buffer, startIdx, result, 0, len);
                }

                return result;
            }
            else
            {
                if (head + start < buffer.Length)
                {
                    int endLen = buffer.Length - (head + start);
                    int remainingLen = len - endLen;

                    Array.Copy(buffer, head + start, result, 0, endLen);
                    Array.Copy(buffer, 0, result, endLen, remainingLen);
                }
                else
                {
                    int startIdx = (head + start) - buffer.Length;
                    Array.Copy(buffer, startIdx, result, 0, len);
                }

                return result;
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
