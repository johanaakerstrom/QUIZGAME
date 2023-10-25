using QUIZGAME.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace QUIZGAME
{
    /// <summary>
    /// Interaction logic for QuizView.xaml
    /// </summary>
    public partial class QuizView : Window
    {
        private int currentIndex = 0;
        public string CounterQuestion {  get; set; }
        public Question CurrentQuestion { get; set; }
        public List<Question> questions {  get; set; }
        public QuizView()
        {
            InitializeComponent();
            DataContext = this;
            
        }

        private void ShowQuestion()
        {
            currentIndex++;
            CurrentQuestion = questions[currentIndex];
            CounterQuestion = $"{currentIndex + 1} of {questions.Count}";
            CounterQuestionText.Text = CounterQuestion;
        }

        private void AnswerButton_Click(object sender, RoutedEventArgs e)
        {
            if (int.Parse((sender as Button).Tag.ToString()) == CurrentQuestion.CorrectAnswers)
            {
                MessageBox.Show("Good Job!");
                ShowQuestion();
                
            }
            else
            {
                MessageBox.Show("Wrong answer");
            }
        }

        private void NextQuestionButton_Click(object sender, RoutedEventArgs e)
        {
            ShowQuestion();
        }

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            CurrentQuestion = questions.First();
            CurrentQuestionText.Text = CurrentQuestion.Statement;
            CounterQuestion = $"{currentIndex + 1} of {questions.Count}";
            CounterQuestionText.Text = CounterQuestion;
        }
    }
}
