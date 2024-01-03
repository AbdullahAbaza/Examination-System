using Examination_System.Exams;
using System;

namespace Examination_System
{
    internal class Subject
    {
        
        public int Id { get; }
        public string Name { get; }
        public Exam? AssociatedExam { get; private set; }

        public Subject(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public void CreateExam()
        {
            // not implemented yet
            bool flag1, flag2, flag3; int typeofexam; int timeofexam; int numberofquestions;

            do
            {
                Console.Write("Please Enter The Type Of Exam You Want To Create ( 1.Practical 2.Final ): ");
                flag1 = int.TryParse(Console.ReadLine(), out typeofexam);
            } while (!flag1 || typeofexam < 1 || typeofexam > 2);
            do
            {
                Console.Write("\nPlease Enter The Time Of Exam in Minutes: ");
                flag2 = int.TryParse(Console.ReadLine(), out timeofexam);
            } while (!flag2);
            do
            {
                Console.Write("\nPlease Enter The Number Of Questions You Want To Create: ");
                flag3 = int.TryParse(Console.ReadLine(), out numberofquestions);
            } while (!flag3);


            Console.Clear();

            if (typeofexam == 1)
                AssociatedExam = new PracticeExam(timeofexam, numberofquestions);

            else AssociatedExam = new FinalExam(timeofexam, numberofquestions);

        }
    }
}
