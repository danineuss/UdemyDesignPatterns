using System;
using static System.Console;

namespace Coding.Exercise
{
    public class Point
    {
        public int X, Y;

        public Point(int x, int y)
        {
            X = x;
            Y = y;
        }

        public Point(Point other)
        {
            X = other.X;
            Y = other.Y;
        }

        public override string ToString()
        {
            return $"(X: {X} Y: {Y})";
        }
    }

    public class Line
    {
        public Point Start, End;

        public Line(Point start, Point end)
        {
            Start = start;
            End = end;
        }

        public Line(Line other)
        {
            Start = new Point(other.Start);
            End = new Point(other.End);
        }

        public Line DeepCopy()
        {
            return new Line(this);
        }

        public override string ToString()
        {
            return $"Start: {Start} // End: {End}";
        }
    }

    public class Demo
    {
        public static void Main()
        {
            Line first = new Line(new Point(0, 0), new Point(1, 1));
            Line second = first.DeepCopy();
            second.End.Y = 7;

            WriteLine(first);
            WriteLine(second);
            ReadKey();
        }
    }
}
