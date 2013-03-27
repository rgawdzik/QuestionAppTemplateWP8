using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using QuestionAppTemplate.Classes;
using QuestionAppTemplate.Classes.Structures;

namespace QuestionAppTemplate.Classes
{

    /// <summary>
    /// Manages and generates the questions 
    /// </summary>
    public class QuestionManager
    {
        public string AppName { get; set; }



        /// <summary>
        /// Sets up and randomly arranges the questions in the question Manager.
        /// </summary>
        /// <param name="questionFile"></param>
        public QuestionManager(string questionFile)
        {

        }


        /// <summary>
        // FORMAT
        // ------
        // ------------------------------------------ #START
        // Title                                           | //The title of the app.
        // ~                                               | // ~ is a line seperator, and lines after the first ~ are questions.
        // This is a question, what is the answer?         | // The actual question
        // #A1:Answer 1 #A2: Answer 2 #A3 Answer 3         | //The answers: Note that you must have at least 2 answers.
        // #A3                                             | //The RIGHT answer
        // ~                                               |
        // This is a question, what is the answer?         |
        // #A1:Answer 1 #A2: Answer 2 #A3 Answer 3         |
        // #A3											   |
        // &&&&                                            | // Four &(Amperstands) specifies the document ends.
        // ---------------------------------------------#END
        /// </summary>
        /// <param name="questionFile">The string makeup of the Questions.txt</param>
        /// <returns>The questions from the file</returns>

        private List<Question> ParseQuestionFile(string questionFile, out string appTitle)
        {
            List<Question> returnList = new List<Question>();
            appTitle = "";
            string[] splitBySeperators = questionFile.Remove('~').Split('\n');

            for (int i = 0; i < splitBySeperators.Length; i++)
            {
                if (i == 0) appTitle = splitBySeperators[i];
                else
                {
                    Question toParseQuestion = new Question(splitBySeperators[i], ParseAnswers(splitBySeperators[i + 1]), GetCorrect(splitBySeperators[i + 3]));
                    returnList.Add(toParseQuestion);
                }


            }


            return returnList;
        }

        private int GetCorrect(string correctAnswer)
        {
            return 0;
        }
        
        private string[] ParseAnswers(string answerData)
        {
            return new string[] { };
        }
    }
}
