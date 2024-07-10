namespace Lesson_07_Select_sort
{
    class Program
    {
        static void Swap(ref int a, ref int b)
        {
            int temp = b;
            b = a;
            a = temp;
        }

        #region 选择排序
        static void SelectSort(int[] arr)
        {
            for (int i = 0; i < arr.Length; i++)
            {
                // index 保存当前排序轮次的最大值的索引值
                int index = 0;
                for (int j = 1; j < arr.Length - i; j++)
                {
                    if (arr[index] < arr[j])
                    {
                        index = j;
                    }
                }
                // 索引值不为当前排序轮次的最大索引值
                if (index != arr.Length - 1 - i)
                {
                    Swap(ref arr[arr.Length - 1 - i], ref arr[index]);
                }
            }

            for(int i = 0; i < arr.Length; i++)
            {
                Console.Write(arr[i] + " ");
            }
        }
        #endregion
        static void Main(string[] args)
        {
            Console.WriteLine("选择排序");
            int[] arr = [8, 7, 1, 5, 4, 2, 6, 3, 9];
            SelectSort(arr);
        }
    }
};


