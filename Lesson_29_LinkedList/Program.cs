using System.Collections.Generic;

namespace Lesson_29_LinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("系统自带的LinkedList");      // 默认为双向链表

            LinkedList<int> linkedList = new LinkedList<int>();

            #region 增删改查
            
            #region 1.增
            // 1.尾插
            linkedList.AddLast(10);
            linkedList.AddLast(20);
            linkedList.AddLast(30);
            linkedList.AddLast(40);

            // 2.头插
            linkedList.AddFirst(53);

            // 3.在某一个结点之后添加结点
            var node = linkedList.Find(20);
            linkedList.AddAfter(node, 28);
            Console.WriteLine(node.Next.Value);

            // 4.在某一个结点之前添加结点
            linkedList.AddBefore(node, 17);
            Console.WriteLine(node.Previous.Value);
            #endregion

            #region 2.删
            // 1.移除头
            linkedList.RemoveFirst();
            // 2.移除尾
            linkedList.RemoveLast();
            // 3.移除指定结点(根据value进行删除)
            linkedList.Remove(20);
            // 4.清空
            // linkedList.Clear();
            #endregion

            #region 3.查    
            // 1.头结点
            LinkedListNode<int> first = linkedList.First;
            // 2.尾结点
            var last = linkedList.Last;
            // 3.找到指定值的节点
            node = linkedList.Find(30);
            Console.WriteLine(node.Value);
            // 4.判断是否存在
            if (linkedList.Contains(11))
            {
                Console.WriteLine("存在元素11");
            }
            else Console.WriteLine("不存在该元素");
            #endregion

            #region 4.改
            Console.WriteLine(linkedList.First.Value);
            linkedList.First.Value = 8;
            Console.WriteLine(linkedList.First.Value);
            #endregion

            #endregion

            #region 遍历
            // 1.foreach
            foreach (var item in linkedList)
            {
                Console.Write(item + ", ");
            }
            Console.WriteLine();

            // 2.从头到尾
            LinkedListNode<int> curNode = linkedList.First;
            while (curNode != null)
            {
                Console.Write(curNode.Value + ", ");
                curNode = curNode.Next;
            }
            Console.WriteLine();

            // 3.从尾到头
            curNode = linkedList.Last;
            while (curNode != null)
            {
                Console.Write(curNode.Value + ", ");
                curNode = curNode.Previous;
            }
            Console.WriteLine();
            #endregion
        }
    }
};


