using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    public class QuestionManager : Bindable
    {
        public string AppName { get; set; }

        public ObservableCollection<Question> QuestionList;

        /// <summary>
        /// Sets up and randomly arranges the questions in the question Manager.
        /// </summary>
        /// <param name="questionFile"></param>
        public QuestionManager(string questionFile)
        {
            string appname = "";
            QuestionList = new ObservableCollection<Question>(ParseQuestionFile(questionFile, out appname));
            AppName = appname;
        }


        /// <summary>
        // FORMAT
        // ------
        // ------------------------------------------ #START
        // Title                                           | //The title of the app.
        // ~                                               | // ~ is a line seperator, and lines after the first ~ are questions.
        // This is a question, what is the answer?         | // The actual question
        // #A1:Answer 1 #A2:Answer 2 #A3:Answer 3          | //The answers: Note that you must have at least 2 answers, but less than 10 answers.
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
            string[] splitBySeperators = questionFile.Replace("~", " ").Replace("\r", "").Split('\n');

            
            for (int i = 0; i < splitBySeperators.Length; i++)
            {
                if (splitBySeperators[i].Length > 2)
                {
                    if (i == 0) appTitle = splitBySeperators[i];
                    else
                    {
                        Question toParseQuestion = new Question(splitBySeperators[i], ParseAnswers(splitBySeperators[i + 1]), GetCorrect(splitBySeperators[i + 3]));
                        returnList.Add(toParseQuestion);
                    }
                }
            }

            return returnList;
        }
        /// <summary>
        /// Returns the correct answer from the answer string.
        /// </summary>
        private int GetCorrect(string correctAnswer)
        {
            return Int32.Parse(correctAnswer.Substring(1, correctAnswer.Length - 1)) - 1;
        }
        
        /// <summary>
        /// Parses the answer list.
        /// </summary>
        /// <param name="answerData">The unparsed string data.</param>
        /// <returns>The split string data.</returns>
        private string[] ParseAnswers(string answerData)
        {
            string[] splitAnswers = answerData.Substring(1,answerData.Length - 1).Split('#');
            for(int i = 0; i < splitAnswers.Length; i++)
            {
                splitAnswers[i] = splitAnswers[i].Substring(3, splitAnswers[i].Length - 3).Trim();
            }
            return splitAnswers;
        }
    }
}
