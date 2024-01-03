using System;
using System.Diagnostics;
using Examination_System.Exams;


namespace Examination_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Subject sub1 = new Subject(1, "C#");
            sub1.CreateExam();
            Console.Clear();


            char choice;
            do
                Console.WriteLine("Do You Want To Start The Exam (y | n): ");
            while (!char.TryParse(Console.ReadLine(), out choice)) ;
            if(choice == 'y' || choice == 'Y')
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                sub1?.AssociatedExam?.StartExam();
                Console.WriteLine($"The Elapsed Time = {sw.Elapsed}");
            }
            else
                Console.WriteLine("Thank You");

        }
    }

}