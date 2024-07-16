using System.Collections.Generic;

namespace Lesson_26_List
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("List的使用");

            #region 一、List的本质
            // 泛型数组
            #endregion

            #region 二、声明
            List<int> list = new List<int>();
            List<int> list2 = new List<int>();
            #endregion

            #region 三、List的增删改查

            #region 1.增
            list.Add(1);
            list.Add(2);
            list.Add(3);
            list.Add(4);
            list.Add(5);

            list2.Add(6);
            list2.AddRange(list2);

            list.Insert(1, 456);
            Console.WriteLine(list[1]);
            #endregion

            #region 2.删
            // 移除指定元素
            list.Remove(1);
            // 移除指定位置的元素
            list.RemoveAt(2);
            // 清空
            // list.Clear();
            #endregion

            #region 3.查
            // 得到指定索引位置的元素
            Console.WriteLine(list[0]);

            // 查看元素是否存在
            if (list.Contains(5))
            {
                Console.WriteLine("存在元素5");
            }

            // 正向查找
            int index = list.IndexOf(5);
            Console.WriteLine(index);

            // 反向查找
            index = list.LastIndexOf(4);
            Console.WriteLine(index);
            #endregion

            #region 4.改
            Console.WriteLine(list[0]);
            list[0] = 777;
            Console.WriteLine(list[0]);
            #endregion

            #endregion

            #region 四、遍历
            Console.WriteLine(list.Count);
            Console.WriteLine(list.Capacity);
            Console.WriteLine("---------------------------------------------");

            // 1.for
            for(int i = 0; i < list.Count; i++)
            {
                Console.Write(list[i] + " ");
            }
            Console.WriteLine();

            // 2.foreach
            foreach(var item in list)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            #endregion
        }
    }
};


