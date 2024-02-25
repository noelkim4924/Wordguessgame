using System.Collections.Generic;

namespace WordSelectionEngine
{
    public class GameStateManager
    {
        public int WrongGuesses { get; private set; }
        public bool IsGameOver { get; private set; }
        public bool HasWon { get; private set; }

        // 게임의 최대 허용 오답 횟수
        private readonly int maxWrongGuesses = 3;

        public GameStateManager()
        {
            WrongGuesses = 0;
            IsGameOver = false;
            HasWon = false;
        }

        public void RegisterGuess(char guess, string currentWord, List<char> guessedChars)
        {
            // 만약 추측한 글자가 단어에 없다면 오답 횟수를 증가시킵니다.
            if (!currentWord.Contains(guess))
            {
                WrongGuesses++;
                if (WrongGuesses >= maxWrongGuesses)
                {
                    IsGameOver = true;
                }
            }
            else
            {
                // 맞춘 글자를 리스트에 추가합니다.
                guessedChars.Add(guess);
                // 만약 모든 글자를 맞췄다면 게임에서 승리합니다.
                HasWon = !currentWord.Except(guessedChars).Any();
                if (HasWon)
                {
                    IsGameOver = true;
                }
            }
        }

        public void ResetGame()
        {
            WrongGuesses = 0;
            IsGameOver = false;
            HasWon = false;
        }
    }
}
