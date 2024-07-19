#define Fun
using System.Runtime.InteropServices;
using System.Diagnostics;
using System;
using System.Runtime.CompilerServices;
using System.Reflection;

namespace Lesson_39_特性
{
    #region 一、特性
    /*
        特性本质是个类
        我们可以利用特性类为元数据添加额外信息
        比如一个类、成员变量、成员方法等等为他们添加更好的额外信息
        之后可ui通过反射来获取这些额外信息
    */
    #endregion

    #region 二、自定义特性
    // 继承特性基类 Attribute
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Field, AllowMultiple = true, Inherited = false)]
    class MyCustomAttribute : Attribute
    {
        // 特性中的成员 一般根据需要来写
        public string info;

        public MyCustomAttribute(string info)
        {
            this.info = info;
        }

        public void TestFun()
        {
            Console.WriteLine("特性的方法");
        }
    }
    #endregion

    #region 三、特性的使用  
    // 基本语法         ->    [特性名(参数列表)]         -> 本质上就在在调用特性类的构造函数
    // 写的位置         ->    类、函数、变量上一行，表示他们具有该特性

    [MyCustom("特性测试")]              // 默认会省略后面的 Attribute
    public class MyClass
    {
        [MyCustom("这是一个成员变量")]
        public int value;

        public MyClass() { }
        public MyClass(int value)
        {
            this.value = value;
        }

        // [MyCustom("这是一个用于计算加法的函数")]
        // public void TestAdd([MyCustom("函数参数")] int value)
        // {

        // }
        public void TestAdd(int value)
        {

        }
    }
    #endregion

    #region 四、限制自定义特性的使用范围
    /*
        通过为特性类 加特性 限制其使用范围
            参数一：AttributeTargets    -   特性能够用在哪些地方
            参数二：AllowMultiple       -   是否允许多个特性实例用在同一目标上
            参数三：Inherited           -   特性是否能被派生类和重写成员继承
    */
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Struct, AllowMultiple = true, Inherited = true)]
    public class MyCustom2Attribute : Attribute
    {

    }
    #endregion

    #region 五、系统自带特性--过时特性
    /*
        Obsolete
        用于提示用户    使用的方法的成员已经过时    建议使用新方法
        一般加在函数前的特性
    */

    class TestClass
    {
        // 参数二：     true - 使用该方法时会报错   false - 使用该方法时直接警告
        [Obsolete("OldSpeak方法已经过时, 请使用Speak方法", false)]
        public void OldSpeak(string str)
        {

        }

        public void Speak()
        {

        }

        public void SpeakCaller(string str, [CallerFilePath] string fileName = "",
                                [CallerLineNumber]int line = 0, [CallerMemberName]string target = "")
        {
            Console.WriteLine(str);
            Console.WriteLine(fileName);
            Console.WriteLine(line);
            Console.WriteLine(target);
        }
    }
    #endregion

    #region 六、系统自带特性--调用者信息特性
    /*
        CallerFilePath          -> 哪个文件调用
        CallerLineNumber        -> 哪个函数调用
        CallerMemberName        -> 哪个函数调用
        引用命名空间             -> using System.Runtime.CompilerServices;      -> 替班作为函数参数的特性
    */
    #endregion

    #region 七、系统自带特性--条件编译特性
    /*
        Conditional
        配合 #define 一起使用
        引用命名空间                -> using System.Diagnostics;
        用法                       -> 主要用在一些调试代码上    有时像执行有时不想执行的代码
    */
    #endregion

    #region 八、系统自带特性--外部DLL包函数特性
    /*
        DllImport
            1.用来标记非 .Net 的函数    表明该函数在一个外部的DLL中定义
            2.一般用来调用 C或C++ 的DLL包写好的方法
            3.引用命名控件          -> using System.Runtime.InteropServices;
    */
    #endregion

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("特性");

            [DllImport("Test.dll")]
            static extern int Add(int a, int b);

            [Conditional("Fun")]
            static void Fun()
            {
                Console.WriteLine("Fun执行");
            }

            #region 特性的使用
            MyClass mc = new MyClass();
            // 下面三种写法都可以
            Type type = mc.GetType();
            // type = typeof(MyClass);
            // type = mc.GetType("Lesson_39_特性.MyClass");

            // 判断是否使用了某个特性   IsDefined(typeof(特性类型), 是否查找父类有此特性(true/false))    
            if (type.IsDefined(typeof(MyCustomAttribute), false))
            {
                Console.WriteLine("该类型应用了MyCustom特性");
            }

            object[] array = type.GetCustomAttributes(true);
            for (int i = 0; i < array.Length; i++)
            {
                if (array[i] is MyCustomAttribute myCustom)
                {
                    Console.WriteLine(myCustom.info);
                    myCustom.TestFun();
                }
            }

            TestClass tc = new TestClass();
            tc.OldSpeak("666");
            tc.Speak();

            tc.SpeakCaller("92174812");

            Fun();

            #endregion
        }
    }

    /*
        总结：
            特性用于 为元数据再添加更多的额外信息   （变量、方法等等）
            可以通过反射获取这个额外的数据  来进行一些特殊的处理
            自定义特性  --  继承 Attribute 类

            系统自带特性    
                过时特性                -> Obsolete
                调用者信息特性   
                            CallerFilePath          -> 哪个文件调用
                            CallerLineNumber        -> 哪个函数调用
                            CallerMemberName        -> 哪个函数调用
                条件编译特性            -> Conditional
                外部DLL包函数特性       -> DllImport
    */
};


