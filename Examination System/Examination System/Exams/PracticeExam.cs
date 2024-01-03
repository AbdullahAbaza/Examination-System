using Examination_System.Questions;
using System.Text;

namespace Examination_System.Exams
{
    internal class PracticeExam : Exam
    {
        public new MCQ[] Questions { get; set; }

        private int[, ] StudentAnswers;
        // a Two Dimentional Array that Holds All Student Answers(MCQ Question Can Have Mutiple Answer in Practical Exam)


        public PracticeExam(int timeofexam, int numberofquestions) : base(timeofexam, numberofquestions)
        {
            CreateListOfQuestions();

        }

        public override void CreateListOfQuestions()
        {

            Questions = new MCQ[NumberOfQuestions];
            StudentAnswers = new int[Questions.Length, 4]; // Assuming Questions[i].AnswerList.Length == 4 as max value


            for (int i = 0; i < Questions.Length; i++)
            {
                Console.WriteLine($"Question Number {i + 1}:");
                Console.Clear();
                Questions[i] = new MCQ();
                Console.Clear();
            }
        }


        public override void StartExam()
        {
            Console.Clear();
            for (int i = 0; i < Questions.Length; i++)
            {
                Console.WriteLine($"{Questions[i].ToString()}");

                Console.WriteLine("Enter Your Answer: ");
                for (int j = 0; j < Questions[i]?.RightAnswers?.Length; j++)
                {
                    bool flag;
                    do
                    {
                        flag = int.TryParse(Console.ReadLine(), out StudentAnswers[i, j]);

                    } while (!flag || StudentAnswers[i, j] < 0 || StudentAnswers[i, j] > Questions[i].AnswerList.Length);

                }

                Console.WriteLine("=========================================\n");
            }

            // Show All Exam After Finish
            ShowAnswers();
        }

        public void ShowAnswers()
        {
            Console.Clear();
            Console.WriteLine("Exam Answers:");

            StringBuilder questionstring = new StringBuilder();

            for (int i = 0; i < Questions.Length; i++)
            {
                if (Questions[i] is not null)
                {
                    questionstring.Append($"Q{i + 1})    {Questions[i].Body}: \nRightAnswers: ");
                    for (int j = 0; j < Questions[i].RightAnswers?.Length; j++)
                    {
                        int answer = Questions[i].RightAnswers[j];
                        questionstring.Append($"{Questions[i][answer]}     ");

                        //questionstring.Append($"\nYour Answers: {Questions[i].GetStudentAnswerString()}");
                    }
                }


                
                Console.WriteLine($"{questionstring.ToString()}");
                questionstring.Clear();

            }

        }


    }
}
