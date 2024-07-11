namespace Lesson_09_Member_method;

class Program
{
    #region 成员方法
    class Person
    {
        public Person(string name, int age)
        {
            this.name = name;
            this.age = age;
            this.friends = new Person[0];
        }

        public void Speak(string str)
        {
            Console.WriteLine("{0}说{1}", name, str);
        }

        public bool InAdult()
        {
            return age >= 18;
        }

        public void AddFriend(Person p)
        {
            if(friends == null)
            {
                friends = new Person[] { p };   // 初始化
            }
            else
            {
                // 数组扩容
                Person[] newFriends = new Person[friends.Length + 1];
                for(int i = 0; i < friends.Length; i++)
                {
                    newFriends[i] = friends[i];
                }
                newFriends[newFriends.Length - 1] = p;
                // 地址重定向
                friends = newFriends;
            }
        }

        public void PrintFriendName(Person p)
        {
            for(int i = 0; i < friends.Length; i++)
            {
                Console.WriteLine(p.friends[i].name);
            }    
        }

        private string name;
        private int age;
        public Person[] friends;
    }

    #endregion

    static void Main(string[] args)
    {
        Console.WriteLine("成员方法");

        #region 成员方法的使用
        Person p = new Person("wxj", 18);
        p.Speak("666");
        if(p.InAdult())
        {
            p.Speak("我要耍朋友");
        }

        Person p2 = new Person("cjb", 19);
        p.AddFriend(p2);
        p.PrintFriendName(p);

        #endregion
    }
}
