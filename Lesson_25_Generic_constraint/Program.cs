namespace Lesson_25_Generic_constraint;

class Program
{
    #region 一、泛型约束 
    /*
    关键字: where
    1.值类型                        where 泛型字母:struct
    2.引用类型                      where 泛型字母:class
    3.存在无参公共构造函数            where 泛型字母:new()
    4.某个类本身或者其派生类          where 泛型字母:类名
    5.某个接口的派生类型              where 泛型字母:接口名
    6.另一个泛型类型本身或者派生类型   where 泛型字母:另一个泛型字母

    where 泛型字母: (约束的类型)
    */
    #endregion

    #region 二、各泛型约束讲解

    #region 1.值类型约束
    class Test1<T> where T : struct     
    {
        public T? value;

        public void TestFun<K>(K k) where K : struct
        {
            Console.WriteLine(k);
        }
    }
    #endregion

    #region 2.引用类型约束
    class Test2<T> where T : class
    {
        public T? value;

        public void TestFun<K>(K k) where K : class
        {
            Console.WriteLine(k);
        }
    }
    #endregion

    #region 3.公共午餐构造约束
    class Test3<T> where T : new()
    {
        public T? value;

        public void TestFun<K>(K k) where K : new()
        {
            Console.WriteLine(k);
        }
    }

    class Test31
    {

    }

    class Test32
    {
        public Test32(int a)
        {

        }
    }
    #endregion

    #region 4.类约束
    class Test4<T> where T : Test41
    {
        public T? value;

        public void TestFun<K>(K k) where K : Test41
        {
            Console.WriteLine(k);
        }
    }

    class Test41 : Test31
    {

    }
    #endregion

    #region 5.接口约束
    interface IFly
    {

    }

    class Test4 : IFly
    {

    }

    class Test5<T> where T : IFly
    {
        public T? value;

        public void TestFun<K>(K k) where K : IFly
        {
            Console.WriteLine(k);
        }
    }
    #endregion

    #region 6.另一个泛型约束
    class Test6<T,U> where T : U
    {
        public T? value;

        public void TestFun<K, V>(K k) where K : V
        {
            Console.WriteLine(k);
        }
    }

    #endregion

    #endregion

    #region 二、约束的组合使用
    class Test7<T> where T : class, new()
    {

    }
    #endregion

    #region 三、多个泛型有约束
    class Test8<T, K> where T : class, new() where K : struct
    {
        
    }
    #endregion

    static void Main(string[] args)
    {
        Console.WriteLine("泛型约束");

        Test1<int> t1 = new Test1<int>();
        t1.value = 1;
        t1.TestFun<float>(1.77777777f);

        Test2<Random> t2 = new Test2<Random>();
        t2.value = new Random();
        t2.TestFun<object>(new object());

        Test3<Test31> t3 = new Test3<Test31>();
        // Test3<Test32> t3_2 = new Test3<Test32>();   // 由于Test32里面的函数有参，故会报错
        t3.value = new Test31();
        t3.TestFun<Test31>(new Test31());

        Test4<Test41> t4 = new Test4<Test41>();

        Test5<IFly> t5 = new Test5<IFly>();
        t5.value = new Test4();            // Test继承了 IFly
        t5.TestFun<IFly>(new Test4());

        Test6<Test4, IFly> t6 = new Test6<Test4, IFly>();
        t6.value = new Test4();
    }
}
