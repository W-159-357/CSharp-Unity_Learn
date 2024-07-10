namespace Lesson_04_function;

class Program
{
    #region params的使用
    /*
    变长参数关键字 params int[]
    1.params关键字后面必须为数组
    2.数组的类型可以是任意的类型
    3.函数参数可以有 别的参数和 params关键字修饰的参数
    4.函数参数中只能最多出现 一个params关键字，并且一定是在最后一组参数，前面可以有n个其他参数
    */
    static int Sum(params int[] arr)
    {
        int sum = 0;
        for (int i = 0; i < arr.Length; i++)
        {
            sum += arr[i];
        }
        return sum;
    }

    static void Eat(string name, int a, int b, params string[] things)
    {
        int sum = a + b;
        string str = "";
        for (int i = 0; i < things.Length; i++)
        {
            str += things[i];
        }
        Console.WriteLine("name:{0}, sum:{1}, string:{2}", name, sum, str);
    }
    #endregion

    #region 函数递归
    static void Fun(int a)
    {
        if(a > 10)
        {
           return;
        }
        a++;
        Fun(a);
    }
    #endregion

    static void Main(string[] args)
    {
        Console.WriteLine("变长参数和参数默认值");

        Console.WriteLine(Sum(1, 2, 3, 4, 5, 6, 7));
        Eat("Cpp", 2, 3, "qqq-", "sss-", "aaa-", "ddd");
        Fun(0);
    }
}
