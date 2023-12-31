namespace code;

public class Processor1
{
    public static long Process(char[,] matrix)
    {
        long sum = 0;
        HashSet<MatrixValue> numberList = GetNumbersSurroundingSymbol(matrix);
        foreach (MatrixValue number in numberList)
        {
            if (number.Value.Length > 0){
            sum += long.Parse(number.Value);}
        }
        return sum;

    }

    public static HashSet<MatrixValue> GetNumbersSurroundingSymbol(char[,] matrix)
    {
        int numRows = matrix.GetLength(0);
        int numCols = matrix.GetLength(1);
        HashSet<MatrixValue> numberList = new HashSet<MatrixValue>();
        HashSet<char> symbols = new HashSet<char>
        {
            '*', '+', '-', '/', '$', '%', '@', '=', '#', '&'
        };
        for (int i = 0; i < numRows; i++)
        {
            for (int j = 0; j < numCols; j++)
            {
                if (symbols.Contains(matrix[i, j]))
                {
                    GetNumbersTop(matrix, i, j, numRows, numCols, numberList);
                    GetNumbersBottom(matrix, i, j, numRows, numCols, numberList);
                    GetNumbersTopLeft(matrix, i, j, numRows, numCols, numberList);
                    GetNumbersTopRight(matrix, i, j, numRows, numCols, numberList);
                    GetNumbersLeft(matrix, i, j, numRows, numCols, numberList);
                    GetNumbersRight(matrix, i, j, numRows, numCols, numberList);
                    GetNumbersBottomLeft(matrix, i, j, numRows, numCols, numberList);
                    GetNumbersBottomRight(matrix, i, j, numRows, numCols, numberList);
                }
            }
        }
        return numberList;
    }

    private static void GetNumbersTop(char[,] matrix, int row, int col, int numRows, int numCols, HashSet<MatrixValue> numberList)
    {
        if (row > 0 && char.IsDigit(matrix[row - 1, col]))
        {
            string number = "";
            int i = row - 1;
            int colLeft = col;
            while (i >= 0 && colLeft >= 0 && char.IsDigit(matrix[i, colLeft]))
            {
                number = matrix[i, colLeft] + number;
                colLeft--;
            }
            int colRight = col + 1;
            while (i >= 0 && colRight < numCols && char.IsDigit(matrix[i, colRight]))
            {
                number = number + matrix[i, colRight];
                colRight++;
            }
            numberList.Add(new MatrixValue(number, i, colLeft+1));
            // Console.WriteLine(number);
        }
    }
    private static void GetNumbersBottom(char[,] matrix, int row, int col, int numRows, int numCols, HashSet<MatrixValue> numberList)
    {
        if (row < numRows - 1 && char.IsDigit(matrix[row + 1, col]))
        {
            string number = "";
            int i = row + 1;
            int colLeft = col;
            while (i >= 0 && colLeft >= 0 && char.IsDigit(matrix[i, colLeft]))
            {
                number = matrix[i, colLeft] + number;
                colLeft--;
            }
            int colRight = col + 1;
            while (i >= 0 && colRight < numCols && char.IsDigit(matrix[i, colRight]))
            {
                number = number + matrix[i, colRight];
                colRight++;
            }
            numberList.Add(new MatrixValue(number, i, colLeft+1));
            // Console.WriteLine(number);

        }
    }
    private static void GetNumbersTopLeft(char[,] matrix, int row, int col, int numRows, int numCols, HashSet<MatrixValue> numberList)
    {
        // Check if we are not on the topmost row or the leftmost column
        if (row > 0 && col > 0)
        {
            int i = row - 1;
            int j = col - 1;
            string number = "";

            // Check if the top-left cell is a digit
            if (char.IsDigit(matrix[i, j]))
            {
                while (i >= 0 && j >= 0 && char.IsDigit(matrix[i, j]))
                {
                    number = matrix[i, j] + number;
                    j--;
                }
                int colRight = col;
                while (i >= 0 && colRight < numCols && char.IsDigit(matrix[i, colRight]))
                {
                    number = number + matrix[i, colRight];
                    colRight++;
                }
            }
            numberList.Add(new MatrixValue(number, i, j+1));
            // Console.WriteLine(number);

        }

    }
    private static void GetNumbersTopRight(char[,] matrix, int row, int col, int numRows, int numCols, HashSet<MatrixValue> numberList)
    {
        if (row > 0 && col < numCols - 1 && char.IsDigit(matrix[row - 1, col + 1]))
        {
            string number = "";
            int i = row - 1, colRight = col + 1;
            while (i >= 0 && colRight < numCols && char.IsDigit(matrix[i, colRight]))
            {
                number = number + matrix[i, colRight];
                colRight++;
            }
            int colLef = col;
            while (i >= 0 && colLef >= 0 && char.IsDigit(matrix[i, colLef]))
            {
                number = matrix[i, colLef] + number;
                colLef--;
            }
            numberList.Add(new MatrixValue(number, i, colLef+1));
            // Console.WriteLine(number);

        }
    }
    private static void GetNumbersLeft(char[,] matrix, int row, int col, int numRows, int numCols, HashSet<MatrixValue> numberList)
    {
        if (col > 0 && char.IsDigit(matrix[row, col - 1]))
        {
            string number = "";
            int j = col - 1;
            while (j >= 0 && char.IsDigit(matrix[row, j]))
            {
                number = matrix[row, j] + number;
                j--;
            }
            numberList.Add(new MatrixValue(number, row, j+1));
            // Console.WriteLine(number);

        }
    }
    private static void GetNumbersRight(char[,] matrix, int row, int col, int numrows, int numCols, HashSet<MatrixValue> numberList)
    {
        if (col < numCols - 1 && char.IsDigit(matrix[row, col + 1]))
        {
            string number = "";
            int j = col + 1;
            while (j < numCols && char.IsDigit(matrix[row, j]))
            {
                number += matrix[row, j];
                j++;
            }
            numberList.Add(new MatrixValue(number, row, col+1));
            // Console.WriteLine(number);

        }
    }

    private static void GetNumbersBottomLeft(char[,] matrix, int row, int col, int numRows, int numCols, HashSet<MatrixValue> numberList)
    {
        if (row < numRows - 1 && col > 0 && char.IsDigit(matrix[row + 1, col - 1]))
        {
            string number = "";
            int i = row + 1, j = col - 1;
            while (i < numRows && j >= 0 && char.IsDigit(matrix[i, j]))
            {
                number = matrix[i, j] + number;
                j--;
            }
            int colRight = col;
            while (i < numRows && colRight < numCols && char.IsDigit(matrix[i, colRight]))
            {
                number = number + matrix[i, colRight];
                colRight++;
            }
            numberList.Add(new MatrixValue(number, i, j+1));
            // Console.WriteLine(number);

        }
    }


    private static void GetNumbersBottomRight(char[,] matrix, int row, int col, int numRows, int numCols, HashSet<MatrixValue> numberList)
    {
        if (row < numRows - 1 && col < numCols - 1 && char.IsDigit(matrix[row + 1, col + 1]))
        {
            string number = "";
            int i = row + 1, j = col + 1;
            while (i < numRows && j < numCols && char.IsDigit(matrix[i, j]))
            {
                number = number + matrix[i, j];
                j++;
            }
            int colLeft = col;
            while (i < numRows && colLeft >= 0 && char.IsDigit(matrix[i, colLeft]))
            {
                number = matrix[i, colLeft] + number;
                colLeft--;
            }
            numberList.Add(new MatrixValue(number, i, colLeft+1));
            // Console.WriteLine(number);

        }
    }
}