namespace TestProject.Static
{
    public static class ArrayExtensions
    {
        public static bool IsValidIndex<T>(this T[,] array, int rowIndex, int colIndex)
        {
            return rowIndex >= 0 && rowIndex < array.GetLength(0) &&
                   colIndex >= 0 && colIndex < array.GetLength(1);
        }
    }
}