// namespace code;

// public class Alternative
// {

//     public static List<int> Results(int[,] heightMap)
//     {
//         int numRows = heightMap.GetLength(0);
//         int numCols = heightMap.GetLength(1);
//         List<int> result = new List<int>();

//         for (int row = 0; row < numRows; row++)
//         {
//             for (int col = 0; col < numCols; col++)
//             {
//                 if(HasLowerOrEqualLeftNeighbour(heightMap, row, col)) continue;
//                 if(HasLowerOrEqualRightNeighbour(heightMap, row, col)) continue;
//                 if(HasLowerOrEqualUpNeighbour(heightMap, row, col)) continue;
//                 if(HasLowerOrEqualDownNeighbour(heightMap, row, col)) continue;
//                 result.Add(heightMap[row, col]);
//             }
//         }
//         return result;
//     }
// }
