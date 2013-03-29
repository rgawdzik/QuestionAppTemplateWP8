using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionAppTemplate.Classes.Structures
{
    public class Question : Bindable
    {
        public ObservableCollection<Answer> AnswerList { get; set; }
        public string QuestionStatement { get; set; }

        /// <summary>
        /// Sets up a question that might be prompted to the user.
        /// </summary>
        /// <param name="statement">The actual question text.</param>
        /// <param name="answers">An array of answers that the user can choose from.</param>
        /// <param name="correctAnswer">The index of the correct answer.</param>
        public Question(string statement, string[] answers, int correctAnswer)
        {
            AnswerList = new ObservableCollection<Answer>();
            QuestionStatement = statement;
            for (int i = 0; i < answers.Length; i++)
            {
                //This internal function sets the answer to correct if the current Index is equal to the index of the correct answer.
                AnswerList.Add(new Answer(answers[i], new Func<bool>(() => { if (i == correctAnswer) return true; return false; }).Invoke()));
            }
        }

        /// <summary>
        /// Checks to see if the item he choose was the correct answer.
        /// </summary>
        /// <param name="index">The item index within the list.</param>
        /// <returns>Returns true if the question has been chosen correctly.</returns>
        public bool CheckQuestion(int index)
        {
            return AnswerList[index].Correct;

        }

    }
}
