using System;
using System.Windows;
using System.Windows.Controls;

namespace TicTacToe
{
    public partial class MainWindow : Window
    {
        private TicTacToe game;

        public MainWindow()
        {
            InitializeComponent();

            // Initialize the game
            game = new TicTacToe();
            game.GameEnded += OnGameEnded;

            // Set button click events
            Button00.Click += OnButtonClick;
            Button01.Click += OnButtonClick;
            Button02.Click += OnButtonClick;
            Button10.Click += OnButtonClick;
            Button11.Click += OnButtonClick;
            Button12.Click += OnButtonClick;
            Button20.Click += OnButtonClick;
            Button21.Click += OnButtonClick;
            Button22.Click += OnButtonClick;
        }

        private void OnButtonClick(object sender, RoutedEventArgs e)
        {
            // Get the button that was clicked
            Button button = (Button)sender;

            // Get the row and column of the button
            int row = Grid.GetRow(button);
            int column = Grid.GetColumn(button);

            try
            {
                // Make a move in the game
                game.MakeMove(row, column);

                // Update the button content
                button.Content = game.Board[row, column];

                // Update the player text
                PlayerText.Text = game.CurrentPlayer.ToString();

                // Check if the game has ended
                if (game.GameOver)
                {
                    // Show the end panel
                    EndPanel.Visibility = Visibility.Visible;

                    // Set the end text
                    if (game.Winner != null)
                    {
                        EndText.Text = game.Winner + " wins!";
                    }
                    else
                    {
                        EndText.Text = "Tie game!";
                    }
                }
            }
            catch (Exception ex)
            {
                // Show an error message
                MessageBox.Show(ex.Message);
            }
        }

        private void OnGameEnded(object sender, EventArgs e)
        {
            // Show the end panel
            EndPanel.Visibility = Visibility.Visible;

            // Set the end text
            if (game.Winner != null)
            {
                EndText.Text = game.Winner + " wins!";
            }
            else
            {
                EndText.Text = "Tie game!";
            }
        }

        private void NewGameButton_Click(object sender, RoutedEventArgs e)
        {
            // Reset the game
            game.Reset();

            // Reset the button content
            Button00.Content = "";
            Button01.Content = "";
            Button02.Content = "";
            Button10.Content = "";
            Button11.Content = "";
            Button12.Content = "";
            Button20.Content = "";
            Button21.Content = "";
            Button22.Content = "";

            // Update the player text
            PlayerText.Text = game.CurrentPlayer.ToString();

            // Hide the end panel
            EndPanel.Visibility = Visibility.Collapsed;
        }
    }
}

