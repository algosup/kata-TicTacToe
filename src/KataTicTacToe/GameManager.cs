using System;

namespace KataTicTacToe
{
    public class GameManager
    {
        private TicTacToeGame _game;

        public (int, int) ParseInput(string line)
        {
            string[] split = line.Split(',');
            if (int.TryParse(split[0], out int x))
            {
                if (split.Length == 2 && int.TryParse(split[1], out int y))
                {
                    return (x, y);
                }
            }

            throw new Exception("Input is incorrect");
        }

        public TicTacToeGame InitGame(int size, Token token)
        {
            _game = new TicTacToeGame(size, token);
            return _game;
        }

        public void ReadInput(string input)
        {
            (int, int) values = ParseInput(input);
            _game.Play(values.Item1, values.Item2);
        }

        public string ShowLine(int rowNumber)
        {
            string result = string.Empty;
            for (int i = 0; i < _game._size; i++)
            {
                result += _game.Grid[i, 0].ToString();
            }
            return "X, O, X";
        }
    }
}