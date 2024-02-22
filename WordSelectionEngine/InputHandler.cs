using System;

namespace WordSelectionEngine
{
    public class InputHandler
    {
        public char ProcessInput(string input)
        {
            // 입력을 받아 문자로 변환합니다. 실제 게임에서는 입력 검증이 필요할 수 있습니다.
            if (!string.IsNullOrEmpty(input) && input.Length == 1)
            {
                return input[0];
            }
            else
            {
                throw new ArgumentException("Invalid input");
            }
        }
    }
}
