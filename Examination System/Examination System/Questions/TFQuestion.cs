using System;
using System.Reflection.PortableExecutable;
using System.Text;

namespace Examination_System.Questions
{
    internal class TFQuestion : QuestionBase
    {
        public override string Header => "True Or False Question :";

        public TFQuestion()
        {
            AnswerList = new Answers[2];
            AnswerList[0] = new Answers(1, "True");
            AnswerList[1] = new Answers(2, "False");
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

            bool flag; int mark;
            do
            {
                Console.WriteLine("Please Enter The Mark Of Question [1 : 10]:");
                flag = int.TryParse(Console.ReadLine(), out mark);
            } while (!flag || mark < 1 || mark > 10);
            Mark = mark;

            bool flag2;
            do
            {
                Console.WriteLine("Please Enter The Right Answer of Question as int ( 1.True 2.False )");
                flag2 = int.TryParse(Console.ReadLine(), out rightanswer);
            } while (!flag2 || rightanswer < 1 || rightanswer > 2);
        }



        public override string ToString()
        {
            StringBuilder questionstring = new StringBuilder();
            questionstring.Append($"{Header}     Mark({Mark})\n{Body}\n");

            foreach (Answers answer in AnswerList)
                questionstring.Append($"{answer.ToString()}            ");

            questionstring.Append("\n--------------------------------------------------\n");

            return questionstring.ToString();

        }


    }
}

    

