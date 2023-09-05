using System.Security.Cryptography.X509Certificates;

namespace Delegates
{
    public class Program
    {
        public delegate void MyDelegate(int x, int y);
        static void Main(string[] args)
        {
            //Unicast deligate

            MyDelegate del1 = new MyDelegate(Add);
            del1(8, 5);

            MyDelegate del2 = new MyDelegate(Multiply);
            del2(8, 5);

            MyDelegate del3 = new MyDelegate(Multiply);
            del3(8, 5);

            Console.WriteLine();


            ActionDelegate();
            PredicateDelegate();
            FuncDelegate();
            Multicast();

        }
        public static void ActionDelegate()
        {
            Console.WriteLine();
            Console.WriteLine("Action Delegate");
            Action<int, int> action = Add;
            //Action<int,int> action = new Action<int,int>(add);

            Action<string> val = delegate (string str)
            {
                Console.WriteLine(str);
            };
            val("Hello");

            Action<int, int> action1 = (int p, int q) => { Console.WriteLine(p - q); };
            action(1, 2);
            action1(8, 6);
            Console.WriteLine();
        }
        public static void Multicast()
        {

            Console.WriteLine("Multicast Delegate");
            Console.WriteLine();

            MyDelegate del = new MyDelegate(Add);
            del += Sub;
            del += Multiply;
            del(8, 5);
        }

        public static void FuncDelegate()
        {
            Console.WriteLine();
            Console.WriteLine("Func Delegate");
            Console.WriteLine();
            //func can have input parameters from 0 to 16 and one output parameter.Last parameter
            //of the Func delegate is the out parameter which is considered as return type and used
            //for the result
            Func<int, int, int> myfunc = Addition;
            Console.WriteLine("Addition {0} ", myfunc(10, 11));


            Func<int, int, int> myfunc2 = (int x, int y) =>
            {
                return x + y;
            };
            Console.WriteLine("Addition1 {0} ", myfunc(10, 11));


            Func<int, int, int> myfunc3 = delegate (int x, int y)
            {
                return x + y;
            };
            Console.WriteLine("Addition2 {0} ", myfunc(10, 11));
            Console.WriteLine();
        }
        public static void PredicateDelegate()
        {
            Console.WriteLine("Predicate Deligate");
            Console.WriteLine();

            //return type is boolean
            //This delegate takes only one input and returns the value in the form of true or false.
            Predicate<string> predicate = str => str.Equals(str.ToLower());
            Console.WriteLine($"{predicate("Hello")}");
            Console.WriteLine($"{predicate("hello")}");
        }
        public static int Addition(int x, int y)
        {
            return x + y;
        }
        public static void Add(int x, int y)
        {
            Console.WriteLine($"Addition : 8 - 5 ={x + y}");   
        }
        public static void Sub(int x, int y)
        {
            Console.WriteLine($"Subtarction : 8 - 5 = {x - y}");
        }
        public static void Multiply(int x, int y)
        {
            Console.WriteLine($"Multiplication : 8 X 5 = {x * y}");
        }


    }
    
}