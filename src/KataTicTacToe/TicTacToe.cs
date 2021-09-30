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

        public bool IsWinner(Player player)
        {
            var result = true;
            Token playerToken;
            if (player == Player.Player1)
                playerToken = FirstToken;
            else
                playerToken = GetOppositeToken(FirstToken);

            for (var i = 0; i < _size; i++)
            {
                    result = result && (playerToken == Grid[0, i]);
            }

            return result;
        }

        private Token GetOppositeToken(Token token)
        {
            if (token == Token.X)
                return Token.O;
            else
                return Token.X;
        }
    }

}

