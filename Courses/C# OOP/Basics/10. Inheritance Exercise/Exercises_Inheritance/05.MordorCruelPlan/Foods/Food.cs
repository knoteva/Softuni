using System;
using System.Collections.Generic;
using System.Text;

namespace _05.MordorCruelPlan.Foods
{
    public abstract class Food
    {
        protected Food(int happiness)
        {
            Happiness = happiness;
        }

        public int Happiness { get; }
    }
}
