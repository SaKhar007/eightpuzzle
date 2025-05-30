﻿namespace Coursova
{
    public class GameBoard
    {
        private Button[,] board = new Button[3, 3];
        private Point emptySpot;
        private bool isPlaying = false;
        public event Action GameStarted;

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


        public void SetTilesClickable(bool clickable)
        {
            foreach (Button btn in board)
            {
                btn.Enabled = clickable;
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
            SetTilesClickable(true);
            foreach (Button btn in board)
            {
                btn.Click += Tile_Click;
            }
            Shuffle();
        }

        public void StartGame(Form1 form1)
        {
            isPlaying = true;
            SetTilesClickable(true);
            moveCount = 0;
            GameStarted?.Invoke();
            form1.EnableStopButton(true);
        }
        
        public void testSet() // mojno v shuffle vstavit kogda nado setnut` shablon (no exception handlers for this command because it is not allowed for average user)
        {
            board[0, 0].Text = "5";
            board[0, 1].Text = "2";
            board[0, 2].Text = "4";
            board[1, 0].Text = "3";
            board[1, 1].Text = "6";
            board[1, 2].Text = "1";
            board[2, 0].Text = "8";
            board[2, 1].Text = string.Empty;
            board[2, 2].Text = "7";
        }
        public void Shuffle()
        {
            List<string> numbers = new List<string>() { "1", "2", "3", "4", "5", "6", "7", "8", string.Empty };
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
                    if (string.IsNullOrEmpty(numbers[index]))
                    {
                        emptySpot = new Point(i, j);
                        board[i, j].Text = string.Empty; 
                    }
                    index++;
                }
            }
            moveCount = 0;
        }

        private bool IsSolvable(List<string> numbers) 
        {
            int inversionCount = 0;
            for (int i = 0; i < numbers.Count - 1; i++)
            {
                if (string.IsNullOrWhiteSpace(numbers[i])) continue;

                for (int j = i + 1; j < numbers.Count; j++)
                {
                    if (string.IsNullOrWhiteSpace(numbers[j])) continue;

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
                        if (!string.IsNullOrEmpty(board[i, j].Text))
                            return false;
                    }
                    else
                    {
                        if (board[i, j].Text != expected.ToString())
                            return false;
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
                    if (string.IsNullOrEmpty(currentBoard[i, j]))
                    {
                        empty = new Point(i, j);
                    }
                }
            }
            return new PuzzleState(currentBoard, empty, MoveCount);
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
                        if (string.IsNullOrEmpty(state.Board[i, j]))
                        {
                            emptySpot = new Point(i, j);
                        }
                    }
                }
                MoveCount++;
                await Task.Delay(300);
            }
        }
        
    }
}