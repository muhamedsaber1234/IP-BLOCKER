using System.ComponentModel;

namespace c__oop_all_tasks
{
    class Day1Part1Part1
    {
        private static string Reading( string inputt)
        {
            Console.WriteLine($"entar a valid {inputt}");
            string input = Console.ReadLine();
            return input;
        }
        public static void ToAscii()
        {
            int ascii = Char.Parse(Reading("charchter"));
            Console.WriteLine(ascii);
        }

        public static void fromAscii()
        {

            char chard = (Char) int.Parse(Reading("number"));         
            Console.WriteLine(chard);
        }
        public static void EvenOrOdd()
        {   
            int num = int.Parse(Reading("number"));
            if (num % 2 == 0)
            {
                Console.WriteLine("even");
            }
            else
            {
                Console.WriteLine("odd");
            }
        }
        public static void Operations()
        {  
            int s = int.Parse(Reading("number"));        
            int e = int.Parse(Reading("number"));
            Console.WriteLine($"sum = {s+e},sub = {s/e}, ,multiply = {s*e}");
        }

        public static void Grade()
        {
             static void print(string grade)
            {
                Console.WriteLine(grade);
            }
            int degree = int.Parse(Reading("degree"));
            if(degree >= 90)
            {
                print("a");
                
            }
             else if (degree >=80)
             {
                print("b");
               

            }
            else if (degree >=70)
             {
                print("c");
                

            }
            else if (degree >= 60)
             {
                print("d");
               

            }
            else
            {
                print("f");
            }
        }
        public static void MultiplicationTable()
        {
            for (int i = 1; i < 11; i++)
            { 
                for(int j = 1; j < 11; j++)
                {
                    Console.WriteLine($"{i}x{j}={i*j}");
                }
            }
        }
    }
    class Panda
    {
        public static void DivideNumbers(int a, int b)
        {
            try
            {
                int result = a / b; // This will throw a DivideByZeroException if b is 0
            }
            catch (Exception ex)
            {
                //Console.WriteLine("An error occurred: " + ex.Message);
                throw ex; // Rethrow the original exception, preserving the stack trace
            }
        }

        public void CallDivideNumbers()
        {
            try
            {
                DivideNumbers(10, 0); // Will cause an exception
            }
            catch (Exception ex)
            {
                Console.WriteLine("Caught in outer method: " + ex.StackTrace); // Original stack trace
            }
        }

    }
    internal class Program
    {
        static void Main(string[] args)
        {
            Panda.DivideNumbers(10, 0);
        }
    }
}
