namespace Lesson_01_Test;

enum E_QQType
{
    OnLine,
    Leave,
    Busy,
    Invisible,
}

enum E_CafeType
{
    S,
    M,
    L,
    XL,
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("枚举练习题");
        #region test_01 QQ_Type
        try
        {
            Console.WriteLine("请输入QQ的状态(0在线, 1离开, 2繁忙, 3.隐身)");
            int type = int.Parse(Console.ReadLine());
            E_QQType qqType = (E_QQType)type;
            Console.WriteLine(qqType);
        }
        catch
        {
            Console.WriteLine("请输入数字");
        }
        #endregion

        #region  test_02    Cafe_Type
        try
        {
            Console.WriteLine("请输入Cafe的种类(小0, 中1, 大2, 超大3)");
            int cafeType = int.Parse(Console.ReadLine());
            E_CafeType cType = (E_CafeType)cafeType;
            switch (cType)
            {
                case E_CafeType.S:
                    Console.WriteLine("小杯, 10");
                    break;
                case E_CafeType.M:
                    Console.WriteLine("中杯, 15");
                    break;
                case E_CafeType.L:
                    Console.WriteLine("大杯, 20");
                    break;
                case E_CafeType.XL:
                    Console.WriteLine("超大杯, 25");
                    break;
                default:
                    Console.WriteLine("请输入正确类型");
                    break;
            }
        }
        catch
        {

        }
        #endregion
    }
}
