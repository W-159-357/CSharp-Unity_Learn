namespace Lesson_33_Lambda
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Lambda表达式");

            #region 一、基本语法
            /*
                1.匿名函数
                delegate (参数列表)
                {
                    函数体
                };
            */

            /*
                lambda表达式
                (参数列表) =>
                {
                    函数体
                };
            */
            #endregion

            #region 二、使用
            // 1.无参无返回值
            var action = () =>
            {
                Console.WriteLine("无参无返回值的Lambda表达式");
            };
            action();

            // 2.有参数无返回值
            Action<int> action2 = (int value) =>
            {
                Console.WriteLine("有参数无返回值的 value is {0}", value);
            };
            action2(11);

            // 3.深圳参数类型都可以省略 参数类型和委托或事件容器一致
            Action<int> action3 = (value) =>
            {
                Console.WriteLine("省略参数类型的写法, value is {0}", value);
            };
            action3(22);

            // 4.有返回值有参数 (Func 的参数列表中最后一个参数是返回值的类型)
            Func<string, int> action4 = (value) =>
            {
                Console.WriteLine("有参数有返回值的表达式{0}", value);
                return 33;
            };
            Console.WriteLine(action4("action4"));

            // 其他传参使用和匿名函数一样
            // 缺点也是和匿名韩式一样
            #endregion

            Test t = new Test();
            t.DoSomething();
        }
    }

    #region 三、闭包
    // 注意：
    //      改变量提供的值并非变量创建时的值，二十在父函数范围内的最终值
    class Test
    {
        public event Action action;

        public Test()
        {
            int value = 11;

            // 这里就形成了闭包
            // 因为 当构造函数执行完毕时 其中声明的临时变量value的生命周期被改变了
            action = () =>
            {
                Console.WriteLine(value);
            };

            for (int i = 0; i < 10; i++)
            {
                // 此index 非彼index
                int index = i;
                action += () =>
                {
                    // Console.WriteLine(i);
                    Console.WriteLine(index);
                };
            }
        }

        public void DoSomething()
        {
            action();
        }
    }
    #endregion

    /*
    总结
        匿名函数的特殊写法 就是 lambda表达式
        固定写法 就是 (参数列表) => ();
        参数列表可以直接省略参数类型
        主要在 委托传递和存储时 为了方便可以直接使用匿名函数或者lambda表达式

    缺点：
        无法指定移除
    */
};


