using System;
using Xunit;

namespace Interview
{
    public class NumberOfIsland
    {
        public int NumIslands(char[,] grid)
        {
            var count = 0;
            var rows = grid.GetLength(0);
            if (rows == 0) return 0;

            var cols = grid.Length / rows;
            var visited = new bool[rows, cols];
            for (var i = 0; i < rows; i++)
            {
                for (var j = 0; j < cols; j++)
                {
                    if (grid[i, j] == '1' && !visited[i, j])
                    {
                        DFS(grid, rows, cols, visited, i, j);
                        count++;
                    }
                }
            }

            return count;
        }

        private void DFS(char[,] matrix, int rows, int cols, bool[,] visited, int row, int col)
        {
            visited[row, col] = true;

            var rs = new[] { -1, 0, 1, 0 };
            var cs = new[] { 0, 1, 0, -1 };
            for (var i = 0; i < 4; i++)
            {
                if (IsSafe(matrix, rows, cols, visited, row + rs[i], col + cs[i]))
                {
                    DFS(matrix, rows, cols, visited, row + rs[i], col + cs[i]);
                }
            }
        }

        private bool IsSafe(char[,] matrix, int totalRow, int totalColumn, bool[,] visited, int row, int col)
        {
            return row >= 0
                && col >= 0
                && row < totalRow && col < totalColumn
                && matrix[row, col] == '1'
                && !visited[row, col];
        }

        [Fact]
        public void Test_4_4()
        {
            var matrix = new[,]
            {
                {'1', '1', '0', '0'},
                {'1', '1', '0', '1'},
                {'0', '0', '0', '0'},
                {'0', '1', '0', '1'}
            };
            Assert.Equal(4, new NumberOfIsland().NumIslands(matrix));
        }

        [Fact]
        public void Test_2_4()
        {
            var matrix = new[,]
            {
                {'1', '1', '0', '0'},
                {'1', '1', '0', '0'},
            };

            Assert.Equal(1, new NumberOfIsland().NumIslands(matrix));
        }
    }
}
