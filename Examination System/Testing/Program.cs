using Testing.types;

namespace Testing
{
    internal class Program
    {
        static void Main(string[] args)
        {
            typeA t1 = new typeA();
            Console.WriteLine(t1.GetType());

            typeA t2 = new typeB();
            //Console.WriteLine(t2.GetType());

            if(t2.GetType().ToString() == "Testing.types.typeB")
                Console.WriteLine(t2.GetType().ToString());
        }

    }

    internal class typeA
    {
        public int a { get; set; }
    }
}