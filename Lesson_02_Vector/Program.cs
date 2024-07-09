namespace Lesson_02_Vector;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Vector 1' Usage");
        #region 1. Vector 1
        // int[] arr1;
        // int[] arr2 = new int[5];    // 初始值默认为0
        // int[] arr3 = new int[5] { 1, 2, 3, 4, 5 };     // 创建时进行初始化操作
        // int[] arr4 = new int[] { 1, 2, 3, 4, 5, 6 };    // 不固定长度
        // int[] arr5 = { 1, 2, 3, 4, 5 };
        #endregion

        #region Vector' Usage
        // int[] array = { 1, 2, 3, 4, 5 };
        // Console.WriteLine(array.Length);
        // // 遍历数组 for
        // int a = 3;
        // for (int i = 0; i < array.Length; i++)
        // {
        //     if (array[i] == a)
        //     {
        //         Console.WriteLine("索引值的位置在{0}", i);
        //         break;
        //     }
        // }
        #endregion

        Console.WriteLine("----------------------------");
        Console.WriteLine("Vector 2' Usage");
        #region 2. Vector 2
        // int[,] arr;                 // 声明
        // int[,] arr2 = new int[3, 3];
        // int[,] arr3 = new int[3, 3] { {1, 2, 3},
        //                               {4, 5, 6},
        //                               {7, 8, 9 } };  // 3 * 3
        // int[,] arr4 = new int[,] {  {1, 2, 3},
        //                             {4, 5, 6},
        //                             {7, 8, 9 } };
        // int[,] arr5 = { {1, 2, 3},
        //                 {4, 5, 6},
        //                 {7, 8, 9} };
        // // 得到多少行
        // Console.WriteLine(arr5.GetLength(0));
        // // 得到多少列
        // Console.WriteLine(arr5.GetLength(1));
        #endregion

        Console.WriteLine("----------------------------");
        Console.WriteLine("交错数据");
        #region 3. 交错数组
        int[][] arr1;
        int[][] arr2 = new int[3][];
        int[][] arr3 = new int[3][] { new int[] {1, 2, 3},
                                      new int[] {1, 2},
                                      new int[] {1} };          // 行数固定，列数不定
        int[][] arr4 = new int[][]  { new int[] {1, 2, 3},
                                      new int[] {1, 2},
                                      new int[] {1} };          // 行数不定，列数不定
        int[][] arr5 = { new int[] {1, 2, 3},
                         new int[] {1, 2},
                         new int[] {1} };

        #region 
        int[][] array = { new int[] {1, 2, 3},
                          new int[] {4, 5} };
        // 行数
        Console.WriteLine(array.GetLength(0));
        // 某一行的列数
        Console.WriteLine(array[0].Length);
        // 获取交错数据的某个元素
        Console.WriteLine(array[0][1]);
        // 遍历交错数组
        for (int i = 0; i < array.GetLength(0); i++)
        {
            for (int j = 0; j < array[i].Length; j++)
            {
                Console.Write(array[i][j] + " ");
            }
            Console.WriteLine();
        }
        #endregion      

        #endregion

    }
}
