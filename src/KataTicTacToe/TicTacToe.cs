
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
        public int _size { get; }
        private Token _currentToken;
        private Token FirstToken { get; }
        public Token[,] Grid { get; }



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

        public bool IsWin()
        {

            Token previousToken = GetOppositeToken(_currentToken);
            var result = false;
            for (var i = 0; i < _size; i++)
            {
                result |= CheckRow(previousToken, i);
                result |= CheckColumn(previousToken, i);
                
            }
            result |= CheckDiagonal(previousToken);
            result |= CheckAntiDiagonal(previousToken);

            return result;
        }

        private bool CheckColumn(Token token, int columnNumber)
        {
            for (var i = 0; i < _size; i++)
            {
                if (Grid[i, columnNumber] != token)
                    return false;
            }

            return true;
        }

        private bool CheckRow(Token token, int rowNumber)
        {
            for (var i = 0; i < _size; i++)
            {
                if (Grid[rowNumber, i] != token)
                    return false;
            }

            return true;
        }

        private bool CheckDiagonal(Token token)
        {
            for (var i = 0; i < _size; i++)
            {
                if (Grid[i, i] != token)
                    return false;
            }

            return true;
        }

        private static Token GetOppositeToken(Token token)
        {
            return token == Token.X ? Token.O : Token.X;
        }
        private bool CheckAntiDiagonal(Token token)
        {
            for (var i = 0; i < _size; i++)
            {
                if (Grid[i, _size - 1 - i] != token)
                    return false;
            }

            return true;
        }


        // Human-machine interface
        public void Display()
        {
            Console.Out.WriteLine();
            for (int i = 0; i < _size; i++)
            {
                string line = "";
                for (int j = 0; j < _size; j++)
                {
                    line += Grid[j, i].ToString();
                }

                Console.Out.WriteLine(line);
            }
        }

        
    }

}

