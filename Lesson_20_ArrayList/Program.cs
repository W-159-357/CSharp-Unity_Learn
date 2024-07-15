using System.Collections;

namespace Lesson_20_ArrayList
{
    class Test
    {

    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("ArrayList");

            #region 1.ArrayList的本质
            // 本质是一个object类型的数据,可以存放各种类型的数据
            #endregion

            #region 2.声明
            ArrayList arrayList = new ArrayList();
            #endregion

            #region 3.增删改查

            #region 增
            arrayList.Add(111);
            arrayList.Add("3333");
            arrayList.Add(true);
            arrayList.Add(true);
            arrayList.Add(new object());
            arrayList.Add(new Test());

            // 批量增加，把另一个arrayList的数据添加在后面
            ArrayList array2 = new ArrayList();
            array2.Add(222);
            arrayList.AddRange(array2);

            // 插入
            arrayList.Insert(1, "12312312");
            Console.WriteLine(arrayList[1]);
            #endregion

            #region 删
            // 移除指定元素 从头找 找到就删
            arrayList.Remove(111);    
            // 移除指定位置的元素
            arrayList.RemoveAt(2);
            // 清空
            // arrayList.Clear();
            #endregion

            #region 查
            // 得到指定位置的元素
            Console.WriteLine(arrayList[0]);

            // 查看元素是否存在
            if (arrayList.Contains("3333"))
            {
                Console.WriteLine("存在3333");
            }

            // 正向查找元素位置
            // 找到的返回值 是位置索引 找不到 返回值 是-1
            var index = arrayList.IndexOf(true);
            Console.WriteLine(index);
            Console.WriteLine(arrayList.IndexOf(false));

            // 反向查找元素位置
            index = arrayList.LastIndexOf(true);
             Console.WriteLine(index);
            Console.WriteLine(arrayList.LastIndexOf(false));
            #endregion

            #region 改
            Console.WriteLine(arrayList[0]);
            arrayList[0] = "1111111";
            Console.WriteLine(arrayList[0]);
            #endregion

            #region 遍历
            // 长度
            Console.WriteLine(arrayList.Count);
            // 容量(避免产生过多垃圾)
            Console.WriteLine(arrayList.Capacity);
            Console.WriteLine("------------------------------------------");

            // 传统遍历
            for(int i = 0;i < arrayList.Count; i++)
            {
                Console.Write(arrayList[i] + " ");
            } 
            Console.WriteLine();

            // foreach遍历
            foreach(var item in arrayList)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            #endregion

            #endregion
        }
    }
};


