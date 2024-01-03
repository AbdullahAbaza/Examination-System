using System;
using System.Text;

namespace Examination_System.Questions
{
    internal class MCQ : QuestionBase
    {

        public Answers[] AnswerList { get; protected set; }

        public int[]? RightAnswers { get; private set; } // for each MCQ in AnswerList

        public override string? Header => "MCQ Question ( You Can Choose Multiple Answers )";

        // Indexer => will Help In Printing the Exam After Finish
        public string this[int index] {
            get { 
                return $"{AnswerList[index-1].ToString()}";
            }
        }


        public MCQ()
        {
            // Get Choices of the Question 
            AnswerList = new Answers[4];
            RightAnswers = null;
            AddQuestion();
        }

        public override void AddQuestion()
        {
            Console.WriteLine(Header);
            do
            {
                Console.WriteLine("Please Enter The Body Of Question:");
                Body = Console.ReadLine();
            } while (Body is null);

            Console.WriteLine("The Choices of Question: ");
            string choice;
            for (int i = 0; i < AnswerList.Length; i++)
            {
                Console.Write($"Please Enter Choice Number {i + 1}: ");
                choice = Console.ReadLine() ?? "";
                AnswerList[i] = new Answers(i + 1, choice);
            }

            Console.WriteLine();
            // Get the right answers // may be more than one answer
            FillRightAnswersArray();

        }

        /// <summary>
        /// This Function is An Incapsulation Of the Code That Fills The RightAnswers Array
        /// </summary>
        private void FillRightAnswersArray()
        {
            int numRightAnswers; bool flag1, flag2;
            do
            {
                Console.Write("please Specify the Number Of Right Answers:");
                flag1 = int.TryParse(Console.ReadLine(), out numRightAnswers);

            } while (!flag1 || numRightAnswers <= 0 || numRightAnswers > 4);

            RightAnswers = new int[numRightAnswers];

            Console.WriteLine();
            for (int i = 0; i < numRightAnswers; i++)
            {
                do
                {
                    Console.Write($"RightAnswer Num{i + 1}:");
                    flag2 = int.TryParse(Console.ReadLine(), out RightAnswers[i]);

                } while (!flag2 || RightAnswers[i] < 1 || RightAnswers[i] > 4);
            }
        }

        public override string ToString()
        {
            StringBuilder questionstring = new StringBuilder();

            questionstring.Append($"{Header}     Mark({Mark})\n{Body}\n");

            foreach(Answers answer in AnswerList)
                questionstring.Append($"{answer.ToString()}            ");

            questionstring.Append("\n--------------------------------------------------\n");
           
            return questionstring.ToString();
        }



        //public override string GetStudentAnswerString(params int[] studentAnswers)
        //{
        //    StringBuilder answerString = new StringBuilder();
        //    for (int i = 0; i < studentAnswers.Length; i++) {
        //        int a = studentAnswers[i];
        //        answerString.Append($"{this[a]}      " );
        //    }
        //    return answerString.ToString();
        //}

    }
}
