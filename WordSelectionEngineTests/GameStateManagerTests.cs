using Microsoft.VisualStudio.TestTools.UnitTesting;
using WordSelectionEngine;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordSelectionEngine.Tests
{
    [TestClass]
    public class GameStateManagerTests
    {
        [TestMethod]
        public void RegisterGuess_WrongGuess_IncrementsWrongGuesses()
        {
            var gameStateManager = new GameStateManager();
            gameStateManager.RegisterGuess('z', "word", new List<char>());
            Assert.AreEqual(1, gameStateManager.WrongGuesses);
        }

        [TestMethod]
        public void RegisterGuess_CorrectGuess_ChecksWinCondition()
        {
            var gameStateManager = new GameStateManager();
            string currentWord = "word";
            List<char> guessedChars = new List<char> { 'w', 'o', 'r' };
            gameStateManager.RegisterGuess('d', currentWord, guessedChars);
            Assert.IsTrue(gameStateManager.HasWon);
        }
    }

}