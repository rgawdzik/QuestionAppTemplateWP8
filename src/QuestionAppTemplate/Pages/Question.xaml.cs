using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

using QuestionAppTemplate.Classes;

namespace QuestionAppTemplate.Pages
{
    public partial class Question : PhoneApplicationPage
    {
        QuestionManager QuestionManager;

        /// <summary>
        /// Sets up the Question Page.
        /// </summary>
        public Question()
        {
            InitializeComponent();
            QuestionManager = MainPage.QuestionManager;
            AppTitle.Text = QuestionManager.AppName + "-Question #" + (QuestionManager.CurrentQuestion + 1);
            this.Loaded += (o, e) =>
            {
                ContentPanel.DataContext = QuestionManager.GetCurrentQuestion(); AnswerList.SelectedIndex = 0;
                //Default Selection
            };

        }

        /// <summary>
        /// The user has submitted an answer.
        /// </summary>
        private void SubmitAnswer(object sender, RoutedEventArgs e)
        {
            if (QuestionManager.GetCurrentQuestion().CheckQuestion(AnswerList.SelectedIndex))
            {
                QuestionManager.CorrectQuestionsAmount++; //Executed when the user has a correct answer.
            }
            if (!QuestionManager.NoMoreQuestions())
            {
                QuestionManager.CurrentQuestion++;
                NavigationService.Navigate(new Uri("/Pages/Question.xaml?id=" + QuestionManager.CurrentQuestion, UriKind.Relative));
            }
            else
            {
                NavigationService.Navigate(new Uri("/Pages/Result.xaml", UriKind.Relative));
            }
        }
    }
}