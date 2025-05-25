using System.Text;

namespace Coursova
{
    public static class AlgorithmLogger
    {
        private static string aStarLogFile = "AStar_last_result.txt";
        private static string rbfsLogFile = "RBFS_last_result.txt";

        public static void LogAStarResult(string[,] initialState, int moves, int comparisons, List<string[,]> solution = null)
        {
            LogToFile(aStarLogFile, "A* (A-Star)", initialState, moves, comparisons, solution);
        }

        public static void LogRBFSResult(string[,] initialState, int moves, int comparisons, List<string[,]> solution = null)
        {
            LogToFile(rbfsLogFile, "RBFS (Recursive Best-First Search)", initialState, moves, comparisons, solution);
        }

        private static void LogToFile(string fileName, string algorithmName, string[,] initialState, int moves, int comparisons, List<string[,]> solution)
        {
            try
            {
                StringBuilder logEntry = new StringBuilder();

                logEntry.AppendLine(algorithmName);
                logEntry.AppendLine();

                logEntry.AppendLine("Initial state:");
                for (int i = 0; i < 3; i++)
                {
                    logEntry.Append("{ ");
                    for (int j = 0; j < 3; j++)
                    {
                        string value = string.IsNullOrEmpty(initialState[i, j]) ? "\"\"" : initialState[i, j];
                        logEntry.Append(value);
                        if (j < 2) logEntry.Append(" ");
                    }
                    logEntry.AppendLine(" }");
                }
                logEntry.AppendLine();

                logEntry.AppendLine($"Number of moves: {moves}");
                logEntry.AppendLine($"Number of comparisons: {comparisons}");
                logEntry.AppendLine();

                File.WriteAllText(fileName, logEntry.ToString(), Encoding.UTF8);
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"Error logging to file: {ex.Message}");
            }
        }
    }
}
