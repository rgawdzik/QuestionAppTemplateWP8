using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionAppTemplate.Classes.Structures
{
    public class Question
    {
        public List<Answer> AnswerList { get; set; }
        public string QuestionStatement { get; set; }

        /// <summary>
        /// Sets up a question that might be prompted to the user.
        /// </summary>
        /// <param name="statement">The actual question text.</param>
        /// <param name="answers">An array of answers that the user can choose from.</param>
        /// <param name="correctAnswer">The index of the correct answer.</param>
        public Question(string statement, string[] answers, int correctAnswer)
        {
            AnswerList = new List<Answer>();
            for (int i = 0; i < AnswerList.Count; i++)
            {
                //This internal function sets the answer to correct if the current Index is equal to the index of the correct answer.
                AnswerList.Add(new Answer(answers[i], new Func<bool>(() => { if (i == correctAnswer) return true; return false; }).Invoke()));
            }
        }

    }
}
