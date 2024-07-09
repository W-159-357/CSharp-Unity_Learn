namespace Lesson_03_string;

class Program
{
    static void Print(string text)
    {
        Console.WriteLine(text);
    }

    static void Main(string[] args)
    {
        Console.WriteLine("特殊的引用类型String");
        
        #region 
        string str1 = "123";
        string str2 = str1;     // str2 与 str1 指向同一片内存空间
        Console.WriteLine("old str2:{0}", str2);
        str2 = "321";           // str2 取消指向 str1, 并重新分配属于自己的一片内存空间
        Console.WriteLine(str1);
        Console.WriteLine("new str2:{0}", str2);
        #endregion

        Print("1111111111");
    }
}
