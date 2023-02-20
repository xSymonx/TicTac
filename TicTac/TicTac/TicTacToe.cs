using System;
using System.Numerics;

namespace TicTacToe
{
    public class TicTacToe
    {
        public string[,] Board { get; private set; }
        public Player CurrentPlayer { get; private set; }
        public bool GameOver { get; private set; }
        public string Winner { get; private set; }

        public event EventHandler GameEnded;

        public TicTacToe()
        {
            // Initialize the board
            Board = new string[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Board[i, j] = "";
                }
            }

            // Set the current player
            CurrentPlayer = Player.X;

            // Reset the game
            Reset();
        }

        public void MakeMove(int row, int column)
        {
            // Check if the game is over
            if (GameOver)
            {
                throw new InvalidOperationException("The game is over.");
            }

            // Check if the field is already occupied
            if (Board[row, column] != "")
            {
                throw new InvalidOperationException("The field is already occupied.");
            }

            // Make the move
            Board[row, column] = CurrentPlayer.ToString();

            // Check if the game is
            // Check for a win
            if (CheckForWin())
            {
                GameOver = true;
                Winner = CurrentPlayer.ToString();
                OnGameEnded();
                return;
            }

            // Check for a tie
            if (CheckForTie())
            {
                GameOver = true;
                OnGameEnded();
                return;
            }

            // Switch to the next player
            if (CurrentPlayer == Player.X)
            {
                CurrentPlayer = Player.O;
            }
            else
            {
                CurrentPlayer = Player.X;
            }
        }

        public void Reset()
        {
            // Reset the board
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    Board[i, j] = "";
                }
            }

            // Reset the game state
            CurrentPlayer = Player.X;
            GameOver = false;
            Winner = null;
        }

        private bool CheckForWin()
        {
            // Check the rows
            for (int i = 0; i < 3; i++)
            {
                if (Board[i, 0] != "" && Board[i, 0] == Board[i, 1] && Board[i, 1] == Board[i, 2])
                {
                    return true;
                }
            }

            // Check the columns
            for (int i = 0; i < 3; i++)
            {
                if (Board[0, i] != "" && Board[0, i] == Board[1, i] && Board[1, i] == Board[2, i])
                {
                    return true;
                }
            }

            // Check the diagonals
            if (Board[0, 0] != "" && Board[0, 0] == Board[1, 1] && Board[1, 1] == Board[2, 2])
            {
                return true;
            }
            if (Board[0, 2] != "" && Board[0, 2] == Board[1, 1] && Board[1, 1] == Board[2, 0])
            {
                return true;
            }

            return false;
        }

        private bool CheckForTie()
        {
            // Check if all fields are occupied
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (Board[i, j] == "")
                    {
                        return false;
                    }
                }
            }

            return true;
        }

        protected virtual void OnGameEnded()
        {
            EventHandler handler = GameEnded;
            if (handler != null)
            {
                handler(this, EventArgs.Empty);
            }
        }
    }

    public enum Player
    {
        X,
        O
    }
}