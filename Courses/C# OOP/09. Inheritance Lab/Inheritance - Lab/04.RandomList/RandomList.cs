using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CustomRandomList
{
    public class RandomList : List<string>
    {
        private Random random = new Random();

        public string RandomString()
        {
            string result = null;
            if (this.Count != 0)
            {
                int index = random.Next(0, this.Count - 1);
                result = this[index];
                this.RemoveAt(index);
            }
            return result;
        }

    }
}
