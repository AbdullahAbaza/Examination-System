
namespace Examination_System.Questions
{
    internal class Answers : ICloneable
    {
        public int AnswerId { get; }
        public string AnswerText { get; }

        public Answers(int _AnswerId, string _AnswerText) {
            AnswerId = _AnswerId;
            AnswerText = _AnswerText;
        }

        public Answers( Answers CopyAnswer) { 
            AnswerId = CopyAnswer.AnswerId;
            AnswerText = CopyAnswer.AnswerText;
        }
        public override string ToString()
        {
            return $"{AnswerId}. {AnswerText}";
        }

        public object Clone()
        {
            return new Answers(this);
        }
    }
}
 