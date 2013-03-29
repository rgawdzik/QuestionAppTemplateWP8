using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestionAppTemplate.Classes.Structures
{
    /// <summary>
    /// Represents an answer in a question.
    /// </summary>
    public class Answer : Bindable
    {
        public bool Correct { get; set; }
        public string AnswerStatement { get; set; }

        /// <summary>
        /// Sets up an answer that a user may choose on-screen.
        /// </summary>
        /// <param name="statement">The textual statement of the answer.</param>
        /// <param name="correct">A boolean stating if it is the right answer out of a set of answers.</param>
        public Answer(string statement, bool correct)
        {
            Correct = correct;
            AnswerStatement = statement;
        }

    }
}
