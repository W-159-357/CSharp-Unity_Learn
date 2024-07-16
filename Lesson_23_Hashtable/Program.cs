using System.Collections;

namespace Lesson_23_Hashtable
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hashtable");

            #region 1.哈希表(散列表)的本质    k/v
            // 基于键的哈希代码组织起来 键值对
            #endregion

            #region 2.声明
            Hashtable hashtable = new Hashtable();
            #endregion

            #region 3.增删查改

            #region 增  不能出现相同的键
            hashtable.Add(0, "QAQ");
            hashtable.Add(1, 666);
            hashtable.Add(2, new object());
            hashtable.Add(3, true);
            hashtable.Add("GG", 44);
            #endregion

            #region 删
            // 1.只能通过键去删除
            hashtable.Remove(1);
            // 2.删除不存在的键则没有反应
            hashtable.Remove(4);
            // 3.直接清空
            hashtable.Clear();
            hashtable.Add(1, 666);
            hashtable.Add("GG", 44);
            hashtable.Add(2, new object());
            hashtable.Add(3, true);
            #endregion

            #region 查
            // 1.通过键查看
            Console.WriteLine(hashtable[3]);
            Console.WriteLine(hashtable[10]);   // 此处返回空
            Console.WriteLine(hashtable["GG"]);

            // 2.查看是否存在   Contains 和 ContainsKey 两者的效果一样
            if(hashtable.Contains("GG"))
            {
                Console.WriteLine("GG is exist!");
            }
            else Console.WriteLine("GG is not exist!");

            // 3.根据值检测     ContainsValue
            if(hashtable.ContainsValue(true))
            {
                Console.WriteLine("存在value = true");
            }
            else Console.WriteLine("不存在改value");
            #endregion

            #region 改
            Console.WriteLine(hashtable[1]);
            hashtable[1] = 7777777;
            Console.WriteLine(hashtable[1]);
            #endregion

            #endregion

            #region 4.遍历
            Console.WriteLine(hashtable.Count);

            // 1.遍历所有键
            foreach(var item in hashtable.Keys)
            {
                Console.Write("Key: " + item + " ");
                Console.Write("Value: " + hashtable[item] + " ");
                Console.WriteLine();
            }
            
            // 2.遍历所有值
            foreach(var item in hashtable.Values)
            {
                Console.Write("Value: " + item + ", ");
            }
            Console.WriteLine();

            // 3.键值对一起遍历 DictionaryEntry 为 键值对类型的结构体
            foreach(DictionaryEntry item in hashtable)
            {
                Console.WriteLine("Key: " + item.Key + " Value: " + item.Value);
            }

            // 4.迭代器遍历
            IDictionaryEnumerator myEnumerator = hashtable.GetEnumerator();
            bool flag = myEnumerator.MoveNext();
            while(flag)
            {
                Console.WriteLine("Key: " + myEnumerator.Key + " Value: " + myEnumerator.Value);
                flag = myEnumerator.MoveNext();
            }
            #endregion
        }
    }

};

