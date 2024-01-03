using Examination_System.Questions;
using System;
using System.Text;

namespace Examination_System.Exams
{
    internal class FinalExam : Exam
    {
        
        private int[] StudentAnswers;

        private int totalmarks;
        
        private int grade;

        public FinalExam(int timeofexam, int numberofquestions) : base(timeofexam, numberofquestions)
        {
            CreateListOfQuestions();
        }

        public override void CreateListOfQuestions() {
            Questions = new QuestionBase[NumberOfQuestions];
            StudentAnswers = new int[NumberOfQuestions];

            bool flag1; int typeofquestion;
            for (int i = 0; i < Questions.Length; i++)
            {

                do
                {
                    Console.WriteLine($"Please Choose The Type Of Question Number({i + 1}) ( 1. True or False || 2. MCQ)");
                    flag1 = int.TryParse(Console.ReadLine(), out typeofquestion);

                } while (!flag1 || typeofquestion < 1 || typeofquestion > 2);

                Console.Clear();

                if (typeofquestion == 1) // TF Question
                {
                    Questions[i] = new TFQuestion();
                }
                else
                    Questions[i] = new MCQ_OneChoice();


                totalmarks += Questions[i].Mark;

                Console.Clear();
            }

        }


        public override void StartExam()
        {
            Console.WriteLine($"Total Marks: {totalmarks}");

            Console.Clear();
            for (int i = 0; i < Questions.Length; i++)
            {
                Console.WriteLine($"{Questions[i].ToString()}");
                bool flag;
                do
                {
                    flag = int.TryParse(Console.ReadLine(), out StudentAnswers[i]);
                } while (!flag || StudentAnswers[i] < 0 || StudentAnswers[i] > 3);

                Console.WriteLine("=========================================\n");
            }

            // show all exam after finish
            Console.Clear();
            ShowAnswers();

            CalculateCrade();
            Console.WriteLine($"Your Exam Grade Is {grade} out of {totalmarks}\n");


        }


        public void ShowAnswers()
        {

            Console.WriteLine("Exam Answers:");
            StringBuilder questionstring = new StringBuilder();

            for (int i = 0; i < Questions.Length; i++)
            {
                questionstring.Append($"Q{i + 1})    {Questions[i].Body}:\n");

                questionstring.Append($"Your Answer: {Questions[i].GetStudentAnswerString(StudentAnswers[i])}\n");
                questionstring.Append($"RightAnswer: {Questions[i].GetRightAnswerString}\n");



                Console.WriteLine($"{questionstring.ToString()}");

                questionstring.Clear();
            }
        }

        public void CalculateCrade()
        {
            for (int i = 0; i < Questions.Length; i++)
            {
                if (Questions[i].RightAnswer == StudentAnswers[i])
                {
                    grade += Questions[i].Mark;
                }

            }

        }
    } 
}