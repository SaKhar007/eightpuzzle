using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coursova
{

    public class ManhattanHeuristic : HeuristicCalculator
    {
        public override int CalculateHeuristic(string[,] board)
        {
            int distance = 0;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (!string.IsNullOrEmpty(board[i, j]) && int.TryParse(board[i, j], out int value))
                    {
                        var targetPos = FindTargetPosition(value);
                        distance += Math.Abs(i - targetPos.X) + Math.Abs(j - targetPos.Y);
                    }
                }
            }
            return distance;
        }
    }
}



