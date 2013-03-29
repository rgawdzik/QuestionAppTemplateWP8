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
    /// The Question App is a template-based app which requires 3 steps to have your own app that asks questions.
    /// Steps to Complete Template.
    /// 1. Edit Questions/Questions.txt, add at least 2 questions with answers that are formatted correctly.
    /// 2. Change the title and app images of the app within WMAppManifest.xml.
    /// 3. You are done!
    /// </summary>
    public partial class MainPage : PhoneApplicationPage
    {
        //Manages all static properties of the Questions.
        public static QuestionManager QuestionManager { get; set; }
        

        public MainPage()
        {
            InitializeComponent();
            Task a = Load();
            this.Loaded += (o, e) => { NavigationService.Navigate(new Uri("/Pages/Question.xaml?id=" + QuestionManager.CurrentQuestion, UriKind.Relative)); };
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