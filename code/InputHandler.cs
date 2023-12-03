namespace code;

public class InputHandler
{

    // store lines of strings in a 2d array
    public static char[,] ReadInput2DArray(string input)
    {
        // Split the input into rows
        string[] rows = input.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);

        int numRows = rows.Length;
        int numCols = rows[0].Length;
        var matrix = new char[numRows, numCols];

        for (int i = 0; i < numRows; i++)
        {
            for (int j = 0; j < numCols; j++)
            {
                matrix[i, j] = rows[i][j]; // Convert char to int
            }
        }


        // // Display the 2D array for verification
        // for (int i = 0; i < numRows; i++)
        // {
        //     for (int j = 0; j < numCols; j++)
        //     {
        //         Console.Write(heightMap[i, j]);
        //     }
        //     Console.WriteLine();
        // }
        return matrix;
    }
    public static string[] ReadInputLines(string input)
    {
        // Split the input into rows
        string[] rows = input.Split(new[] { '\r', '\n' }, StringSplitOptions.RemoveEmptyEntries);
        return rows;
    }
}