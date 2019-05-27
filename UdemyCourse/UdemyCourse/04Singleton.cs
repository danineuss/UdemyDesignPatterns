using System;
using NUnit.Framework;

namespace Coding.Exercise
{
    public class SingletonTester
    {
        public static bool IsSingleton(Func<object> func)
        {
            var obj1 = func.Invoke();
            var obj2 = func.Invoke();
            bool test1 = obj1.Equals(obj2);
            bool test2 = ReferenceEquals(obj1, obj2);
            return test1 && test2;
        }
    }
}
