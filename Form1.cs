// Form1.cs
using System;
using System.Collections.Generic;
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

        private void InitializeGame()
        {
            Button[,] buttons = new Button[3, 3]
            {
                { button1, button2, button3 },
                { button4, button5, button6 },
                { button7, button8, button10 }
            };

            gameBoard = new GameBoard();
            gameBoard.Initialize(buttons);
            gameBoard.MoveCountChanged += UpdateMoveCount;
            gameBoard.PuzzleSolved += OnPuzzleSolved;
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

        private async void buttonSolve_Click(object sender, EventArgs e)
        {
            gameBoard.MoveCount = 0;
            var initialState = gameBoard.GetCurrentState();
            var solution = await Task.Run(() => AStarSolver.Solve(initialState));

            if (solution != null)
            {
                await gameBoard.ApplySolution(solution);
                MessageBox.Show($"Solution found in {solution.Count - 1} moves!");
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
        private void button12_Click(object sender, EventArgs e)
        {
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}