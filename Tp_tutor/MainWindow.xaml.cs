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
// class library  namespace
using WordSelectionEngine;

namespace Tp_tutor
{
    public partial class MainWindow : Window
    {
        // main aplication class implement
        /*
        public partial class MainWindow : Window
        {
            private WordSelector wordSelector = new WordSelector();
            private WordHider wordHider = new WordHider();

            public MainWindow()
            {
                InitializeComponent();
                DataContext = this;
                InitializeGame();
            }

            private void InitializeGame()
            {
                // WordSelector를 사용하여 무작위 단어를 선택합니다.
                var word = wordSelector.SelectRandomWord();
                SelExp = word.Explanation; // 예를 들어, 단어의 설명 부분
                SelEng = word.Word; // 예를 들어, 가릴 단어 부분
                compareWord = SelEng; // 실제 단어를 비교하기 위한 변수에 저장
                UpdateWordDisplay();
            }

            private void UpdateWordDisplay()
            {
                // WordHider를 사용하여 단어를 가립니다.
                SelEng = wordHider.HideCharacters(compareWord, SelWord);
            }

            // 사용자가 글자를 선택하거나 입력하는 이벤트 핸들러에서 UpdateWordDisplay를 호출할 수 있습니다.
            // 예시: 사용자가 'a' 글자를 선택했다고 가정
            private void OnLetterSelected(char selectedLetter)
            {
                if (!SelWord.Contains(selectedLetter))
                {
                    SelWord.Add(selectedLetter);
                    UpdateWordDisplay();
                }
            }
        }

        */
    }

}

namespace Tp_tutor
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window,INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if(handler != null) handler(this, new PropertyChangedEventArgs(name));
        }
        private string wrongStatus;
        private string selExp;
        private string selEng;
        private string message;
        private List<char> btns = new List<char>();

        public string WrongStatus {
            get => wrongStatus;
            set
            {
                wrongStatus = value;
                OnPropertyChanged("WrongStatus");
            }
        }

        public string SelExp
        {
            get => selExp;
            set
            {
                selExp = value;
                OnPropertyChanged("SelExp");
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
            "explaination 1, answer 1",
            "explaination 2, answer 2",
            "explaination 3 , answer 3",
        };
        int wrong =0;
        int maxWrong = 3;
        string compareWord = string.Empty;


        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;
            btns.AddRange("abcdefghijklmnopqrstuvwxyz");
            ic.ItemsSource = btns;
            RandomWord();
            ChangWord(SelEng, SelWord);
        }

        private void ChangWord(string selEng, List<char> selWord)
        {
            // making answer as a * function
            char[] result = selEng.Select(x => (selWord.IndexOf(x) >= 0 ? x : '*')).ToArray();
            SelEng = string.Join(" ", result);
        }

        private void RandomWord()
        {
            string[] selChar = words[new Random().Next(0, words.Count)].Split(',' );
            SelExp = selChar[0];
            SelEng = selChar[1];
            compareWord = selEng;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
