// PuzzleState.cs
namespace Coursova
{
    public class PuzzleState
    {
        public string[,] Board { get; }
        public Point EmptyPosition { get; }
        public int G { get; } // cost from start
        public int H { get; } // heuristic
        public int F => G + H;
        public PuzzleState Parent { get; }

        public PuzzleState(string[,] board, Point emptyPos, int g, PuzzleState parent = null)
        {
            Board = (string[,])board.Clone();
            EmptyPosition = emptyPos;
            G = g;
            Parent = parent;
            H = CalculateManhattanDistance();
        }

        private int CalculateManhattanDistance()
        {
            int distance = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (!string.IsNullOrEmpty(Board[i, j]))
                    {
                        int value = int.Parse(Board[i, j]);
                        int targetX = (value - 1) / 3;
                        int targetY = (value - 1) % 3;
                        distance += Math.Abs(i - targetX) + Math.Abs(j - targetY);
                    }
                }
            }
            return distance;
        }

        public bool IsGoal()
        {
            int expected = 1;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (i == 2 && j == 2)
                    {
                        if (Board[i, j] != "") return false;
                    }
                    else
                    {
                        if (Board[i, j] != expected.ToString()) return false;
                        expected++;
                    }
                }
            }
            return true;
        }

        public List<PuzzleState> GetNeighbors()
        {
            var neighbors = new List<PuzzleState>();
            int[] dx = { -1, 1, 0, 0 };
            int[] dy = { 0, 0, -1, 1 };

            for (int k = 0; k < 4; k++)
            {
                int x = EmptyPosition.X + dx[k];
                int y = EmptyPosition.Y + dy[k];

                if (x >= 0 && x < 3 && y >= 0 && y < 3)
                {
                    var newBoard = (string[,])Board.Clone();
                    newBoard[EmptyPosition.X, EmptyPosition.Y] = newBoard[x, y];
                    newBoard[x, y] = "";
                    neighbors.Add(new PuzzleState(newBoard, new Point(x, y), G + 1, this));
                }
            }
            return neighbors;
        }

        public override bool Equals(object obj)
        {
            if (obj is PuzzleState other)
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        if (Board[i, j] != other.Board[i, j])
                            return false;
                    }
                }
                return true;
            }
            return false;
        }

        public override int GetHashCode()
        {
            int hash = 17;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    hash = hash * 31 + (Board[i, j]?.GetHashCode() ?? 0);
                }
            }
            return hash;
        }
    }
}