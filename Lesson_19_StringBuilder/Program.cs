using System.Text;

namespace Lesson_19_StringBuilder
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("StringBuilder");
            // 使用StringBuilder前需要 引入 using.System.Text

            #region 1.StringBuilder初始化
            StringBuilder str = new StringBuilder("12312421412");
            Console.WriteLine(str);
            #endregion

            #region 2.容量 (会自动扩容, 以 2 的幂次方进行扩容, 和 Vector 一样的机制)
            Console.WriteLine(str.Capacity);    // 获取容量
            Console.WriteLine(str.Length);      // 获取长度
            #endregion

            #region 3.增删改查
            // 增
            str.Append("4444");
            Console.WriteLine(str);
            Console.WriteLine(str.Capacity);
            Console.WriteLine(str.Length);

            str.AppendFormat("{0}{1}", 100, 999);
            Console.WriteLine(str);
            Console.WriteLine(str.Length);
            Console.WriteLine(str.Capacity);

            // 插入     参数1：插入位置 参数二：插入的字符串
            str.Insert(0, "wxj");
            Console.WriteLine(str); 

            // 删除
            str.Remove(0, 10);
            Console.WriteLine(str); 

            // 清空
            // str.Clear();
            // Console.WriteLine(str); 

            // 查找
            Console.WriteLine(str[0]);

            // 修改
            str[0] = 'Q';
            Console.WriteLine(str); 

            // 替换
            str.Replace("1", "G");
            Console.WriteLine(str); 

            // 重新赋值
            str.Clear();
            str.Append("2194189721");
            Console.WriteLine(str); 

            // 判断是否相等
            if(str.Equals("2194189721"))
            {
                Console.WriteLine("字符串相等");
            }
            #endregion

            
            
        }
    }
};


