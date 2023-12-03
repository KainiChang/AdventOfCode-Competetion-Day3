public class MatrixValue
{
    public string Value { get; }
    public int Row { get; }
    public int Column { get; }

    public MatrixValue(string value, int row, int column)
    {
        Value = value;
        Row = row;
        Column = column;
    }

    public override bool Equals(object obj)
    {
        return obj is MatrixValue other &&
               Row == other.Row &&
               Column == other.Column;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Row, Column);
    }
}
