using System;

class Program
{
    int[,] matrix;
    public int ColCount { get; set; }
    public int RowCount { get; set; }
    public Program(int row, int col)
    {
        matrix = new int[row, col];
        RowCount = matrix.GetLength(0);
        ColCount = matrix.GetLength(1);

    }
    public void FillElementsRandom(int min, int max)
    {
        Random rand = new Random();
        for (int i = 0; i < RowCount; i++)
            for (int j = 0; j < ColCount; j++)
                matrix[i, j] = rand.Next(min, max + 1);
    }
    public void ShowMatrix()
    {
        for (int i = 0; i < RowCount; i++)
        {
            for (int j = 0; j < ColCount; j++)
            {
                Console.Write(matrix[i, j] + " ");
            }
            Console.WriteLine();
        }
    }

    public void SumOfRowsWithNegatives()
    {
        int[] sum = new int[RowCount];

        for (int i = 0; i < RowCount; i++)
        {
            bool hasNegative = false;
            for (int j = 0; j < ColCount; j++)
            {
                if (matrix[i, j] < 0)
                {
                    hasNegative = true;
                    break;
                }
            }
            if (hasNegative)
            {
                for (int j = 0; j < ColCount; j++)
                {
                    sum[i] += matrix[i, j];
                }
                Console.WriteLine("Sum of all elements in row,where at least one negative element ["+(i+1)+"]: " + sum[i]);
            }
            
        }

    }


    public void FindSaddlePoints()
    {
        int[,] saddlePoints = new int[RowCount, ColCount];
        for (int i = 0; i < RowCount; i++)
        {
            for (int j = 0; j < ColCount; j++)
            {
                int value = matrix[i, j];
                bool isSaddlePoint = true;
                for (int k = 0; k < ColCount; k++)
                {
                    if (value > matrix[i, k])
                    {
                        isSaddlePoint = false;
                        break;
                    }
                }
                if (isSaddlePoint)
                {
                    for (int k = 0; k < RowCount; k++)
                    {
                        if (value < matrix[k, j])
                        {
                            isSaddlePoint = false;
                            break;
                        }
                    }
                }
                if (isSaddlePoint)
                {
                    saddlePoints[i, j] = value;
                }
            }

        }
        for (int i = 0; i < RowCount; i++)
        {
            for (int j = 0; j < ColCount; j++)
            {
                if (saddlePoints[i,j]>0)
                {
                    Console.Write(saddlePoints[i, j] + " ");
                }
                
            }
            Console.WriteLine();
        }
        
    }

           public static void Main(string[] args)
    {
        Program ob = new Program(5, 3);

        ob.FillElementsRandom(-20, 222);
        ob.ShowMatrix();
        ob.SumOfRowsWithNegatives();
        ob.FindSaddlePoints();
    }
}


