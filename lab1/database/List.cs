using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace database
{
    public class List
    {
        private Node First;
        private Node Current;
        private Node Last;
        public uint Size { get; set; }
        public List()
        {
            Size = 0;
            First = Current = Last = null;
        }
        public bool isEmpty()
        {
            if (Size == 0)
            {
                return true;
            }
            else return false;
        }
        public Node this[uint index]
        {
            set { this.insertSymbolByIndex(value, index); }
            get
            {
                if (index < 0 || index > Size + 1)
                {
                    throw new InvalidOperationException();
                }
                uint count = 0;
                Current = First;
                while (count < index)
                {
                    Current = Current.Next;
                    count++;
                }
                return Current;
            }
        }
        public void insertSymbolByIndex(Node obj, uint index)
        {
            if (index < 0 || index > Size)
            {
                throw new InvalidOperationException();
            }
            else if (index == 0)
            {
                if (isEmpty())
                {
                    First = obj;
                    Last = obj;
                    Size++;
                }
                else
                {
                    obj.Next = First;
                    First.Prev = obj;
                    First = obj;
                    Size++;
                }
            }
            else
            {
                uint count = 1;
                Current = First;
                while (count < index)
                {
                    Current = Current.Next;
                    count++;
                }
                if (Current.Next == null)
                {
                    Last.Next = obj;
                    obj.Prev = Last;
                    Last = obj;
                    Size++;
                }
                else
                {
                    Current.Prev.Next = obj;
                    obj.Next = Current;
                    obj.Prev = Current.Prev;
                    Current.Prev = obj;
                    Size++;
                }

            }
        }
        public void deleteSymbol(uint index)
        {
            if (index < 0 || index >= Size || this.isEmpty())
            {
                throw new InvalidOperationException();
            }
            else if (Size == 1 && index == 0)
            {
                Size = 0;
                First = Current = Last = null;
            }
            else if (index == Size - 1)
            {
                Current = Last.Prev;
                Current.Next = null;
                Last = Current;
                Size--;
            }
            else
            {
                if (index == 0)
                {
                    First = First.Next;
                    First.Prev = null;
                    Size--;
                }
                else
                {
                    uint count = 0;
                    Current = First;
                    while (count < index)
                    {
                        Current = Current.Next;
                        count++;
                    }

                    Current.Prev.Next = Current.Next;
                    Current.Next.Prev = Current.Prev;
                }
            }

        }
        public IEnumerator GetEnumerator()
        {
            Current = First;
            yield return Current;
            while (Current.Next != null)
            {
                Current = Current.Next;
                yield return Current;
            }
        }
        public void pushBack(Node node)
        {
            this.insertSymbolByIndex(node, this.Size);
        }
        
    }
}
