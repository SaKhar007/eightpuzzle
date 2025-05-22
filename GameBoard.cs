// GameBoard.cs
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Coursova
{
    public class GameBoard
    {
        private Button[,] board = new Button[3, 3];
        private Point emptySpot;

        private int moveCount = 0;
        public int MoveCount
        {
            get => moveCount;
            set
            {
                moveCount = value;
                MoveCountChanged?.Invoke(moveCount);
            }
        }


        public void IncrementMoveCount()
        {
            moveCount++;
            MoveCountChanged?.Invoke(moveCount);
        }

        public event Action<int> MoveCountChanged;
        public event Action PuzzleSolved;

        public void Initialize(Button[,] buttons)
        {
            board = buttons;
            foreach (Button btn in board)
            {
                btn.Click += Tile_Click;
            }
        }

        public void Shuffle()
        {
            List<string> numbers = new List<string>() { "1", "2", "3", "4", "5", "6", "7", "8", "" };
            Random rand = new Random();

            do
            {
                numbers = numbers.OrderBy(x => rand.Next()).ToList();
            } while (!IsSolvable(numbers));

            int index = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    board[i, j].Text = numbers[index];
                    if (numbers[index] == "")
                    {
                        emptySpot = new Point(i, j);
                    }
                    index++;
                }
            }

            moveCount = 0;
            MoveCountChanged?.Invoke(moveCount);
        }

        private bool IsSolvable(List<string> numbers)
        {
            int inversionCount = 0;
            for (int i = 0; i < numbers.Count - 1; i++)
            {
                if (numbers[i] == "") continue;

                for (int j = i + 1; j < numbers.Count; j++)
                {
                    if (numbers[j] == "") continue;

                    if (int.Parse(numbers[i]) > int.Parse(numbers[j]))
                    {
                        inversionCount++;
                    }
                }
            }

            return inversionCount % 2 == 0;
        }

        private void Tile_Click(object sender, EventArgs e)
        {
            Button clicked = sender as Button;
            Point clickedPos = FindButtonPosition(clicked);

            if (IsAdjacent(clickedPos, emptySpot))
            {
                board[emptySpot.X, emptySpot.Y].Text = clicked.Text;
                clicked.Text = "";
                emptySpot = clickedPos;

                moveCount++;
                MoveCountChanged?.Invoke(moveCount);

                if (IsPuzzleSolved())
                {
                    PuzzleSolved?.Invoke();
                }
            }
        }

        private Point FindButtonPosition(Button btn)
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i, j] == btn)
                    {
                        return new Point(i, j);
                    }
                }
            }
            return Point.Empty;
        }

        private bool IsAdjacent(Point a, Point b)
        {
            return (Math.Abs(a.X - b.X) == 1 && a.Y == b.Y) ||
                   (Math.Abs(a.Y - b.Y) == 1 && a.X == b.X);
        }

        private bool IsPuzzleSolved()
        {
            int expected = 1;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (i == 2 && j == 2)
                    {
                        if (board[i, j].Text != "") return false;
                    }
                    else
                    {
                        if (board[i, j].Text != expected.ToString()) return false;
                        expected++;
                    }
                }
            }
            return true;
        }

        public PuzzleState GetCurrentState()
        {
            string[,] currentBoard = new string[3, 3];
            Point empty = Point.Empty;

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    currentBoard[i, j] = board[i, j].Text;
                    if (currentBoard[i, j] == "")
                    {
                        empty = new Point(i, j);
                    }
                }
            }

            return new PuzzleState(currentBoard, empty, 0);
        }

        public async Task ApplySolution(List<PuzzleState> solution)
        {
            foreach (var state in solution.Skip(1))
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        board[i, j].Text = state.Board[i, j];
                    }
                }
                emptySpot = state.EmptyPosition;
                moveCount++;
                MoveCountChanged?.Invoke(moveCount);
                await Task.Delay(300);
            }
        }
    }
}