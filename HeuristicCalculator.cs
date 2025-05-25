namespace Coursova
{
    public abstract class HeuristicCalculator
    {
        public abstract int CalculateHeuristic(string[,] board);

        protected Point FindTargetPosition(int value)
        {
            if (value < 1 || value > 8) return new Point(2, 2);
            return new Point((value - 1) / 3, (value - 1) % 3);
        }
    }
}

