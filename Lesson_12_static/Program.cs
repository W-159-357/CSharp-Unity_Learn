namespace Lesson_12_static;

static class Tools
{
    #region 扩展方法的基本语法
    // 访问修饰符 static 返回值 函数名(this 扩展类名 参数名， 参数类型 参数名)
    #endregion

    #region 实例

    // 扩展方法必须在顶级静态类中定义
    public static void SpeakValue(this int value)   
    {
        Console.WriteLine("为int扩展的方法" + value);
    }

    public static void SpeakStringInfo(this string str, string str2, string str3)
    {
        Console.WriteLine("为string扩展的方法");
        Console.WriteLine("调用方法的对象" + str);
        Console.WriteLine("传的参数：" + str2 + " " + str3);
    }
    #endregion

    public static void Func3(this Test t)
    {
        Console.WriteLine("为Test类扩展的新方法");
    }
}

#region 为自定义的类型扩展方法
class Test
{
    public int i = 10;
    public void Func1()
    {
        Console.WriteLine("123");
    }
    public void Func2()
    {
        Console.WriteLine("456");
    }
}
#endregion

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Hello, World!");

        #region 扩展方法的使用
        int i = 10;
        i.SpeakValue();

        string str = "888";
        str.SpeakStringInfo("wxj", str);

        Test t = new Test();
        t.Func3();
        #endregion
    }
}
