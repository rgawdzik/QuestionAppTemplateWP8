using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using QuestionAppTemplate.Resources;

using QuestionAppTemplate.Classes;

namespace QuestionAppTemplate
{
    /// <summary>
    /// The Question App is a template based app which requires 3 steps to have your own app that asks quesitons.
    /// Steps to Complete Template.
    /// 1. Questions/Questions.txt, add at least 10 questions that are formatted correctly.
    /// </summary>
    public partial class MainPage : PhoneApplicationPage
    {
        public QuestionManager QuestionManager { get; set; }
        public MainPage()
        {
            InitializeComponent();

            Task a = Load();

        }

        public async Task Load()
        {
            try
            {
                QuestionManager = new QuestionManager(await FileIO.ReadStaticResource((@"/QuestionAppTemplate;component/Questions/Questions.txt")));
            }
            catch (Exception) { }
        }
    }
}