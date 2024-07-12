namespace Lesson_11_indexer;

class Program
{
    class Person
    {
        private string name;
        private int age;
        private Person[] friends;
        private int[,] Vector2;

        // 索引器可以重载
        public int this[int i, int j]
        {
            get { return Vector2[i, j]};
            set { Vector2[i, j] = value;}
        }

        public string this[string str]
        {
            get
            {
                switch (str)
                {
                    case "name":
                        return this.name;
                        break;
                    case "age":
                        return this.age.ToString();
                        break;
                }
                return "";
            }
        }

        public Person() this[int index]
        {
            get
            { 
                if(friends == null || friends.Length - 1 < index)   // 越界处理
                {
                    return null;
                }
                return friends[index];
            }
            set
            {
                if(friends == null)
                {
                    friends = new Person[] { value };
                }
                else if(index > friends.Length - 1)
                {
                    // 如果索引越界，就默认把最后一个朋友替换
                    friends[friends.Length - 1] = value;
                }
                friends[index] = value;
            }
        }
    }


    static void Main(string[] args)
    {
        Console.WriteLine("索引器");

        #region 索引器的使用
        Person p = new Person();
        p[0] = new Person();
        Console.WriteLine(p[0]);

        p[0, 0] = 10;

        #endregion
    }

    // 总结
    // 索引器对于我们来说的主要作用
    // 可以让我们以中括号的形式范围自定义类中的元素 规则自己定 访问时和数组一定 （类似于 Template）
    // 比较适用于 在类中有数组变量中使用 可以方便的访问和进行逻辑处理

    // 国定写法:|访问修饰符 返回值 this[参数列表]
    //         |     get { }
    //         |     set { }
}
