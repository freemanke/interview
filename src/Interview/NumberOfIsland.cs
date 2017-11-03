using System;
using Xunit;

namespace Interview
{
    public class NumberOfIsland
    {
        [Fact]
        public void Test_4_4()
        {
            var matrix = new[,]
            {
                {1, 1, 0, 0} ,
                {1, 1, 0, 0},
                {0, 0, 0, 0},
                {0, 1, 0, 1}
            };
            Assert.Equal(3, new NumberOfIsland().CountIsland(matrix, 4, 4));
        }

        [Fact]
        public void Test_2_4()
        {
           var matrix = new[,]
           {
                {1, 1, 0, 0} ,
                {1, 1, 0, 0},
            };

            Assert.Equal(1, new NumberOfIsland().CountIsland(matrix, 2, 4));
        }

        public int CountIsland(int[,] matrix, int row, int col)
        {
            var count = 0;
            var visited = new bool[row, col];
            for (var i = 0; i < row; i++)
            {
                for (var j = 0; j < col; j++)
                {
                    if (matrix[i, j] == 1 && !visited[i, j])
                    {
                        DFS(matrix, row, col, visited, i, j);
                        count++;
                    }
                }
            }

            return count;
        }

        private void DFS(int[,] matrix, int totalRow, int totalColums, bool[,] visited, int row, int col)
        {
            var rows = new[] { -1, -1, -1, 0, 1, 1, 1, 0 };
            var cols = new[] { -1, 0, 1, 1, 1, 0, -1, -1 };
            visited[row, col] = true;

            for (var i = 0; i < 8; i++)
            {
                if (IsSafe(matrix, totalRow, totalColums, visited, row + rows[i], col + cols[i]))
                {
                    DFS(matrix, totalRow, totalColums, visited, row + rows[i], col + cols[i]);
                }
            }
        }

        private bool IsSafe(int[,] matrix, int totalRow, int totalColumn, bool[,] visited, int row, int col)
        {
            return row >= 0 && col >= 0
                && row < totalRow && col < totalColumn
                && matrix[row, col] == 1 && !visited[row, col];
        }
    }
}
