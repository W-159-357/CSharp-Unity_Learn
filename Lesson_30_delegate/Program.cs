using System;

namespace Lesson_30_delegate
{
    #region 一、委托
    // 关键字: delegate
    // 默认为public
    #endregion

    #region 二、自定义委托
    // 声明了一个可以用来存储无参无返回值函数的容器
    // 委托规则的声明 是不能重名 (同一语句块中)
    delegate void MyFun();

    public delegate int MyFun2(int a);
    #endregion

    #region 三、使用定义好的委托
    // 1.作为类的成员
    // 2.作为函数的参数
    class Test
    {
        public MyFun fun;
        public MyFun2 fun2;
        public Action action;

        public void TestFun(MyFun fun, MyFun2 fun2)
        {
            // 先处理一些别的逻辑   当这些逻辑处理完了  再执行传入的函数
            int i = 100;
            i *= 2;
            i -= 2;

            // fun();
            // fun2(100);
            this.fun = fun;
            this.fun2 = fun2;
        }

        // 增
        public void AddFun(MyFun fun, MyFun2 fun2)
        {
            this.fun += fun;
            this.fun2 += fun2;
        }

        // 删
        public void RemoveFun(MyFun fun, MyFun2 fun2)
        {
            this.fun -= fun;
            this.fun2 -= fun2;
        }
        #endregion
    }

    #region 四、委托变量可以存储多个函数(多播委托)


    #endregion

    class Program
    {
        static void Fun()
        {
            Console.WriteLine("xxx to do something");
        }

        static int Fun2(int value)
        {
            return value;
        }

        static void Fun3()
        {
            Console.WriteLine("www to do something");
        }

        static string Fun4()
        {
            return "value";
        }

        static int Fun5()
        {
            return 0;
        }

        static void Fun6(int i, string s)
        {

        }

        static void Main(string[] args)
        {
            Console.WriteLine("delegate' Usage");

            // 专门用来装载函数的容器
            MyFun f = new MyFun(Fun);
            Console.WriteLine("*************************");
            // 委托的调用
            f.Invoke();     // 1.用Invoke调用

            MyFun f2 = Fun;
            f2();           // 2.直接调用

            Console.WriteLine("*************************");
            MyFun2 f3 = Fun2;
            Console.WriteLine(f3.Invoke(777));
            Console.WriteLine(f3(888));

            Test t = new Test();
            t.TestFun(f, f3);

            // 如果用委托存储多个函数
            MyFun ff = null;
            ff += Fun;
            ff += Fun3;
            ff();

            // 从容器中移除指定的函数
            ff -= Fun;
            ff();

            t.AddFun(Fun, Fun2);
            // t.fun();
            // t.fun2(23);

            #region 五、系统定义好的委托
            // 使用系统自带委托，需要引用 using System
            // 无参无返回值的委托   Action
            Action action = Fun;
            action += Fun3;
            action();

            // 泛型委托     Func
            Func<string> funcString = Fun4;
            Func<int> funcInt = Fun5;

            // 可以传 n 个参数的, 系统提供给了 1 - 16 个参数的委托
            Action<int, string> action2 = Fun6;
            #endregion
        }
    }

    /*
    总结
    简单理解 委托 就是装载、传递函数的容器而已
    可以用委托变量 来存储函数或者传递函数的
    系统其实已经提供了很多委托给我们用
    Action:没有返回值，参数提供了 0 - 16 个委托给我们用
    Func:有返回值，参数提供了 0 - 16 个委托给我们用
    */
};

