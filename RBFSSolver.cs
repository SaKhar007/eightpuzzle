namespace Coursova
{
    public class RBFSSolver
    {
        private const int INFINITY = 999999;
        public int ComparisonCount { get; private set; }

        public List<PuzzleState> Solve(PuzzleState initialState)
        {
            ComparisonCount = 0;
            initialState.UpdatedF = initialState.F;
            var result = RBFS(initialState, INFINITY);
            return result.Path;
        }

        private RBFSResult RBFS(PuzzleState node, int fLimit)
        {
            ComparisonCount++;
            if (node.IsGoal())
            {
                return new RBFSResult { Path = ReconstructPath(node), FValue = node.F };
            }

            var successors = node.GetNeighbors();
            if (successors.Count == 0)
            {
                return new RBFSResult { Path = null, FValue = INFINITY };
            }

            foreach (var successor in successors)
            {
                successor.UpdatedF = Math.Max(successor.F, node.UpdatedF);
            }

            while (true)
            {
                successors = successors.OrderBy(s => s.UpdatedF).ToList();
                var best = successors[0];

                if (best.UpdatedF > fLimit)
                {
                    return new RBFSResult { Path = null, FValue = best.UpdatedF };
                }

                int alternative = successors.Count > 1 ? successors[1].UpdatedF : INFINITY;
                var result = RBFS(best, Math.Min(fLimit, alternative));

                best.UpdatedF = result.FValue;

                if (result.Path != null)
                {
                    return result;
                }
            }
        }

        private List<PuzzleState> ReconstructPath(PuzzleState current)
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

    public class RBFSResult
    {
        public List<PuzzleState> Path { get; set; }
        public int FValue { get; set; }
    }
}