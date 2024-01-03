
namespace Examination_System.Questions
{
    internal abstract class QuestionBase
    {
        public abstract string? Header { get; }
        public string? Body { get; protected set; }

        private int mark;

        public int Mark
        {
            get { return mark; }
            protected set { mark = value; }
        }


        public Answers[] AnswerList { get; protected set; }

        protected int rightanswer;
        public int RightAnswer
        {
            get { return rightanswer; }
            protected set { rightanswer = value; }
        }


        public string GetRightAnswerString { get { return $"{AnswerList[RightAnswer - 1].ToString()}"; } }
        public string GetStudentAnswerString(int answer)
        {
            return $"{AnswerList[answer - 1].ToString()}";
        }

        public abstract void AddQuestion();


        public QuestionBase()
        {

        }


    }
}
