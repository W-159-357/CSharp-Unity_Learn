using System.Collections;

namespace Lesson_21_Stack
{
    class Test
    {}

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Stack");

            #region 栈声明
            Stack stack = new Stack();
            #endregion

            #region 入栈（增）
            stack.Push(1);
            stack.Push("123");
            stack.Push(true);
            stack.Push(1.222f);
            stack.Push(new Test());
            #endregion

            #region 出栈（删）
            var s = stack.Pop();
            Console.WriteLine(s);
            #endregion

            #region 查
            // 1.栈无法查找指定位置的元素   只能查看栈顶元素
            var s2 = stack.Peek();   // 当前栈顶元素
            Console.WriteLine("当前栈顶元素为{0}", s2);

            // 2.查找元素是否存在于栈中
            if (stack.Contains(true))
            {
                Console.WriteLine("存在数据 true");
            }
            #endregion

            #region 改
            // 栈无法改变其中的元素 只能入栈和出栈  实在要改 只能清空
            stack.Clear();
            stack.Push(1111111);
            stack.Push("嘎嘎");
            stack.Push(new object());
            #endregion

            #region 遍历
            Console.WriteLine(stack.Count);

            // 1.用foreach遍历 会从栈顶到栈底
            foreach(var item in stack)
            {
                Console.Write(item + " ");
            }  
            Console.WriteLine();

            // 2.将栈转换为数组
            var array = stack.ToArray();
            for(int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();

            // 3.循环弹栈遍历
            while (stack.Count > 0)
            {
                var item = stack.Pop();
                Console.Write(item + " ");
            }
            Console.WriteLine();

            #endregion

            #region 栈的练习题  利用栈使用十进制转二进制打印
            stack.Clear();

            int input = int.Parse(Console.ReadLine()); 
            while (input > 0)
            {
                stack.Push(input % 2);
                input = input / 2;
            }
            foreach(var item in stack)
            {
                Console.Write(item);    
            }
            Console.WriteLine();
            #endregion
        }
    }
};


