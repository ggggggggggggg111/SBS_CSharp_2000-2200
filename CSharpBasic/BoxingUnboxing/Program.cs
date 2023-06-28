namespace BoxingUnBoxing
{
    internal class Program
    {
        static void Main(string[] args) 
        {
            object obj1 = new object();
            Object obj2 = new Object();
            obj1 = 1;
            int a = 1;
            long long1 = (long)obj1;
            int b = a;
            Console.WriteLine(Campare(1, 1)); 
        }

        static bool Campare(int a,int b)
        {
            return a == b;
        }
        //static bool Campare(int a, int b)
        //{
        //    return a == b;
        //}
    }
}
