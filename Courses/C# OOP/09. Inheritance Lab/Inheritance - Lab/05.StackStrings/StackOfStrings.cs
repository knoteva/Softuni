using System;
using System.Collections.Generic;
using System.Text;

namespace CustomStack
{
    public class StackOfStrings
    {

        private List<string> data = new List<string>();

        public bool IsEmpty()
        {
            return this.data.Count == 0;
        }

        public void Push(string item)
        {
            data.Add(item);
        }

        public string Peek()
        {
            string result = null;
            if (!IsEmpty())
            {
                int index = this.data.Count - 1;
                result = this.data[index];
            }
            return result;
        }

        public string Pop()
        {
            string result = null;
            if (!IsEmpty())
            {
                int index = this.data.Count - 1;
                result = this.data[index];
                this.data.RemoveAt(index);
            }
            return result;
        }
    }
}
