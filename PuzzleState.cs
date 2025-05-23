// PuzzleState.cs
using System.Text;

namespace Coursova
{
    public class PuzzleState
    {
        private static readonly HeuristicCalculator heuristicCalculator = new ManhattanHeuristic();
        public string[,] Board { get; }
        public Point EmptyPosition { get; }
        public int G { get; } // cost from start
        public int H { get; } // heuristic
        public int F => G + H;


        public PuzzleState Parent { get; }

        private static readonly string[,] GoalState = new string[3, 3]
    {
        { "1", "2", "3" },
        { "4", "5", "6" },
        { "7", "8", "" }
    };
        public PuzzleState(string[,] board, Point emptyPos, int g, PuzzleState parent = null)
        {
            Board = (string[,])board.Clone();
            EmptyPosition = emptyPos;
            G = g;
            Parent = parent;
            H = heuristicCalculator.CalculateHeuristic(this.Board);
        }

        public bool IsGoal()
        {
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (Board[i, j] != GoalState[i, j])
                        return false;
                }
            }
            return true;
        }

        public int UpdatedF { get; set; }
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

        public string GetKey()
        {
            var sb = new StringBuilder();
            for (int i = 0; i < 3; i++)
                for (int j = 0; j < 3; j++)
                    sb.Append(Board[i, j] ?? " ");
            return sb.ToString();
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