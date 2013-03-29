using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;

namespace QuestionAppTemplate.Pages
{
    public partial class Result : PhoneApplicationPage
    {
        public Result()
        {
            InitializeComponent();

            AppTitle.Text = MainPage.QuestionManager.AppName;
            TotalAnswers.Text = MainPage.QuestionManager.QuestionList.Count.ToString();
            CorrectAnswers.Text = MainPage.QuestionManager.CorrectQuestionsAmount.ToString();
            FinalResult.Text = Decimal.Round(((decimal)(0.0 + MainPage.QuestionManager.CorrectQuestionsAmount) / (decimal)(0.0 + MainPage.QuestionManager.QuestionList.Count)) * 100, 1).ToString() + "%";
        }

        /// <summary>
        /// The user wishes to retry the questionnaire.
        /// </summary>
        private void RetryClick(object sender, RoutedEventArgs e)
        {
            MainPage.QuestionManager.CorrectQuestionsAmount = 0;
            MainPage.QuestionManager.CurrentQuestion = 0;
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }
    }
}