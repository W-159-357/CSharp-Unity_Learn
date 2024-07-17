using System.Collections.Generic;

namespace Lesson_27_Dictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Dictionary' Usage");

            #region 一、声明
            Dictionary<int, string> dict = new Dictionary<int, string>();
            #endregion

            #region 二、增删改查

            #region 1.增
            dict.Add(1, "111");
            dict.Add(2, "222");
            dict.Add(3, "333");
            #endregion

            #region 2.删
            // 以 key 的方式删除
            dict.Remove(2);
            dict.Remove(4);

            // 清空
            dict.Clear();
            #endregion

            #region 3.查
            dict.Add(1, "111");
            dict.Add(2, "222");
            dict.Add(3, "333");
            // 如果是找不到的 Key, 则会直接报错
            Console.WriteLine(dict[2]);
            Console.WriteLine(dict[3]);

            // 查看是否存在(根据KEY)
            if (dict.ContainsKey(1))
            {
                Console.WriteLine("存在KEY = 1 的元素, value = {0}", dict[1]);
            }

            // 根据 VALUE
            if (dict.ContainsValue("222"))
            {
                Console.WriteLine("存在VALUE = 222 的键值对");
            }
            #endregion

            #region 4.改
            Console.WriteLine(dict[1]);
            dict[1] = "777";
            Console.WriteLine(dict[1]);
            #endregion

            #endregion

            #region 三、遍历
            // 1.遍历所有KEY
            foreach (var key in dict.Keys)
            {
                Console.Write(key + ": ");
                Console.Write(dict[key]);
                Console.WriteLine();    
            }

            // 2.遍历所有VALUE
            foreach (var value in dict.Values)
            {
                Console.Write(value + " ");
            }
            Console.WriteLine();

            // 3.键值对一直遍历
            foreach (KeyValuePair<int, string> item in dict)    // 可以用 var 替换 KeyValuePair<int, string>
            {
                Console.WriteLine("Key: " + item.Key + " Value: " + item.Value);
            }
            #endregion
        }
    }
};


