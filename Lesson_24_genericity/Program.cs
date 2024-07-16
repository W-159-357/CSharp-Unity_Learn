namespace Lesson_24_genericity
{
    #region 一、泛型类的使用  多类型和但类型
    class TestClass<T>
    {
        public T? value;
    }

    class TestClass2<T1, T2, K, M, L>
    {
        public T1? value1;
        public T2? value2;
        public K? value3;
        public M? value4;
        public L? value5;
    }
    #endregion 

    #region 二、泛型接口及使用
    interface TestInterface<T>
    {
        T Value { get; set; }
    }

    class Test : TestInterface<int>
    {
        public int Value { get; set; }
    }
    #endregion

    #region 三、泛型方法
    class Test2
    {
        public void TestFun<T>(T value)
        {
            Console.WriteLine(value);
        }

        public void TestFun<T>()
        {
            // 用泛型类型 在里面做一些逻辑处理
            T t = default(T);
        }

        public T TestFun<T>(string str)
        {
            return default(T);
        }

        public void TestFun<T, K ,M>(T t, K k, M m)
        {

        }
    }
    #endregion

    #region 泛型类中的泛型方法
    class Test2<T>
    {
        public T? value;

        public void TestFun<K>(K k)     // 必须在类里面的函数使用才算泛型
        {
            Console.WriteLine(k);
        }
    }
    #endregion

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("泛型");

            #region 什么是泛型
            // 和 Cpp 的 template 一样
            #endregion

            TestClass<int> t = new TestClass<int>();
            t.value = 100;
            Console.WriteLine(t.value);

            TestClass2<int, float, double, string, short> t2 = new TestClass2<int, float, double, string, short>();
            t2.value1 = 666;
            t2.value2 = 3.14f;
            t2.value3 = 3.1415926d;
            t2.value4 = "hash";
            t2.value5 = 128;

            Test2 test2 = new Test2();
            test2.TestFun<string>("string.....");

            Test2<string> test22 = new Test2<string>();
            test22.value = "77774GG";
            test22.TestFun<short>(128);
            test22.TestFun<double>(1.999999999999d);
        }
    }
};


