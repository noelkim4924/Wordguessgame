using System;
using System.Collections.Generic;

namespace WordSelectionEngine
{
    public class WordSelector
    {
        private List<string> words = new List<string>
        {
            "explanation 1,answer 1",
            "explanation 2,answer 2",
            "explanation 3,answer 3",
        };

        private Random random = new Random();

        public string SelectRandomWord()
        {
            // 단어 목록에서 무작위 인덱스를 선택합니다.
            int index = random.Next(words.Count);
            // 선택된 단어를 반환합니다.
            return words[index];
        }
    }
}
