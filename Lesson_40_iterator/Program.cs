using System;
using System.Collections;
using System.Collections.Generic;
namespace Lesson_40_iterator
{
    #region 标准迭代器的实现
    class CustomList : IEnumerable, IEnumerator
    {
        private int[] list;
        // 从-1开始的光标 用于表示 数据得到了哪个位置
        private int position = -1;

        public CustomList()
        {
            list = new int[] { 1, 2, 3, 4, 5, 6, 7, 8 };
        }

        #region IEnumerable
        public IEnumerator GetEnumerator()
        {
            return this;
        }
        #endregion

        #region IEnumerator
        public object Current
        {
            get { return list[position]; }
            private set { }
        }
        public bool MoveNext()
        {
            ++position;
            // 判断索引是否越界
            return position < list.Length;
        }
        public void Reset()
        {
            // 光标复原
            position = -1;
        }
        #endregion
    }
    #endregion

    #region 用 yield return 语法糖实现迭代器
    class CustomList2 : IEnumerable
    {
        private int[] list;

        public CustomList2()
        {
            list = new int[] { 1, 2, 3, 4, 5, 6, 7};
        }

        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < list.Length; i++)
            {
                // yield关键字 配置迭代器使用   可以理解为 暂时返回 保留当前的状态
                yield return list[i];
            }
        }
    }
    #endregion

    #region 用 yield return 语法糖为泛型类实现迭代器
    class CustomList3<T> : IEnumerable
    {
        private T[] array;
        public CustomList3(params T[] array)
        {
            this.array = array;
        }
        public IEnumerator GetEnumerator()
        {
            for (int i = 0; i < array.Length; i++)
            {
                yield return array[i];
            }
        }
    }
    #endregion

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("迭代器");

            CustomList list = new CustomList();

            /*
            foreach本质  
                1.先调用 in 后面的IEnumerator, 然后调用GetEnumerator()
                2.执行得到这个IEnumerator对象的 MoveNext()
                3.只要MoveNext方法的返回值时 true 就回去得到 Current
                4.然后赋值给 item
            */
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            list.Reset();
            foreach (var item in list)
            {
                Console.WriteLine(item);
            }

            CustomList2 list2 = new CustomList2();
            foreach (var item in list2)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
            foreach (var item in list2)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            CustomList3<float> lis3 = new CustomList3<float>(1.1f, 2.2f, 3.3f);
            foreach (var item in lis3)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();
        }
    }

    /*
    总结
        迭代器就是让我们在外部直接通过foreach遍历对象中元素而不需要了解其结构
    主要迭代方式
        1.继承 IEnumerable, IEnumerator 两个接口    实现里面的方法
        2.用语法糖 yield return 去返回内容  只需要继承 IEnumerable 即可
    */
};


