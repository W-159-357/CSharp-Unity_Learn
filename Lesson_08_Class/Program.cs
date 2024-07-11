namespace Lesson_08_Class
{
    #region 类
    // class Person
    // {
         
    // }

    // class Machine
    // {

    // }
    #endregion

    #region 类和对象练习
    class GameObject
    {

    }
    #endregion

    #region 成员变量和访问修饰符

    // 性别枚举
    enum E_SexType
    {
        Man,
        Woman,
    }

    // 位置结构体
    struct Position
    {
        double x,
        double y,
        double z,
    }

    // 宠物类
    class Pet
    {

    }

    class Person
    {
        public string name = "Jack";   // 可以进行默认初始化
        public int age;
        public E_SexType sex;
        public Person gridFriend = null;      // 如果要在类中声明一个和自己相同类型的成员变量时，不能对他进行实例化（不能new,可以为null）
        public Person[] boyFriend;
        public Position pos;
        public Pet pet;

        public Person(string name, int age, E_SexType sex, Person gridFriend, Person[] boyFriend, Position pos, Pet pet)
        {
            this.name = name;
            this.age = age;
            this.sex = sex;
            this.boyFriend = boyFriend;
            this.pos = pos;
            this.pet = pet;
        }
    }
    #endregion
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("类和对象");

            #region 实现化对象
            // Person p;
            // Person p2 = null;           // 不分配堆空间
            // Person p3 = new Person();   // 会分配堆空间

            // Machine m = new Machine();
            // Machine M1 = new Machine();
            #endregion

            #region 类和对象练习题一
    

            #endregion

            #region 类和对象练习题二
            GameObject A = new GameObject();
            GameObject B = A;
            B = null;
            // A目前等于多少？--------------- A不变
            #endregion

            #region 类和对象练习题三
            GameObject C = new GameObject();
            GameObject D = C;
            D = new GameObject();
            // A和B有什么关系？-------------- C与D没有关系
            #endregion

            #region 成员变量和访问修饰符的使用
            // 值类型来说 数字类型 默认值为0 bool 默认为 false
            // 引用类型默认为 null
            Person p = new Person();
            p.age = 18;
            #endregion

            #region 成员变量和访问修饰符练习题一
            Person person = new Person();
            person.name = "Nike";
            person.age = 18;
            person.sex = E_SexType.Man;

            Person person1 = new Person("Mike", 19, E_SexType.Woman);
            #endregion

        }
    }
};


