namespace Lesson_18_string;

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("string");

        string str = "wsadryui";

        #region 1.正常查找  IndexOf
        int index = str.IndexOf("u");
        Console.WriteLine(index);
        #endregion

        #region 2.反向查找  LastIndexOf
        index = str.LastIndexOf("d");
        Console.WriteLine(index);
        #endregion

        #region 3.移除指定位置后的字符  Remove
        str = "我是卤鸡蛋司法解释";
        str = str.Remove(5);    // 移除第四和后面的所有数据
        Console.WriteLine(str);

        // 指定参数进行移除 参数一：开始位置 参数二：要移除的字符个数
        str = str.Remove(1, 1);
        Console.WriteLine(str);
        #endregion

        #region 4,替换指定字符串    Replace
        str = "我是卤鸡蛋司法解释";
        str = str.Replace("卤鸡蛋", "咸鸭蛋");
        Console.WriteLine(str);
        #endregion

        #region 5.大小写转换    ToUpper     ToLower
        str = "askjglksjdggjeliskdlg";
        str = str.ToUpper();            // 转为大写
        Console.WriteLine(str);
        str = str.ToLower();            // 转为小写
        Console.WriteLine(str);
        #endregion

        #region 6.字符串截取    Substring
        str = "我是卤鸡蛋司法解释";
        // 从指定位置截取之后的字符串
        str = str.Substring(2);
        Console.WriteLine(str);

        // 指定参数进行截取 参数一：开始位置 参数二：要截取的字符串个数
        str = "我是卤鸡蛋司法解释";
        // 从指定位置截取之后的字符串
        str = str.Substring(2, 5);
        Console.WriteLine(str);
        #endregion

        #region 7.字符串切割    Split
        str = "我是,卤鸡蛋,司法,解释";
        string[] strings = str.Split(",");
        for(int i = 0; i < strings.Length; i++)
        {
            Console.Write(strings[i] + " ");
        }
        #endregion
    }
}
