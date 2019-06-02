using System;

namespace Coding.Exercise
{
    public class Bird
    {
        public int Age { get; set; }

        public string Fly()
        {
            return (Age < 10) ? "flying" : "too old";
        }
    }

    public class Lizard
    {
        public int Age { get; set; }

        public string Crawl()
        {
            return (Age > 1) ? "crawling" : "too young";
        }
    }

    public class Dragon // no need for interfaces
    {
        private Bird bird = new Bird();
        private Lizard lizard = new Lizard();
        private int age;
        public int Age
        {
            get => age;
            set
            {
                age = value;
                bird.Age = value;
                lizard.Age = value;
            }
        }

        public Dragon(int age)
        {
            Age = age;
        }

        public string Fly()
        {
            return bird.Fly();
        }

        public string Crawl()
        {
            return lizard.Crawl();
        }
    }

    public class Demo
    {
        public static void Main()
        {
            Dragon ancient = new Dragon(250);
            Dragon infant = new Dragon(0);
            Dragon warrior = new Dragon(7);

            Console.WriteLine($"The {nameof(ancient)} is {ancient.Fly()} and {ancient.Crawl()}");
            Console.WriteLine($"The {nameof(infant)} is {infant.Fly()} and {infant.Crawl()}");
            Console.WriteLine($"The {nameof(warrior)} is {warrior.Fly()} and {warrior.Crawl()}");
        }
    }
}
