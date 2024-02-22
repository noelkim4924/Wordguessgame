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
    public class WordHiderTests
    {
        [TestMethod]
        public void HideCharacters_AllHidden_ReturnsAllAsterisks()
        {
            var wordHider = new WordHider();
            string result = wordHider.HideCharacters("word", new List<char>());
            Assert.AreEqual("****", result);
        }

        [TestMethod]
        public void HideCharacters_SomeGuessed_ReturnsPartiallyRevealedWord()
        {
            var wordHider = new WordHider();
            string result = wordHider.HideCharacters("word", new List<char> { 'w', 'r', 'd' });
            Assert.AreEqual("w*rd", result);
        }
    }

}