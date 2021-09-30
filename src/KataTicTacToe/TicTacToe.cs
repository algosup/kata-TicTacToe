using System;

namespace KataTicTacToe
{
    public enum Player
    {
        Player1,
        Player2
    }

    public enum Token
    {
        Empty,
        X,
        O
    }

    public class TicTacToeGame
    {
        private int _size;
        private Token _currentToken;
        private Token FirstToken { get; }
        private Token[,] Grid { get; }

        public TicTacToeGame(int size, Token firstToken)
        {
            _size = size;
            FirstToken = firstToken;
            _currentToken = firstToken;
            Grid = new Token[size, size];
        }

        public bool Play(int x, int y)
        {
            var canPlay = Grid[x, y] == Token.Empty;
            if (canPlay)
            {
                Grid[x, y] = _currentToken;
                AlternateToken();
            }

            return canPlay;
        }

        private void AlternateToken()
        {
            _currentToken = _currentToken == Token.X ? Token.O : Token.X;
        }

        public Token GetCurrentToken()
        {
            return _currentToken;
        }

        public Player GetCurrentPlayer()
        {
            return _currentToken == FirstToken ? Player.Player1 : Player.Player2;
        }
    }

}

