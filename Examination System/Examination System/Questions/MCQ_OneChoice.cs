using System;
using System.Text;

namespace Examination_System.Questions
{
    internal class MCQ_OneChoice : QuestionBase
    {
        public override string Header => "MCQ Question";


        public MCQ_OneChoice()
        {
            AnswerList = new Answers[3];
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

            bool flag;
            do
            {
                Console.WriteLine("Please Specify the Right Choice Of Question:");
                flag = int.TryParse(Console.ReadLine(), out rightanswer);

            } while (!flag || rightanswer < 1 || rightanswer > 3);
        }

        public override string ToString()
        {
            StringBuilder questionstring = new StringBuilder();
            questionstring.Append($"{Header}     Mark({Mark})\n{Body}\n");
            foreach(Answers answer in AnswerList){
                questionstring.Append($"{answer.ToString()}            ");

            }
            questionstring.Append("\n--------------------------------------------------\n");
           
            return questionstring.ToString();
        }


    }
}
