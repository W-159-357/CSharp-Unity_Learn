namespace Lesson_34_List_Sort
{
    class Item : IComparable<Item>
    {
        public int money;
        public Item(int money)
        {
            this.money = money;
        }

        public int CompareTo(Item other)
        {
            // 返回值的函数
            // 小于0    -> 放在传入对象的前面
            // 等于0    -> 保持当前的位置不变
            // 大于0    -> 放在传入对象的后面

            // 可以简单理解 传入对象的位置 就是0
            // 如果你的返回为负数 就放在它的左边 也就是前面
            // 如果你返回正数 就放在它的右边 也就是后面

            // 升序排序
            if (this.money > other.money)
            {
                return 1;
            }
            else
            {
                return -1;
            }
        }
    }

    class ShopItem
    {
        public int id;
        public ShopItem(int id)
        {
            this.id = id;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("List 自带排序");

            List<int> list = new List<int>();
            list.Add(6);
            list.Add(3);
            list.Add(8);
            list.Add(4);
            list.Add(1);
            list.Add(11);
            for(int i = 0; i < list.Count; i++)
            {
                Console.Write(list[i] + ", ");
            }
            Console.WriteLine();

            list.Sort();
            for(int i = 0; i < list.Count; i++)
            {
                Console.Write(list[i] + ", ");
            }
            Console.WriteLine();

            #region 一、自定义类的排序
            List<Item> items = new List<Item>();
            items.Add(new Item(7));
            items.Add(new Item(3));
            items.Add(new Item(1));
            items.Add(new Item(10));
            items.Add(new Item(8));
            items.Add(new Item(12));
            items.Sort();
            for(int i = 0; i < items.Count; i++)
            {
                Console.Write((items[i].money) + " ");
            }
            Console.WriteLine();
            #endregion

            #region 二、通过委托函数进行排序
            List<ShopItem> shopItems = new List<ShopItem>();
            shopItems.Add(new ShopItem(2));
            shopItems.Add(new ShopItem(1));
            shopItems.Add(new ShopItem(6));
            shopItems.Add(new ShopItem(4));
            shopItems.Add(new ShopItem(3));
            shopItems.Add(new ShopItem(5));

            // lambda 配合 三目运算符
            shopItems.Sort((ShopItem a, ShopItem b) => {return a.id > b.id ? 1 : -1;});  // 升序

            for (int i = 0; i < shopItems.Count; i++)
            {
                Console.Write(shopItems[i].id + " ");
            }
            Console.WriteLine();
            #endregion

        }

        static int SortShopItem(ShopItem a, ShopItem b)
        {
            // 传入的两个对象为列表中的两个对象
            // 进行两两的比较   用左边的和右边的条件 比较
            // 返回值规则 和之前一样

            // if (a.id > b.id)
            // {
            //     return 1;
            // }
            // else
            // {
            //     return -1;
            // }

            // 也可以直接返回
            return a.id - b.id;
        }
    }

    /*
    总结：
        系统自带的变量（int、double....）一般都可以直接Sort
    自定义类Sort有两种方式
        1.继承接口 IComparable
        2.在Sort中传入委托函数
    */
};


