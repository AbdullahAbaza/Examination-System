using Examination_System.Questions;
using System;

namespace Examination_System.Exams
{
    internal abstract class Exam
    {
        public int TimeOfExam { get; }
        public int NumberOfQuestions { get; }
        public virtual QuestionBase[] Questions { get; set; }

        public Exam(int timeofexam, int numberofquestions) {
            TimeOfExam = timeofexam;
            NumberOfQuestions = numberofquestions;
        }

        public abstract void CreateListOfQuestions();
        public abstract void StartExam();
    }
}
