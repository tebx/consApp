using System;
using System.Collections.Generic;

namespace ConsoleApplication1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            ISummat iSummatA = new A(); // pretend that this comes from the IoC
            ISummat iSummatB = new B();  // pretend that this comes from the IoC

            var a = Factory.GetInstance(iSummatA.GetType());

            a.DoSummat();

            var b = Factory.GetInstance(iSummatB.GetType());

            b.DoSummat();

            Console.ReadLine();

            // irrelevant comment, used to demonstrate Git
            // a 2nd irrelevant comment, used to demonstrate Git's checkout command
            // just got the remote repo working properly
        }
    }

    public class Factory
    {
        private static readonly Dictionary<Type, Func<ISummat>> _dictionary;

        static Factory()
        {
            _dictionary = new Dictionary<Type, Func<ISummat>>
            {
                {typeof(A), () => new A()},
                {typeof(B), () => new B()}
            };
        }

        public static ISummat GetInstance(Type type)
        {
            return _dictionary[type].Invoke();
        }
    }

    public interface ISummat
    {
        void DoSummat();
    }

    public class A : ISummat

    {
        public void DoSummat()
        {
            Console.WriteLine("doing summat in A");
        }
    }

    public class B : ISummat
    {
        public void DoSummat()
        {
            Console.WriteLine("Doing summat in B");
        }
    }
}
