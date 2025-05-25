namespace Coursova
{
    public static class AStarSolver
    {
        public static int ComparisonCount { get; private set; }
        public static List<PuzzleState> Solve(PuzzleState initialState)
        {
            ComparisonCount = 0;
            var openSet = new HashSet<PuzzleState> { initialState };
            var closedSet = new HashSet<PuzzleState>();
            var cameFrom = new Dictionary<PuzzleState, PuzzleState>();
            var gScore = new Dictionary<PuzzleState, int> { [initialState] = 0 };
            var fScore = new Dictionary<PuzzleState, int> { [initialState] = initialState.H };

            while (openSet.Count > 0)
            {
                ComparisonCount++;
                var current = openSet.OrderBy(x => fScore[x]).First();

                if (current.IsGoal())
                {
                    return ReconstructPath(current);
                }

                openSet.Remove(current);
                closedSet.Add(current);

                foreach (var neighbor in current.GetNeighbors())
                {
                    ComparisonCount++;
                    if (closedSet.Contains(neighbor))
                        continue;

                    int tentativeGScore = gScore[current] + 1;

                    if (!openSet.Contains(neighbor) || tentativeGScore < gScore[neighbor])
                    {
                        cameFrom[neighbor] = current;
                        gScore[neighbor] = tentativeGScore;
                        fScore[neighbor] = tentativeGScore + neighbor.H;

                        if (!openSet.Contains(neighbor))
                        {
                            openSet.Add(neighbor);
                        }
                    }
                }
            }

            return null; 
        }

        private static List<PuzzleState> ReconstructPath(PuzzleState current)
        {
            var path = new List<PuzzleState>();
            while (current != null)
            {
                path.Add(current);
                current = current.Parent;
            }
            path.Reverse();
            return path;
        }
    }
}