namespace Lesson_35_协变逆变
{
    #region 一、协变逆变
    // 用于在泛型中 修饰 泛型字母的
    // 只有泛型接口和泛型委托能使用
    #endregion

    #region 二、协变逆变的作用  
    // 1.返回值 和 参数
    // 用out修饰的泛型 只能作为返回值
    delegate T TestOut<out T>();

    // 用in修饰的凡是   只能作为参数
    delegate void TestIn<in T>(T t);

    interface Test<out T>
    {
        T TestFun();
    }

    // 2.结合里氏替换原则理解
    class Father
    {

    }

    class Son : Father
    {

    }
    #endregion

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("协变逆变");

            // 协变 父类总是能被子类替换
            // 看起来 就是 son -> father
            TestOut<Son> os = () =>
            {
                return new Son();
            };

            TestOut<Father> of = os;
            Father f = of();            // 实际上 返回的 是os里面装的函数   返回的时 Son

            // 逆变 父类总是能被子类替换
            // 看起来 就是 father -> son
            TestIn<Father> iF = (value) =>
            {

            };

            TestIn<Son> iS = iF;
            iS(new Son());              // 实际上 调用的时iF
        }
    }

    /*
    总结
        协变 out
        逆变 in
        用来修饰 泛型替代符的   只能修饰接口和委托中的泛型

    作用
        1.out修饰的泛型类型 只能作为返回值类型 in修饰的泛型类型 只能作为 参数类型
        2.遵循历史替换原则的    用out和in修饰的 泛型委托    可以相互装载(有父子关系的委托)

    协变： 父类泛型委托装子类泛型委托       逆变： 子类泛型委托装父类泛型委托
    */
};


