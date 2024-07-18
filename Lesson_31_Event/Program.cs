namespace Lesson_31_Event
{
    #region 一、事件是什么
    /*
    事件是基于委托的存在
    事件是委托的安全包裹
    让委托的使用更具有安全性        -> 事件类似于 private 的委托
    事件 是一种特殊的变量类型
    */
    #endregion

    #region 二、事件的使用
    /*
    语法：
        访问修饰符 event 委托事件 事件名;
    使用：
        1.事件是作为 成员变量存在于类中
        2.委托怎么用 事件就怎么用
    事件与委托的区别：
        1.不能在类外部 赋值
        2.不能在类外部 调用
    注意：
        它只能作为成员存在于类和接口以及结构体中
    */

    class Test
    {
        public Action? myFun;            // 委托成员变量 用于存储 函数的
        public event Action? myEvent;    // 事件成员变量 用于存储 函数的

        public Test()
        {
            // 事件的使用和委托 一摸一样 只是有些 细微的区别
            myFun = TestFun;
            myFun += TestFun;
            myFun -= TestFun;
            myFun();
            myFun.Invoke();
            myFun = null;

            myEvent = TestFun;
            myEvent += TestFun;
            myEvent -= TestFun;
            myEvent();
            myEvent.Invoke();
            myEvent = null;
        }

        public void TestFun()
        {
            Console.WriteLine("88888888");
        }

        public void DoEvent()
        {
            if (myEvent != null)
            {
                myEvent();
            }
        }
    }
    #endregion

    class Program
    {
        static void TestFunc()
        {

        }

        static void Main(string[] args)
        {
            Console.WriteLine("Event(事件)");

            Test t = new Test();

            // 委托可以在外部赋值
            t.myFun = null;
            t.myFun = TestFunc;

            // 事件不能在外部赋值
            // t.myEvent = null;        // -> 此处会报错
            // t.myEvent = TestFunc;    // -> 此处会报错

            // 事件虽然不能直接赋值，但是可以 加减 去添加移除记录的函数
            t.myEvent += TestFunc;
            t.myEvent -= TestFunc;

            // 委托是可以在外部调用的
            t.myFun();
            t.myFun.Invoke();

            // 事件不能在外部调用
            // t.myEvent();             // -> 此处会报错
            // t.myEvent.Invoke();      // -> 此处会报错 

            // 只能在类的内部去封装 调用
            t.DoEvent();
        }
    }

    /*
    总结：
        事件和委托的区别
        事件和委托的使用基本是一模一样的
        事件就是特殊的委托          -> 类似于 private 的委托
    主要区别：
        1.事件不能在外部使用 赋值(=)符号  只能使用 +、-w    委托那里都能用
        2.事件 不能在外部执行 委托哪里都可以执行
        3.事件 不能作为 函数中的临时变量 委托可以
    */
};

