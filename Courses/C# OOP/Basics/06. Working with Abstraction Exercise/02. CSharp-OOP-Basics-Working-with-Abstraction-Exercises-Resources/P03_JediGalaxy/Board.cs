namespace P03_JediGalaxy
{
    public class Board
    {
        private int[,] matrix;

        public Board(int rows, int cols)
        {
            Matrix = new int[rows, cols];
            this.CreateBoard();
        }

        public int[,] Matrix { get => matrix; set => matrix = value; }

        private void CreateBoard()
        {
            int value = 0;
            for (int i = 0; i < this.Matrix.GetLength(0); i++)
            {
                for (int j = 0; j < Matrix.GetLength(1); j++)
                {
                    matrix[i, j] = value++;
                }
            }
        }

        public bool IsInside(int row, int col)
        {
            return row >= 0 && row < matrix.GetLength(0) && col >= 0 && col < matrix.GetLength(1);
        }
    }
}
