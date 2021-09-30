using NUnit.Framework;
using KataTicTacToe;

namespace KataTicTacToeTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Should_return_false_when_field_has_token()
        {
            // Act
            var game = new TicTacToeGame(3, Token.X);
            bool result = game.Play(0, 0);
            result = game.Play(0, 0);

            // Assert
            Assert.AreEqual(false, result);
        }
        [Test]
        public void Should_return_true_when_field_is_empty()
        {
            // Act
            var game = new TicTacToeGame(3, Token.X);
            bool result = game.Play(0, 0);
            

            // Assert
            Assert.AreEqual(true, result);
        }


    }
}