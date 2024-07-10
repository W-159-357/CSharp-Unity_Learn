namespace Lesson_06_Bubble_sort
{
    class Program
    {
        #region 冒泡排序
        // 代码实现
        static void Swap(ref int a, ref int b)
        {
            int temp = b;
            b = a;
            a = temp;
        }
        // 1.暴力冒泡排序
        // static void BubbleSort(int[] array)
        // {
        //     for (int i = 0; i < array.Length; i++)
        //     {
        //         for (int j = 0; j < array.Length - 1; j++)
        //         {
        //             if(array[j] > array[j+1])
        //             {
        //                 Swap(ref array[j], ref array[j+1]);
        //             }
        //         }
        //     }

        //     for(int i = 0; i < array.Length; i++)
        //     {
        //         Console.Write(array[i]);
        //     }
        // }

        // 2.冒泡排序的优化，思路：每一轮排序都有一个数到了自己所在的位置
        // static void BubbleSort(int[] array)
        // {
        //     for (int i = 0; i < array.Length; i++)
        //     {
        //         for (int j = 0; j < array.Length - 1 - i; j++)
        //         {
        //             if(array[j] > array[j+1])
        //             {
        //                 Swap(ref array[j], ref array[j+1]);
        //             }
        //         }
        //     }

        //     for(int i = 0; i < array.Length; i++)
        //     {
        //         Console.Write(array[i]);
        //     }
        // }

        // 3.特殊情况下优化的冒泡排序
        static void BubbleSort(int[] array)
        {
            bool isSort;
            for (int i = 0; i < array.Length; i++)
            {   
                // 每一轮开始时默认没有进行交换
                isSort = false;
                for (int j = 0; j < array.Length - 1 - i; j++)
                {
                    if (array[j] > array[j + 1])
                    {
                        isSort = true;
                        Swap(ref array[j], ref array[j + 1]);
                    }
                }
                // 当一轮结束过后，如果isSort这个标识还是false
                // 那就意味着 已经是最终的序列了 不需要再判断
                if (!isSort)
                {
                    break;
                }
            }

            for (int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i]);
            }
        }
        #endregion


        static void Main(string[] args)
        {
            Console.WriteLine("冒泡排序");

            int[] arr = [8, 7, 1, 5, 4, 2, 6, 3, 9];
            BubbleSort(arr);
        }
    }
};


