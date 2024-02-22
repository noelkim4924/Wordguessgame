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
    public class WordSelectorTests
    {
        [TestMethod]
        public void SelectRandomWord_ReturnsNonEmptyString()
        {
            var wordSelector = new WordSelector();
            string result = wordSelector.SelectRandomWord();
            Assert.IsFalse(string.IsNullOrEmpty(result));
        }

        [TestMethod]
        public void SelectRandomWord_ReturnsExpectedFormat()
        {
            var wordSelector = new WordSelector();
            string result = wordSelector.SelectRandomWord();
            // Assuming the format is "explanation,word"
            string[] parts = result.Split(',');
            Assert.AreEqual(2, parts.Length); // Ensure there are two parts
        }
    }

}