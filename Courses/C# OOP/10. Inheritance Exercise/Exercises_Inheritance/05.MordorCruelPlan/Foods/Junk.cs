using System;
using System.Collections.Generic;
using System.Text;

namespace _05.MordorCruelPlan.Foods
{
    public class Junk : Food
    {
        private const int happiness = -1;
        public Junk()
            : base(happiness)
        {
        }
    }
}
