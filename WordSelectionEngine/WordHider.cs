using System;
using System.Collections.Generic;
using System.Linq;

namespace WordSelectionEngine
{
    public class WordHider
    {
        public string HideCharacters(string word, List<char> guessedChars)
        {
            // 단어 내의 각 문자에 대해, guessedChars 리스트에 있는 문자는 그대로 두고,
            // 나머지 문자는 '*'로 대체합니다.
            return new string(word.Select(c => guessedChars.Contains(c) ? c : '*').ToArray());
        }
    }
}
