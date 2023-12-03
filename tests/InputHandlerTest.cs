namespace tests;

[TestClass]
public class InputHandlerTest : code.InputHandler
{
    [TestMethod]
    public void ReadInput2DArrayTest()
    {
        string input = @"467..114..
...*......";
        char[,] expected = new char[,] { { '4', '6', '7', '.', '.', '1', '1', '4', '.', '.' }, { '.', '.', '.', '*', '.', '.', '.', '.', '.', '.' } };
        char[,] actual = code.InputHandler.ReadInput2DArray(input);
        CollectionAssert.AreEqual(expected, actual);

    }
    //     [TestMethod]
    //     public void ReadInputListTest()
    //     {
    //         string input = @"467..114..
    // ...*......";
    //         string[] expected = new string[] { "467..114..", "...*......" };
    //         string[] actual = code.InputHandler.ReadInputLines(input);
    //         CollectionAssert.AreEqual(expected, actual);

    //     }
}
