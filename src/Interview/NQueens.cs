using System;
using System.Collections.Generic;
using Xunit;

namespace Interview
{
    public class NQueens
    {
        [Fact]
        public void Test()
        {
            var result = new NQueens().SolveNQueens(4);
            foreach(var c in result)
            {
                foreach(var line in c)
                {
                    Console.WriteLine(line);
                }
            }
        }
        
        public IList<IList<string>> SolveNQueens(int n)
        {
            var matrix = new char[n,n];
            for (var i = 0; i < n; i++)
            {
                for (var j = 0; j < n; j++)
                {
                    matrix[i, j] = '.';
                }
            }

            var result = new List<IList<string>>();
            DFS(matrix, n, 0, result);
            return result;
        }

        private void DFS(char[,] matrix, int n, int column, List<IList<string>> result)
        {
            if (column == n)
            {
                var solution = new List<string>();
                for (var i = 0; i < n; i++)
                {
                    var line = "";
                    for (var j = 0; j < n; j++)
                    {
                        line += matrix[i, j];
                    }
                    solution.Add(line);
                }
                result.Add(solution);
                return;
            }

            for (var row = 0; row < n; row++)
            {
                if (IsSafe(matrix, n, row, column))
                {
                    matrix[row,column] = 'Q';
                    DFS(matrix, n, column + 1, result);
                    matrix[row, column] = '.';
                }
            }
        }

        private bool IsSafe(char[,] matrix, int n, int x, int y)
        {
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    if (matrix[i,j] == 'Q' && (x + j == y + i || x + y == i + j || x == i))
                        return false;
                }
            }

            return true;
        }
    }
}
