// using System.Collections.Generic;

namespace Lesson_28_Sequence_and_chain
{
    #region 单向链表
    public class LinkNode<T>
    {
        public T value;
        public LinkNode<T>? next;

        public LinkNode(T value)
        {
            this.value = value;
            this.next = null;
        }
    }

    // 单项链表来实现链表的管理
    public class LinkedList<T>
    {
        public LinkNode<T> head;
        public LinkNode<T> tail;

        // 尾插法
        public void Add(T value)
        {
            LinkNode<T> node = new LinkNode<T>(value);
            if (head == null)
            {
                head = node;
                tail = node;
            }
            else
            {
                tail.next = node;
                tail = node;
            }
        }

        public void Remove(T value)
        {
            if (head == null)
            {
                return;
            }
            if (head.value.Equals(value))
            {
                head = head.next;
                if (head == null)
                {
                    tail = null;
                }
                return;
            }

            LinkNode<T> tempNode = head;
            while (tempNode.next != null)
            {
                if (tempNode.next.value.Equals(value))  // 等于就删除结点
                {
                    tempNode.next = tempNode.next.next;
                    break;      // 被断开的结点会被自动GC
                }
                else                                    // 不等就指向下一个结点
                {
                    tempNode = tempNode.next;
                }
            }
        }

        public void Print(LinkNode<T> node)
        {
            while (node != null)
            {
                Console.Write(node.value + ", ");
                node = node.next;
            }
            Console.WriteLine();
        }
    }
    #endregion

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("顺序存储和链式存储");

            #region 单链表的使用
            LinkedList<int> linkList = new LinkedList<int>();
            linkList.Add(777);
            linkList.Add(888);
            linkList.Add(999);
            linkList.Add(1111);

            linkList.Print(linkList.head);

            linkList.Remove(999);
            linkList.Print(linkList.head);

            #endregion
        }
    }
};


