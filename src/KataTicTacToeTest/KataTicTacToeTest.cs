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

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        public void Should_return_win_when_3_in_a_row(int rowNumber)
        {
            var size = 3;
            var player2RowNumber = (rowNumber + 1)% size;
            var game = new TicTacToeGame(size, Token.X);
            game.Play(rowNumber, 0);//player1
            game.Play(player2RowNumber, 1 );//player2
            game.Play(rowNumber, 1);//player1
            game.Play(player2RowNumber, 2);//player2
            game.Play(rowNumber, 2);//player1

            bool isWinner = game.IsWin();
            Assert.IsTrue(isWinner);
        }

        [TestCase(0)]
        [TestCase(1)]
        [TestCase(2)]
        public void Should_return_win_when_3_in_a_column(int columnNumber)
        {
            var size = 3;
            var player2ColumnNumber = (columnNumber + 1) % size;
            var game = new TicTacToeGame(size, Token.X);
            game.Play(0, columnNumber);//player1
            game.Play(1, player2ColumnNumber);//player2
            game.Play(1, columnNumber);//player1
            game.Play(2, player2ColumnNumber);//player2
            game.Play(2, columnNumber);//player1

            bool isWinner = game.IsWin();
            Assert.IsTrue(isWinner);
        }

        [Test]
        public void Should_return_loose_when_not_3_in_a_row()
        {
            var game = new TicTacToeGame(3, Token.X);
            game.Play(0, 0);//player1
            game.Play(0, 1);//player2
            game.Play(0, 2);//player1

            bool isWinner = game.IsWin();
            Assert.IsFalse(isWinner);
        }

        [Test]
        public void Should_return_win_when_3_in_a_diagonal()
        {
            var game = new TicTacToeGame(3, Token.X);
            game.Play(0, 0);//player1
            game.Play(0, 1);//player2
            game.Play(1, 1);//player1
            game.Play(0, 2);//player2
            game.Play(2, 2);//player1

            bool isWinner = game.IsWin();
            Assert.IsTrue(isWinner);
        }
        [Test]
        public void Should_return_loose_when_not_3_in_a_diagonal()
        {
            var game = new TicTacToeGame(3, Token.X);
            game.Play(0, 0);//player1

            bool isWinner = game.IsWin();
            Assert.IsFalse(isWinner);
        }
        [Test]
        public void Should_return_win_when_3_in_a_antidiagonal()
        {
            var game = new TicTacToeGame(3, Token.X);
            game.Play(0, 2);//player1
            game.Play(0, 0);//player2
            game.Play(1, 1);//player1
            game.Play(0, 1);//player2
            game.Play(2, 0);//player1

            bool isWinner = game.IsWin();
            Assert.IsTrue(isWinner);
        }

    }
}