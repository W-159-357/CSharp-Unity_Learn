#define Unity5
// #undef Unity5

#define IOS
#define Android
#define Windows
#define Linux

namespace Lesson_37_预处理器指令
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("预处理器指令");

            #region 一、常用的预处理指令
            /*
                #define  定义
                #undef   取消定义
                #if
                #else
                #elif
                #endif
            */

            // 如果有 Unity5 这个符号，那么其中包裹的代码会被编译器编译
#if Unity5
            Console.WriteLine("版本有Unity5");
#elif Unity6 && IOS || Unity2022
            Console.WriteLine("版本有Unity6");
#else
            Console.WriteLine("其他的Unity版本");
#endif

            #endregion
        }
    }
};


