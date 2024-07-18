namespace Lesson_36_Thread
{
    class Program
    {
        static bool isRunning = true;
        static Mutex mutex = new Mutex();

        static void Main(string[] args)
        {
            Console.WriteLine("多线程");
            // 获取当前控制台窗口的宽度和高度
            int windowWidth = Console.WindowWidth;
            int windowHeight = Console.WindowHeight;

            // 设置控制台缓冲区大小，确保缓冲区大小不小于窗口大小
            int bufferWidth = Math.Max(windowWidth, 120);
            int bufferHeight = Math.Max(windowHeight, 40);

            // 检查缓冲区大小是否小于 short.MaxValue
            if (bufferWidth < short.MaxValue && bufferHeight < short.MaxValue)
            {
                Console.SetBufferSize(bufferWidth, bufferHeight);
            }
            else
            {
                Console.WriteLine("Buffer size is too large.");
            }

            #region 一、线程的使用
            // 1.新线程 将要执行的代码逻辑 被封装到了一个函数语句块中
            Thread thread = new Thread(NewThreadLogin);

            // 2.启动线程
            thread.Start();

            // 3.设置为后台线程     (主线程结束后，子线程也会被结束)
            // 后台线程不会防止应用程序的进程被终止掉   如果不设置为后台线程    可能导致进行无法正常关闭
            thread.IsBackground = true;

            // 4.关闭释放一个线程
            // 如果开启的线程不是死循环，则不用刻意去关闭该线程
            // 如果是死循环 想要终止这个线程    有两种方式
            // 4-1.死循环中bool标识
            Console.ReadKey();
            isRunning = false;

            // 4-2.通过线程提供的方式   About() 用于终止线程
            try
            {
                thread.Abort();
                thread = null;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            // 5.线程休眠
            // 让线程休眠多少毫秒       在哪个线程执行  就休眠哪个线程
            Thread.Sleep(1000);
            #endregion


            #region 二、使用锁来保证高并发的正确执行 (eg:用户余额)
            while (true)
            {
                mutex.WaitOne();
                Console.SetCursorPosition(0, 0);
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write("●");
                Thread.Sleep(50);
                mutex.ReleaseMutex();
            }
            #endregion
        }

        static void NewThreadLogin()
        {
            // 新开线程 执行的代码逻辑 在该函数语句块中
            // int i = 0;
            while (isRunning)
            {
                // Console.WriteLine(i);
                // Thread.Sleep(200);
                // i++;

                mutex.WaitOne();
                Console.SetCursorPosition(10, 10);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("▲");
                Thread.Sleep(50);
                mutex.ReleaseMutex();
            }
        }
    }

    /*
    总结
        多线程是多个可以同时执行代码逻辑的“管道”
        可以通过代码开启多线程  用多线程处理一些复杂的可能影响主线程流畅度的逻辑
    关键字
        Thread
    */
};

