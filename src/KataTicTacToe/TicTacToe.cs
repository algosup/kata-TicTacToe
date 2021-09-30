using System;

namespace KataTicTacToe
{

        public enum Token
        {
            Empty,
            X,
            O
            
        }

        public class TicTacToeGame
        {
            private int _size;
            private Token _token;
            private Token[,] _grid;

            public TicTacToeGame(int size, Token token)
            {
                _size = size;
                _token = token;
                _grid = new Token[size,size];
            }

        public bool Play(int x, int y)
        {
            var isplacable  = _grid[x, y] == Token.Empty;
            if (isplacable) 
                _grid[x, y] = _token;
            return isplacable;


        }
    }

}

