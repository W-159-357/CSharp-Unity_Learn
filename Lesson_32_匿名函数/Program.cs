namespace Lesson_32_匿名函数
{
    class Test
    {
        public Action action;

        // 作为参数传递时
        public void DoSomething(int a, Action action)
        {
            Console.WriteLine(a);
            action();
        }

        // 作为返回值
        public Action GetFun()
        {
            return delegate ()
            {
                Console.WriteLine("函数内部返回的一个匿名函数");
            };
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("匿名函数");

            #region 一、匿名函数基本语法
            // delegate (参数列表)
            // {
            //     // 函数逻辑
            // }
            // 1.函数中传递委托参数时使用
            // 2.委托或事件赋值时使用
            #endregion

            #region 二、匿名函数的使用  
            // 1.无参无返回值               -> 无返回值 用 Action
            Action a = delegate ()
            {
                Console.WriteLine("匿名函数逻辑");
            };
            a();

            // 2.有参数无返回值
            Action<int, string> action2 = delegate (int value, string str)
            {
                Console.WriteLine("value:{0}, string:{1}", value, str);
            };
            action2(99, "www");

            // 3.无参有返回值                   -> 有返回值 用 Func
            Func<int> func1 = delegate ()
            {
                return 111;
            };
            Console.WriteLine(func1());

            // 4.一般情况下会作为函数参数传递 或者 作为函数返回值
            Test t = new Test();

            // 参数传递
            t.DoSomething(222, delegate ()
            {
                Console.WriteLine("随参数传入的匿名函数逻辑");
            });

            // 返回值
            Action action3 = t.GetFun();
            action3();
            // 一步到位 直接调用返回的委托函数
            t.GetFun()();
            #endregion

            #region 三、匿名函数的缺点
            // 添加到委托或事件容器中 不记录 无法单独移除

            Action action4 = delegate ()
            {
                Console.WriteLine("匿名函数一");
            };

            action4 += delegate ()
            {
                Console.WriteLine("匿名函数二");
            };
            action4();

            // 因为匿名函数没有名字 所有没有办法指定移除某一个匿名函数  只能进行清空
            action4 = null;
            #endregion

            #region 四、匿名函数练习题
            Func<int, Func<int, int>> Mul = delegate (int x)
            {
                return delegate (int y)
                {
                    return x * y;
                };
            };
            Func<int, int> func2 = Mul(7);
            Console.WriteLine(func2(8));
            #endregion

        }

    }

    /*
    总结：
        匿名函数 就是没有名字的函数
    固定写法：
        delegate () {};
        主要是在 委托传递和存储时 为了方便直接使用匿名函数
    缺点：
        没有办法指定移除
    */
};

