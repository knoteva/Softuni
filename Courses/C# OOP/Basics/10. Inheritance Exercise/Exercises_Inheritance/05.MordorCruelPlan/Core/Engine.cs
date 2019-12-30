using _05.MordorCruelPlan.Factories;
using _05.MordorCruelPlan.Foods;
using _05.MordorCruelPlan.Moods;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _05.MordorCruelPlan.Core
{
    public class Engine
    {
        private FoodFactory foodFactory;
        private MoodFactory moodFactory;
        public Engine()
        {
            foodFactory = new FoodFactory();
            moodFactory = new MoodFactory();
        }

        public void Run()
        {
            int points = 0;
            var input = Console.ReadLine().Split(" ");

            for (int i = 0; i < input.Length; i++)
            {
                string type = input[i];
                Food currentFood = foodFactory.CreateFood(type);
                points += currentFood.Happiness;
            }
            Mood mood;
            if (points < -5)
            {
                mood = moodFactory.CreateMood("angry");
            }
            else if (points >= -5 && points <= 0)
            {
                mood = moodFactory.CreateMood("sad");
            }
            else if (points >= 1 && points <= 15)
            {
                mood = moodFactory.CreateMood("happy");
            }
            else
            {
                mood = moodFactory.CreateMood("javascript");
            }
            Console.WriteLine(points);
            Console.WriteLine(mood.Name);

        }

    }
}
