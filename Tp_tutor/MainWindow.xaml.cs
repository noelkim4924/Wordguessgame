using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace Tp_tutor
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(name));
        }
        private string wrongStatus;
        private string selEng;
        private string selKor;
        private string message;
        private List<char> btns = new List<char>();

        public string WrongStatus
        {
            get => wrongStatus;
            set
            {
                wrongStatus = value;
                OnPropertyChanged("WrongStatus");
            }
        }
        public string SelEng
        {
            get => selEng;
            set
            {
                selEng = value;
                OnPropertyChanged("SelEng");
            }
        }

        public string SelKor
        {
            get => selKor;
            set
            {
                selKor = value;
                OnPropertyChanged("SelKor");
            }
        }

        public string Message
        {
            get => message;
            set
            {
                message = value;
                OnPropertyChanged("Message");
            }
        }
        List<char> SelWord = new List<char>();
        List<string> words = new List<string>()
        {
            "boy,소년",
            "school,학교",
            "sibal,스으발",
        };
        int wrong = 0;
        int maxWrong = 3;
        string compareWord = string.Empty;

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            btns.AddRange("abcdefghijklmnopqrstuvwxyz");
            ic.ItemsSource = btns;
            RandomWord();
            ChangeWord(SelEng, SelWord);
            WrongStatus = $"WrongTIme:{wrong} of {maxWrong}";
        }

        private void ChangeWord(string selEng, List<char> selWord)
        {
            // making answer as a * function
            char[] result = selEng.Select(x => (selWord.IndexOf(x) >= 0 ? x : '*')).ToArray();
            SelEng = string.Join(" ", result);

        }

        private void RandomWord()
        {
            string[] selChar = words[new Random().Next(0, words.Count)].Split(',');
            SelEng = selChar[0];
            SelKor = selChar[1];
            compareWord = SelEng;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            wrong = 0;
            SelWord = new List<char>();
            RandomWord();
            ChangeWord(SelEng, SelWord);
            Message = "알파벳을 선택하여주세요";
            Status();
            foreach (var a in ic.Items)
            {
                var btn = (UIElement)ic.ItemContainerGenerator.ContainerFromItem(a);
                if (btn != null)
                {
                    btn.IsEnabled = true;
                }
            }
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var btn = sender as Button;
            if (btn != null)
            {
                var result = btn.Content.ToString();
                CheckWord(result[0]);

            }
        }

        private void CheckWord(char v)
        {
            if (SelWord.IndexOf(v) == -1)
            {
                SelWord.Add(v);
            }
            if (compareWord.IndexOf(v) >= 0)
            {
                ChangeWord(compareWord, SelWord);
                CheckWin();
            }
            else if(compareWord.IndexOf(v) == -1)
            {
                wrong++;
                Status();
                CheckLost();
            }
        }

        private void Status()
        {
            WrongStatus = $"WrongTIme:{wrong} of {maxWrong}";
        }
        private void CheckWin() 
        {
            if(compareWord == SelEng.Replace(" ",""))
            {
                Message = "You Win!";
                foreach (var a in ic.Items)
                {
                    var btn = (UIElement)ic.ItemContainerGenerator.ContainerFromItem(a);
                    if (btn != null)
                    {
                        btn.IsEnabled = false;
                    }
                }

            }
        }
        private void CheckLost() 
        {
            if (wrong == maxWrong) 
            {
                Message = "You Lost!";
                foreach(var a in ic.Items)
                {
                    var btn = (UIElement)ic.ItemContainerGenerator.ContainerFromItem(a);
                    if(btn != null) 
                    {
                        btn.IsEnabled = false;
                    }
                }
            }
        
        }
    }
}
