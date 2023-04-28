using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace AreYouPopeye
{
    public partial class MainPage : ContentPage
    {
        private string[] _questions = {
                                        "You love spinach!",
                                        "You love Bluto!",
                                        "You don't have any tatoos.",
                                        "You smoke a pipe.",
                                        "You were once portrayed by Robin Williams."
                                      };
        private bool[] _correctAnswers = {
                                                true,
                                                false,
                                                false,
                                                true,
                                                true
                                            };
        private int _qIndex = 0;
        private bool _isPopeye = true;

        public MainPage()
        {
            InitializeComponent();
            QuestionText.Text = _questions[_qIndex];
        }

        public void Answer(object sender, EventArgs e)
        {
            Button btn = (Button)sender;

            bool answer = false;
            if (btn.ClassId == "TrueButton")
            {
                answer = true;
            }

            if (_isPopeye && answer != _correctAnswers[_qIndex])
            {
                _isPopeye = false;
            }

            if (_qIndex < 4)
            {
                _qIndex++;
                QuestionText.Text = _questions[_qIndex];
            }
            else
            {
                TrueButton.IsVisible = false;
                FalseButton.IsVisible = false;
                HelperText.Text = "";

                if (_isPopeye)
                {
                    Olive.Source = "olive2.png";
                    QuestionText.Text = "You Are Popeye!";
                }
                else
                {
                    Olive.Source = "olive3.png";
                    QuestionText.Text = "You Are Not Popeye!";
                }
            }
        }
    }
}
