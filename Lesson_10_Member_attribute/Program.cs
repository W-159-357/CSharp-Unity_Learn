namespace Lesson_10_Member_attribute;

class Program
{
    class Person
    {
        private string name;
        private int age;
        private int money;
        private bool sex;

        public string Name
        {
            get { return name; }
            set { name = value; }
        }

        public int Money
        {
            private get
            {
                // 解密处理
                return money - 5;
            }
            set
            {
                // 加密处理
                if(value < 0)
                {
                    value = 0;
                    Console.WriteLine("钱不能少于0,已经修正为0了!");
                }
                money = value + 5;
            }
        }

        #region  get 和 set 可以只有一个, 一般情况下只会出现只有 get 的情况, 基本不会出现只有 set
        public bool Sex
        {
            get { return sex; }
        }
        #endregion

        #region  自动属性 (类中有一个特征是只希望外部能得不能改的 又没有什么特殊处理)
        public float Height
        {
            get;
            private set;
        }
        #endregion
    
    }

    static void Main(string[] args)
    {
        Console.WriteLine("成员属性");

        Person p = new Person();
        p.Name = "Jack";
        Console.WriteLine(p.Name);

        p.Money = -1;
        // Console.WriteLine(p.Money);     // get 设置为 private 后，就不用访问 p.Money 了 
    }

    // 总结
    // 1.成员属性概念：一般是用来保护成员变量的
    // 2.成员属性的使用和变量一样 外部用对象点出
    // 3.get中需要return内容 ; set中用value表示传入的内容
    // 4.get和set语句块中可以加逻辑处理
    // 5.get和set可以家访问修饰符，但是要按照一定的规则进行添加
    // 6.get和set可以只有一个
    // 7.自动属性是属性语句块中只有get和set， 一般用于外部能得不能改的这种情况
}
