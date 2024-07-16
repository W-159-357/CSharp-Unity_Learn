using System.Collections;

namespace Lesson_22_Queue
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Queue");

            #region  队列的本质
            // 本质是一个object数组
            #endregion

            #region 1.声明
            Queue queue = new Queue();  // 初始队列(C#并不提供双端队列，只能自己实现)
            #endregion

            #region 2.增删改查
            
            #region 增
            queue.Enqueue(1);
            queue.Enqueue("nasa");
            queue.Enqueue(2.678f);
            queue.Enqueue(new object());
            #endregion

            #region 取
            var header = queue.Dequeue();
            Console.WriteLine(header);
            #endregion

            #region 查
            // 1.查看首部元素
            header = queue.Peek();        
            Console.WriteLine(header);

            // 2.查看元素是否存在于队列中
            if(queue.Contains(true))
            {
                Console.WriteLine("队列包含元素 true");
            }
            else Console.WriteLine("不存在该元素");
            #endregion

            #region 改
            // 队列中的元素无法进行修改 只能进出队列    实在要改，只能清空
            queue.Clear();
            queue.Enqueue(new object());
            queue.Enqueue(2);
            queue.Enqueue(true);
            queue.Enqueue("wxj");
            #endregion

            #endregion

            #region 3.遍历
            Console.WriteLine(queue.Count);

            // foreach
            foreach(var item in queue)
            {
                Console.Write(item + " ");
            }
            Console.WriteLine();

            // 转换为object数组
            var array = queue.ToArray();
            for(int i = 0; i < array.Length; i++)
            {
                Console.Write(array[i] + " ");
            }
            Console.WriteLine();

            // 循环出队列
            while(queue.Count > 0)
            {
                Console.Write(queue.Dequeue() + " ");
            }
            Console.WriteLine();
            #endregion
        }
    }

};

