// Form1.cs
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Coursova
{
    public partial class Form1 : Form
    {
        private GameBoard gameBoard;

        public Form1()
        {
            InitializeComponent();
            InitializeGame();
        }
        
        private void SetupInitialUI()
        {
            labelMoves.Visible = false;
            buttonShuffle.Visible = true;
            buttonSolve.Visible = true;
            button9.Visible = true;
            button13.Visible = true;
        }

        private void OnGameStarted()
        {
            UpdateMoveCount(0);
            button9.Enabled = false;
            buttonSolve.Enabled = false;
            buttonShuffle.Enabled = false;
            button13.Visible = true;
            labelMoves.Visible = true;
            button12.Enabled = false;
        }
        private void InitializeGame()
        {
            Button[,] buttons = new Button[3, 3]
            {
            { button1, button2, button3 },
            { button4, button5, button6 },
            { button7, button8, button10 }
            };

            SetupInitialUI();
            gameBoard = new GameBoard();
            gameBoard.Initialize(buttons);
            gameBoard.MoveCountChanged += UpdateMoveCount;
            gameBoard.PuzzleSolved += OnPuzzleSolved;
            gameBoard.GameStarted += OnGameStarted;
            button9.Click += (s, e) => gameBoard.StartGame(this);

        }

        private void SetTilesStatus(bool status)
        {
            button1.Enabled = status;
            button2.Enabled = status;
            button3.Enabled = status;
            button4.Enabled = status;
            button5.Enabled = status;
            button6.Enabled = status;
            button7.Enabled = status;
            button8.Enabled = status;
            button10.Enabled = status;
        }


        private void UpdateMoveCount(int count)
        {
            labelMoves.Text = $"Moves: {count}";
        }

        private void OnPuzzleSolved()
        {
            MessageBox.Show($"Congratulations! You passed the puzzle in {gameBoard.GetCurrentState().G} moves.");
        }

        private void buttonShuffle_Click(object sender, EventArgs e)
        {
            gameBoard.Shuffle();
        }

        public void EnableStopButton(bool status)
        {
            this.StopButton.Visible = status;
        }
        
        private async void buttonSolve_Click(object sender, EventArgs e)
        {
            SetTilesStatus(false);
            gameBoard.MoveCount = 0;
            labelMoves.Visible = true;
            buttonShuffle.Enabled = false;
            buttonSolve.Enabled = false;
            button9.Enabled = false;
            button12.Enabled = false;
            button13.Enabled = false;
            var initialState = gameBoard.GetCurrentState();
            var solution = await Task.Run(() => AStarSolver.Solve(initialState));


            if (solution != null)
            {
                await gameBoard.ApplySolution(solution);
                MessageBox.Show($"Solution found in {solution.Count - 1} moves!");

                AlgorithmLogger.LogAStarResult(initialState.Board, solution.Count - 1, AStarSolver.ComparisonCount);

                button9.Enabled = true;
                buttonShuffle.Enabled = true;
                buttonSolve.Enabled = true;
                button12.Enabled = true;
                button13.Enabled = true;
                StopButton.Visible = false;
                labelMoves.Visible = false;
                gameBoard.MoveCount = 0;
                SetTilesStatus(true);
            }
            else
            {
                MessageBox.Show("No solution found!");
            }
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult iExit = MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (iExit == DialogResult.No)
            {
                e.Cancel = true;
            }
        }

        private void button13_Click(object sender, EventArgs e)
        {
            DialogResult iExit = MessageBox.Show("Are you sure you want to exit?", "Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (iExit == DialogResult.Yes)
            {
                Application.ExitThread();
            }
        }
        private void button10_Click(object sender, EventArgs e)
        {
        }
        private void button11_Click(object sender, EventArgs e)
        {
        }
        private async void button12_Click(object sender, EventArgs e)
        {
            SetTilesStatus(false);
            gameBoard.MoveCount = 0;
            labelMoves.Visible = true;
            buttonShuffle.Enabled = false;
            buttonSolve.Enabled = false;
            button9.Enabled = false;
            button12.Enabled = false;
            button13.Enabled = false;
            StopButton.Visible = false;

            var initialState = gameBoard.GetCurrentState();
            var solver = new RBFSSolver();

            var solution = await Task.Run(() => solver.Solve(initialState));

            if (solution != null && solution.Count > 0)
            {
                await AnimateSolution(solution);
                MessageBox.Show($"RBFS solution found in {solution.Count - 1} moves!");
                AlgorithmLogger.LogRBFSResult(initialState.Board, solution.Count - 1, solver.ComparisonCount);
                gameBoard.Shuffle();
            }
            else
            {
                MessageBox.Show("No solution found with RBFS!");
            }

            button9.Enabled = true;
            buttonShuffle.Enabled = true;
            buttonSolve.Enabled = true;
            button12.Enabled = true;
            button13.Enabled = true;
            StopButton.Visible = false;
            labelMoves.Visible = false;
            gameBoard.MoveCount = 0;
            SetTilesStatus(true);
        }
        private async Task AnimateSolution(List<PuzzleState> solution)
        {
            foreach (var state in solution.Skip(1))
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        Button[,] buttons = new Button[3, 3]
                        {
                    { button1, button2, button3 },
                    { button4, button5, button6 },
                    { button7, button8, button10 }
                        };

                        buttons[i, j].Text = state.Board[i, j];
                    }
                }

                gameBoard.MoveCount++;
                await Task.Delay(300);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button9_Click(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        public void StopButton_Click(object sender, EventArgs e)
        {
            buttonShuffle.Enabled = true;
            buttonSolve.Enabled = true;
            button9.Enabled = true;
            button12.Enabled = true;
            button13.Enabled = true;
            StopButton.Visible = false;
            labelMoves.Visible = false;
            gameBoard.MoveCount = 0;
            SetTilesStatus(true);
        }
    }
}