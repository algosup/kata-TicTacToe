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

        [Test]
        public void Should_return_alternated_tokens()
        {
            //Act
            var game = new TicTacToeGame(3, Token.X);
            Token token1 = game.GetCurrentToken();
            game.Play(0, 0);
            Token token2 = game.GetCurrentToken();

            //Assert
            Assert.AreNotEqual(token1,token2);
            Assert.AreEqual(Token.X,token1);
            Assert.AreEqual(Token.O,token2);
        }

        [Test]
        public void Should_return_player1_when_game_did_not_start()
        {
            //Act
            var game = new TicTacToeGame(3, Token.X);
            Player currentPlayer = game.GetCurrentPlayer();
            
            //Assert
            Assert.AreEqual(Player.Player1, currentPlayer);
        }

        [TestCase(Token.X, Player.Player2)]
        [TestCase(Token.O, Player.Player2)]
        public void Should_return_player2_when_player1_did_play(Token startToken, Player expectedResult)
        {
            //Act
            var game = new TicTacToeGame(3, startToken);
            game.Play(0, 0);
            Player currentPlayer = game.GetCurrentPlayer();

            //Assert
            Assert.AreEqual(expectedResult, currentPlayer);
        }

        [Test]
        public void Should_return_win_when_3_in_a_row()
        {
            var game = new TicTacToeGame(3, Token.X);
            game.Play(0, 0);//player1
            game.Play(1,1 );//player2
            game.Play(0, 1);//player1
            game.Play(1, 2);//player2
            game.Play(0, 2);//player1

            bool isWinner = game.IsWinner(Player.Player1);
            Assert.IsTrue(isWinner);
        }
        [Test]
        public void Should_return_loose_when_not_3_in_a_row()
        {
            var game = new TicTacToeGame(3, Token.X);
            game.Play(0, 0);//player1
            game.Play(0, 1);//player2
            game.Play(0, 2);//player1

            bool isWinner = game.IsWinner(Player.Player1);
            Assert.IsFalse(isWinner);
        }

    }
}