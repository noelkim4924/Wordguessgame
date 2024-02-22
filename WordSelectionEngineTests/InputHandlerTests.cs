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
    public class InputHandlerTests
    {
        [TestMethod]
        public void ProcessInput_ValidSingleCharacter_ReturnsCharacter()
        {
            var inputHandler = new InputHandler();
            char expected = 'a';
            char result = inputHandler.ProcessInput("a");
            Assert.AreEqual(expected, result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void ProcessInput_InvalidInput_ThrowsArgumentException()
        {
            var inputHandler = new InputHandler();
            inputHandler.ProcessInput("");
        }
    }

}